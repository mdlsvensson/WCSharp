﻿using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace WCSharp.Events.EventHandlers.PlayerUnitEventHandlers
{
	internal abstract class AbstractPlayerUnitEventHandler : IPlayerUnitEventHandler
	{
		protected readonly List<IEventSet> eventSets;
		protected readonly trigger trigger;
		protected int index;
		protected int size;

		public AbstractPlayerUnitEventHandler()
		{
			this.eventSets = new List<IEventSet>();
			this.trigger = CreateTrigger();
		}

		public void Register(Func<int> filterFunc, Action action, int filterId)
		{
			var searchIndex = -1;
			for (var i = 0; i < this.eventSets.Count; i++)
			{
				if (this.eventSets[i].FilterFunc == filterFunc)
				{
					searchIndex = i;
					break;
				}
			}

			IEventSet eventSet;
			if (searchIndex == -1)
			{
				eventSet = filterId == 0 ? new EventSet() : new EventSetWithFilter(filterFunc);
				this.eventSets.Add(eventSet);

				if (this.eventSets.Count == 1)
				{
					EnableTrigger(this.trigger);
				}
			}
			else
			{
				eventSet = this.eventSets[searchIndex];
			}

			eventSet.Add(action, filterId);
		}

		public void Unregister(Func<int> filterFunc, Action action, int filterId)
		{
			var searchIndex = -1;
			for (var i = 0; i < this.eventSets.Count; i++)
			{
				if (this.eventSets[i].FilterFunc == filterFunc)
				{
					searchIndex = i;
					break;
				}
			}

			if (searchIndex == -1)
				return;

			var eventSet = this.eventSets[searchIndex];
			if (eventSet.Remove(action, filterId) && eventSet.Count == 0)
			{
				DisableTrigger(this.trigger);

				if (searchIndex < this.size)
				{
					if (searchIndex <= this.index)
					{
						this.eventSets.RemoveAt(searchIndex);
						this.index--;
						this.size--;
					}
					else
					{
						var actualSize = this.eventSets.Count;
						this.eventSets[searchIndex] = this.eventSets[this.size - 1];
						this.eventSets[this.size - 1] = this.eventSets[actualSize - 1];
						this.eventSets.RemoveAt(actualSize - 1);

						this.size--;
					}
				}
				else
				{
					var actualSize = this.eventSets.Count;
					this.eventSets[searchIndex] = this.eventSets[actualSize - 1];
					this.eventSets.RemoveAt(actualSize - 1);
				}
			}
		}

		protected bool Run()
		{
			this.index = 0;
			this.size = this.eventSets.Count;

			while (this.index < this.size)
			{
				this.eventSets[this.index++].Run();
			}

			return false;
		}
	}
}
