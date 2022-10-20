﻿namespace WCSharp.Events
{
	/// <summary>
	/// Defines all built-in ResearchEvents supported by <see cref="PlayerUnitEvents"/>.
	/// <para>All of these events fire based on a research id filter.</para>
	/// <para>Custom events can also be specified via <see cref="PlayerUnitEvents.AddCustomEvent(string, System.Func{int}, War3Api.Common.playerunitevent)"/>.</para>
	/// </summary>
	public enum ResearchEvent
	{
		/// <summary>
		/// Based on EVENT_PLAYER_UNIT_RESEARCH_CANCEL
		/// </summary>
		IsCancelled = 501,
		/// <summary>
		/// Based on EVENT_PLAYER_UNIT_RESEARCH_FINISH
		/// </summary>
		IsFinished = 502,
		/// <summary>
		/// Based on EVENT_PLAYER_UNIT_RESEARCH_START
		/// </summary>
		IsStarted = 503,
	}
}
