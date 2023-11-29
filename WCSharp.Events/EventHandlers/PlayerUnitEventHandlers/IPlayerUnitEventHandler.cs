﻿using System;
using WCSharp.Api;

namespace WCSharp.Events.EventHandlers.PlayerUnitEventHandlers
{
	internal interface IPlayerUnitEventHandler
	{
		void Register(Action action, int filterId);
		void Register(Action action, int filterId, Func<int> filterFunc, int filterValue);
		void Register(Action action, int filterId, Func<handle> filterFunc, handle filterValue);
		void Unregister(Action action, int filterId);
		void Unregister(Action action, int filterId, Func<int> filterFunc, int filterValue);
		void Unregister(Action action, int filterId, Func<handle> filterFunc, handle filterValue);
	}
}
