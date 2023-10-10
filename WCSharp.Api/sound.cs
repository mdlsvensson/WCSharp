﻿using System;

namespace WCSharp.Api
{
	/// @CSharpLua.Ignore
	public class sound : agent, IDisposable
	{
		internal sound()
		{
		}

		/// @CSharpLua.Template = "CreateSound({0}, {1}, {2}, {3}, {4}, {5}, {6})"
		public static extern sound CreateFromFile(string fileName, bool looping, bool is3D, bool stopWhenOutOfRange, int fadeInRate, int fadeOutRate, string eaxSetting);
		/// @CSharpLua.Template = "CreateSoundFilenameWithLabel({0}, {1}, {2}, {3}, {4}, {5}, {6})"
		public static extern sound CreateFromSlk(string fileName, bool looping, bool is3D, bool stopWhenOutOfRange, int fadeInRate, int fadeOutRate, string slkEntryName);
		/// @CSharpLua.Template = "CreateSoundFilenameWithLabel({0}, {1}, {2}, {3}, {4}, {5}, {6})"
		public static extern sound CreateFromLabel(string soundLabel, bool looping, bool is3D, bool stopWhenOutOfRange, int fadeInRate, int fadeOutRate);
		/// @CSharpLua.Template = "CreateMIDISound({0}, {1}, {2})"
		public static extern sound CreateFromMidi(string soundLabel, int fadeInRate, int fadeOutRate);

		/// @CSharpLua.Template = "GetSoundFileDuration({0})"
		public static extern float GetDuration(string fileName);

		/// @CSharpLua.Get = "GetSoundDuration({0})"
		/// @CSharpLua.Set = "SetSoundDuration({0}, {1})"
		public float Duration { get; set; }

		/// @CSharpLua.Get = "GetDialogueSpeakerNameKey({0})"
		/// @CSharpLua.Set = "SetDialogueSpeakerNameKey({0}, {1})"
		public string DialogueSpeakerName { get; set; }

		/// @CSharpLua.Get = "GetDialogueTextKey({0})"
		/// @CSharpLua.Set = "SetDialogueTextKey({0}, {1})"
		public string DialogueText { get; set; }

		/// @CSharpLua.Get = "GetSoundIsPlaying({0})"
		/// @CSharpLua.Set = "if {1} then StartSound({0}) else StopSound({0}) end"
		public bool IsPlaying { get; set; }

		/// @CSharpLua.Get = "GetSoundIsLoading({0})"
		public bool IsLoading { get; }

		/// @CSharpLua.Template = "SetSoundParamsFromLabel({this}, {0})"
		public extern void SetParamsFromLabel(string soundLabel);
		/// @CSharpLua.Template = "SetSoundDistanceCutoff({this}, {0})"
		public extern void SetDistanceCutoff(float cutoff);
		/// @CSharpLua.Template = "SetSoundChannel({this}, {0})"
		public extern void SetChannel(int channel);
		/// @CSharpLua.Template = "SetSoundVolume({this}, {0})"
		public extern void SetVolume(int volume);
		/// @CSharpLua.Template = "SetSoundPitch({this}, {0})"
		public extern void SetPitch(float pitch);

		/// @CSharpLua.Template = "SetSoundPlayPosition({this}, {0})"
		public extern void SetPlayPosition(float milliseconds);

		/// @CSharpLua.Template = "SetSoundDistances({this}, {0}, {1})"
		public extern void SetDistances(float minDistance, float maxDistance);
		/// @CSharpLua.Template = "SetSoundConeAngles({this}, {0}, {1}, {2})"
		public extern void SetConeAngles(float inside, float outside, int outsideVolume);
		/// @CSharpLua.Template = "SetSoundConeOrientation({this}, {0}, {1}, {2})"
		public extern void SetConeOrientation(float x, float y, float z);
		/// @CSharpLua.Template = "SetSoundPosition({this}, {0}, {1}, {2})"
		public extern void SetPosition(float x, float y, float z);
		/// @CSharpLua.Template = "SetSoundVelocity({this}, {0}, {1}, {2})"
		public extern void SetVelocity(float x, float y, float z);
		/// @CSharpLua.Template = "AttachSoundToUnit({this}, {0})"
		public extern void AttachToUnit(unit unit);

		/// @CSharpLua.Template = "StartSound({this})"
		public extern void Start();
		/// @CSharpLua.Template = "StartSoundEx({this}, {0})"
		public extern void Start(bool fadeIn);
		/// @CSharpLua.Template = "StopSound({this})"
		public extern void Stop();

		/// @CSharpLua.Template = "RegisterStackedSound({this}, {0}, {1}, {2})"
		public extern void RegisterStackedSound(bool byPosition, float rectWidth, float rectHeight);
		/// @CSharpLua.Template = "UnregisterStackedSound({this}, {0}, {1}, {2})"
		public extern void UnregisterStackedSound(bool byPosition, float rectWidth, float rectHeight);

		/// @CSharpLua.Template = "SetSoundFacialAnimationLabel({this}, {0})"
		public extern bool SetFacialAnimationLabel(string animationLabel);
		/// @CSharpLua.Template = "SetSoundFacialAnimationGroupLabel({this}, {0})"
		public extern bool SetFacialAnimationGroupLabel(string groupLabel);
		/// @CSharpLua.Template = "SetSoundFacialAnimationSetFilepath({this}, {0})"
		public extern bool SetFacialAnimationSetFilepath(string animationSetFilepath);

		/// @CSharpLua.Template = "KillSoundWhenDone({this})"
		public extern void Dispose();
	}
}
