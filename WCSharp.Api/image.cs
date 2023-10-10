﻿using System;
namespace WCSharp.Api
{
	/// @CSharpLua.Ignore
	public class image : handle, IDisposable
	{
		internal image()
		{
		}

		/// @CSharpLua.Template = "CreateImage({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})"
		public static extern image Create(string file, float sizeX, float sizeY, float sizeZ, float posX, float posY, float posZ, float originX, float originY, float originZ, int imageType);

		/// @CSharpLua.Template = "ShowImage({0}, {1})"
		public extern void SetVisibility(bool visibility);
		/// @CSharpLua.Template = "SetImageConstantHeight({0}, {1}, {2})"
		public extern void SetConstantHeight(bool isConstant, float height);
		/// @CSharpLua.Template = "SetImagePosition({0}, {1}, {2}, {3})"
		public extern void SetPosition(float x, float y, float z);
		/// @CSharpLua.Template = "SetImageColor({0}, {1}, {2}, {3}, {4})"
		public extern void SetColor(int red, int green, int blue, int alpha = 255);
		/// @CSharpLua.Template = "SetImageRender({0}, {1})"
		public extern void SetRender(bool render);
		/// @CSharpLua.Template = "SetImageRenderAlways({0}, {1})"
		public extern void SetRenderAlways(bool renderAlways);
		/// @CSharpLua.Template = "SetImageAboveWater({0}, {1})"
		public extern void SetAboveWater(bool aboveWater);
		/// @CSharpLua.Template = "SetImageType({0}, {1})"
		public extern void SetType(int imageType);

		/// @CSharpLua.Template = "DestroyImage({0})"
		public extern void Dispose();
	}
}
