﻿using System;
using static War3Api.Common;

namespace WCSharp.Api
{
#pragma warning disable CS0626 // Method, operator, or accessor is marked external and has no attributes on it
	/// @CSharpLua.Ignore
	public class Multiboard : Agent, IDisposable
	{
		internal Multiboard()
		{
		}

		/// @CSharpLua.Template = "{0}"
		public static extern implicit operator multiboard(Multiboard x);
		/// @CSharpLua.Template = "{0}"
		public static extern implicit operator Multiboard(multiboard x);

		/// @CSharpLua.Template = "CreateMultiboard()"
		public static extern Multiboard Create();

		/// @CSharpLua.Template = "CreateMultiboard(~{0})"
		public static extern void SetVisibility(bool visible);

		/// @CSharpLua.Get = "IsMultiboardDisplayed({0})"
		/// @CSharpLua.Set = "MultiboardDisplay({0}, {1})"
		public extern bool IsDisplayed { get; set; }

		/// @CSharpLua.Get = "IsMultiboardMinimized({0})"
		/// @CSharpLua.Set = "MultiboardMinimize({0}, {1})"
		public extern bool IsMinimized { get; set; }

		/// @CSharpLua.Get = "MultiboardGetRowCount({0})"
		/// @CSharpLua.Set = "MultiboardSetRowCount({0}, {1})"
		public extern int Rows { get; set; }

		/// @CSharpLua.Get = "MultiboardGetColumnCount({0})"
		/// @CSharpLua.Set = "MultiboardSetColumnCount({0}, {1})"
		public extern int Columns { get; set; }

		/// @CSharpLua.Get = "MultiboardGetTitleText({0})"
		/// @CSharpLua.Set = "MultiboardSetTitleText({0}, {1})"
		public extern string Title { get; set; }

		/// @CSharpLua.Template = "MultiboardGetItem({0}, {1}, {2})"
		public extern MultiboardItem GetItem(int row, int column);

		/// @CSharpLua.Template = "MultiboardSetItem({0}, {1}, {2})"
		public extern MultiboardItem SetItem(int row, int column);

		/// @CSharpLua.Template = "MultiboardSetItemsStyle({0}, {1}, {2})"
		public extern void SetChildVisibility(bool showValue, bool showIcon);

		/// @CSharpLua.Template = "MultiboardSetItemsValue({0}, {1})"
		public extern void SetChildText(string value);

		/// @CSharpLua.Template = "MultiboardSetItemsValueColor({0}, {1}, {2}, 255)"
		public extern void SetChildColor(int red, int green, int blue);

		/// @CSharpLua.Template = "MultiboardSetItemsValueColor({0}, {1}, {2}, {3})"
		public extern void SetChildColor(int red, int green, int blue, int alpha);

		/// @CSharpLua.Template = "MultiboardSetItemsWidth({0}, {1})"
		public extern void SetChildWidth(float width);

		/// @CSharpLua.Template = "MultiboardSetItemsIcon({0}, {1})"
		public extern void SetChildIcon(string iconPath);

		/// @CSharpLua.Template = "MultiboardClear({0})"
		public extern void Clear();

		/// @CSharpLua.Template = "DestroyMultiboard({0})"
		public extern void Dispose();
	}
}
