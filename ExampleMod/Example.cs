using System;
using System.Reflection;
using FrooxEngine;
using HarmonyLib;
using NeosModLoader;
using UnityEngine;

namespace Example
{
	[HarmonyPatch]
	class ExampleMod : NeosMod
	{
		public override string Name => BuildInfo.Name;
		public override string Author => BuildInfo.Author;
		public override string Version => BuildInfo.Version;
		public override string Link => BuildInfo.Link;

		public override void OnEngineInit()
		{
			try
			{
				Harmony harmony = new(BuildInfo.GUID);
				harmony.PatchAll();
				Msg("Patched successfully");
			}
			catch (Exception ex)
			{
				Error(ex);
			}
		}

		[HarmonyPatch(typeof(CommonTool), "HoldMenu")]
		[HarmonyPostfix]
		private static void ExampleHarmonyPatch()
		{
			Msg("Do a thing!");
		}
	}
}
