﻿using static War3Api.Common;

namespace WCSharp.Api
{
#pragma warning disable CS0626 // Method, operator, or accessor is marked external and has no attributes on it
	/// @CSharpLua.Ignore
	public class Widget : Agent
	{
		internal Widget()
		{
		}

		/// @CSharpLua.Template = "{0}"
		public static extern implicit operator widget(Widget x);
		/// @CSharpLua.Template = "{0}"
		public static extern implicit operator Widget(widget x);

		/// @CSharpLua.Get = "GetWidgetLife({0})"
		/// @CSharpLua.Set = "SetWidgetLife({0}, {1})"
		public extern float Life { get; set; }

		/// @CSharpLua.Get = "GetWidgetX({0})"
		/// @CSharpLua.Set = "SetWidgetX({0}, {1})"
		public extern virtual float X { get; set; }

		/// @CSharpLua.Get = "GetWidgetY({0})"
		/// @CSharpLua.Set = "SetWidgetY({0}, {1})"
		public extern virtual float Y { get; set; }

		/// @CSharpLua.Template = "AddSpecialEffectTarget({1}, {0}, {2})"
		public extern Effect AddSpecialEffect(string model, string attachmentPoint);

		/// @CSharpLua.Template = "AddSpellEffectTarget({1}, {3}, {0}, {2})"
		public extern Effect AddSpellEffect(string model, string attachmentPoint, EffectType type);

		/// @CSharpLua.Template = "AddSpellEffectTargetById({1}, {3}, {0}, {2})"
		public extern Effect AddSpellEffect(int abilityId, string attachmentPoint, EffectType type);

		/// @CSharpLua.Template = "AddIndicator({0}, {1}, {2}, {3}, {4})"
		public extern Effect AddIndicator(int red, int green, int blue, int alpha = 255);
	}
}
