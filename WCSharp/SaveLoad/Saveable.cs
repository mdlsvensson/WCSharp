﻿using static War3Api.Common;

namespace WCSharp.SaveLoad
{
	public abstract class Saveable
	{
		/// <summary>
		/// The player that this Saveable is bound to.
		/// </summary>
		public player Player { get; set; }
		/// <summary>
		/// The save slot that this Saveable is bound to.
		/// </summary>
		public int SaveSlot { get; set; }

		/// <summary>
		/// Stores this saveable to file for the appropriate player and save slot.
		/// </summary>
		public void Save()
		{
			if (GetLocalPlayer() == Player)
			{
				var save = new Save(Player, SaveSlot);
				save.Serialize(this);
				SaveSystem.Save(save);
			}
		}
	}
}
