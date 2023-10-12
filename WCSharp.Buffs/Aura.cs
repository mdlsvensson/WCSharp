﻿using System.Collections.Generic;
using System.Linq;
using WCSharp.Events;
using WCSharp.Shared.Extensions;
using WCSharp.Api;
using static WCSharp.Api.Common;

namespace WCSharp.Buffs
{
	/// <summary>
	/// Auras constantly apply/refresh a linked <see cref="Buff"/> on valid targets in range.
	/// </summary>
	/// <typeparam name="T">The buff that will be applied by this aura.</typeparam>
	public abstract class Aura<T> : IAura
		where T : Buff
	{
		private static readonly group group = CreateGroup();

		/// <inheritdoc/>
		public bool Active { get; set; }
		/// <inheritdoc/>
		public unit Caster { get; set; }
		/// <inheritdoc/>
		public player CastingPlayer { get; set; }

		/// <inheritdoc/>
		public float Radius { get; set; }
		/// <summary>
		/// The duration in seconds of buffs applied by this aura. Defaults to 3.1.
		/// <para>Unless you're making a pulsing aura, you will want the <see cref="Duration"/> to be greater than the <see cref="SearchInterval"/>.</para>
		/// </summary>
		public float Duration { get; set; } = 3.1f;
		/// <inheritdoc/>
		public float SearchIntervalLeft { get; set; }
		/// <summary>
		/// How long in seconds between applications of this aura. Defaults to 1.0.
		/// </summary>
		public float SearchInterval { get; set; } = 1.0f;
		/// <inheritdoc/>
		public StackBehaviour StackBehaviour { get; set; }

		private string effectString;
		/// <inheritdoc/>
		public string EffectString
		{
			get => this.effectString;
			set
			{
				if (this.effectString != value)
				{
					this.effectString = value;
					if (Active)
					{
						if (Effect != null)
						{
							DestroyEffect(Effect);
						}
						Effect = string.IsNullOrEmpty(value) ? null : AddSpecialEffectTarget(value, Caster, this.effectAttachmentPoint);
					}
				}
			}
		}

		private string effectAttachmentPoint = "origin";
		/// <inheritdoc/>
		public string EffectAttachmentPoint
		{
			get => this.effectAttachmentPoint;
			set
			{
				value ??= "origin";
				if (this.effectAttachmentPoint != value)
				{
					this.effectAttachmentPoint = value;
					if (Effect != null)
					{
						DestroyEffect(Effect);
						Effect = AddSpecialEffectTarget(this.effectString, Caster, this.effectAttachmentPoint);
					}
				}
			}
		}

		/// <summary>
		/// Internal effect scale. Used only when there is no effect present yet.
		/// </summary>
		private protected float effectScale = 1.0f;
		/// <inheritdoc/>
		public float EffectScale
		{
			get => Effect == null ? this.effectScale : BlzGetSpecialEffectScale(Effect);
			set
			{
				if (Effect != null)
				{
					BlzSetSpecialEffectScale(Effect, value);
				}
				this.effectScale = value;
			}
		}

		/// <inheritdoc/>
		public effect Effect { get; set; }

		private readonly List<AuraBuffDuration<T>> activeBuffs;

		/// <summary>
		/// Creates a new aura centered around the given caster.
		/// </summary>
		public Aura(unit caster)
		{
			Caster = caster;
			CastingPlayer = GetOwningPlayer(caster);
			this.activeBuffs = new();
		}

		/// <summary>
		/// Use this method to create new aura buffs.
		/// <para>Duration will be set automatically.</para>
		/// </summary>
		/// <param name="unit">The unit on who the aura buff will be applied.</param>
		/// <returns>The aura buff to be applied.</returns>
		protected abstract T CreateAuraBuff(unit unit);

		/// <summary>
		/// Use this method to filter units that should be affected by this aura.
		/// </summary>
		/// <param name="unit">The unit to evaluate</param>
		/// <returns>True if the given unit should receive the aura buff.</returns>
		protected abstract bool UnitFilter(unit unit);

		/// <inheritdoc/>
		public void Apply()
		{
			if (!string.IsNullOrEmpty(this.effectString))
			{
				Effect = AddSpecialEffectTarget(this.effectString, Caster, this.effectAttachmentPoint);
				BlzSetSpecialEffectScale(Effect, this.effectScale);
			}
		}

		/// <inheritdoc/>
		public void Action()
		{
			if (SearchIntervalLeft <= PeriodicEvents.SYSTEM_INTERVAL)
			{
				SearchIntervalLeft = SearchInterval;
				GroupEnumUnitsInRange(group, GetUnitX(Caster), GetUnitY(Caster), Radius, null);
				foreach (var unit in group.ToList())
				{
					var handleId = GetHandleId(unit);
					var existingBuff = this.activeBuffs.FirstOrDefault(x => x.HandleId == handleId);
					if (existingBuff != null)
					{
						existingBuff.Duration = Duration;
						existingBuff.Buff.Duration = Duration;
					}
					else if (UnitFilter(unit))
					{
						var aura = (T)BuffSystem.Add(CreateAuraBuff(unit), StackBehaviour);
						aura.Duration = Duration;
						this.activeBuffs.Add(new AuraBuffDuration<T>(handleId, aura, Duration));
					}
				}
			}
			else
			{
				SearchIntervalLeft -= PeriodicEvents.SYSTEM_INTERVAL;
			}

			for (var i = this.activeBuffs.Count - 1; i >= 0; i--)
			{
				var buff = this.activeBuffs[i];
				if (buff.Duration <= 0)
				{
					buff.Buff.Stacks--;
					this.activeBuffs.RemoveAt(i);
				}
				else
				{
					buff.Duration -= PeriodicEvents.SYSTEM_INTERVAL;
				}
			}
		}

		/// <inheritdoc/>
		public IEnumerable<Buff> GetActiveBuffs()
		{
			return this.activeBuffs.Select(x => x.Buff);
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			if (Effect != null)
			{
				DestroyEffect(Effect);
			}
		}
	}
}
