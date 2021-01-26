﻿using System.IO;
using System.Text;
using WCSharp.ConstantGenerator.Extensions;
using WCSharp.ConstantGenerator.Handlers.WcObjects;

namespace WCSharp.ConstantGenerator.Handlers
{
	internal class W3CHandler
	{
		private const string W3C_INPUT = "war3map.w3c";
		private const string W3C_OUTPUT = "Cameras.cs";

		private const string FILE = @"using static War3Api.Common;

public static class Cameras
{{
{0}

#pragma warning disable IDE0052 // Remove unread private members
	private static readonly object initialiser = Initialise();
#pragma warning restore IDE0052 // Remove unread private members
	private static object Initialise()
	{{
{1}
	}}
}}";

		public static void Run(string inputDirectory, string outputDirectory)
		{
			var input = Path.Combine(inputDirectory, W3C_INPUT);
			var output = Path.Combine(outputDirectory, W3C_OUTPUT);

			if (!File.Exists(input))
			{
				Abort(output);
				return;
			}

			var reader = new BinaryReader(File.OpenRead(input));
			var version = reader.ReadInt32(); // Should be 0
			var count = reader.ReadInt32();
			if (count == 0)
			{
				Abort(output);
				return;
			}

			var variables = new StringBuilder();
			var configuration = new StringBuilder();

			for (var i = 0; i < count; i++)
			{
				var camera = new Camera(reader);
				var name = camera.Name.Escape();
				variables.Append($"\tpublic static readonly camerasetup {name} = CreateCameraSetup();\r\n");
				configuration.Append($"\t\tCameraSetupSetDestPosition({name}, {camera.TargetX}f, {camera.TargetY}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_ZOFFSET, {camera.ZOffset}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_ROTATION, {camera.Rotation}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_ANGLE_OF_ATTACK, {camera.AngleOfAttack}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_TARGET_DISTANCE, {camera.Distance}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_ROLL, {camera.Roll}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_FIELD_OF_VIEW, {camera.FoV}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_FARZ, {camera.FarZ}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_NEARZ, {camera.NearZ}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_LOCAL_PITCH, {camera.LocalPitch}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_LOCAL_YAW, {camera.LocalYaw}f, 0);\r\n");
				configuration.Append($"\t\tCameraSetupSetField({name}, CAMERA_FIELD_LOCAL_ROLL, {camera.LocalRoll}f, 0);\r\n");
			}

			configuration.Append("\t\treturn null;");

			File.WriteAllText(output, string.Format(FILE, variables.ToString(), configuration.ToString()));
		}

		private static void Abort(string output)
		{
			if (File.Exists(output))
			{
				File.Delete(output);
			}
		}
	}
}
