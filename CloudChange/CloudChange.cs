using System;
using System.Reflection;
using FrooxEngine;
using HarmonyLib;
using NeosModLoader;
using UnityEngine;
using CloudX.Shared;

namespace CloudChange
{
	class CloudChange : NeosMod
	{
		public override string Name => BuildInfo.Name;
		public override string Author => BuildInfo.Author;
		public override string Version => BuildInfo.Version;
		public override string Link => BuildInfo.Link;

		[AutoRegisterConfigKey]
		private static readonly ModConfigurationKey<string> API_URL = new("API URL", "API URL: The endpoint for most of the API actions in Neos.", () => "https://api.neos.com");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> BLOB_STORAGE_URL = new("Blob Storage URL", "Blob Storage URL: The root endpoint which stores all the assets for all objects.", () => "https://assets.neos.com/");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> ASSETS_BLOB_URL = new("Blob Retrieval URL", "Blob Retrieval URL: The endpoint which retrieves the assets stored at the Blob Storage URL", () => "https://cloudxstorage.blob.core.windows.net/assets/");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> ASSETS_CDN_URL = new("CDN URL", "CDN URL: The endpoint which delivers assets faster than the Blob Retrieval URL.", () => "https://assets.neos.com/assets/");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> VIDEO_CDN_URL = new("Video CDN URL", "Video CDN URL: The endpoint which delivers specifically video assets saved to your inventory (neosdb videos)", () => "https://assets.neos.com/assets/");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> OLD_THUMBNAIL_URL = new("Old Thumbnail URL", "Old Thumbnail URL: The endpoint which used to store and retrieve thumbnails for sessions.", () => "https://cloudxstorage.blob.core.windows.net/thumbnails/");
        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<string> THUMBNAIL_URL = new("Thumbnail URL", "Thumbnail URL: The endpoint which stores and retrieves thumbnails for sessions.", () => "https://operationaldata.neos.com/thumbnails/");

		private static ModConfiguration config;
        public override void OnEngineInit()
		{
			config = GetConfiguration();
			try
			{
				Harmony harmony = new(BuildInfo.GUID);
				harmony.PatchAll();
			}
			catch (Exception ex)
			{
				Error(ex);
			}
		}

        [HarmonyPatch(typeof(CloudXInterface))]
        class URL_Patches
		{
            [HarmonyPostfix]
            [HarmonyPatch("NEOS_API", MethodType.Getter)]
            public static void ChangeAPI_URL(ref string __result)
            {
				__result = config.GetValue(API_URL);
			}

            [HarmonyPostfix]
            [HarmonyPatch("NEOS_BLOB", MethodType.Getter)]
            public static void ChangeBlobURL(ref string __result)
            {
                __result = config.GetValue(BLOB_STORAGE_URL);
            }

            [HarmonyPostfix]
            [HarmonyPatch("NEOS_ASSETS_BLOB", MethodType.Getter)]
            public static void ChangeAssetsBlobURL(ref string __result)
            {
                __result = config.GetValue(ASSETS_BLOB_URL);
            }

            [HarmonyPostfix]
            [HarmonyPatch("NEOS_ASSETS_CDN", MethodType.Getter)]
            public static void ChangeCDN_URL(ref string __result)
            {
                __result = config.GetValue(ASSETS_CDN_URL);
            }

            [HarmonyPostfix]
            [HarmonyPatch("NEOS_ASSETS_VIDEO_CDN", MethodType.Getter)]
            public static void ChangeVideoCDN_URL(ref string __result)
            {
                __result = config.GetValue(VIDEO_CDN_URL);
            }

            [HarmonyPostfix]
            [HarmonyPatch("NEOS_THUMBNAILS_OLD", MethodType.Getter)]
            public static void ChangeOldThumbnailURL(ref string __result)
            {
                __result = config.GetValue(OLD_THUMBNAIL_URL);
            }

            [HarmonyPostfix]
            [HarmonyPatch("NEOS_THUMBNAILS", MethodType.Getter)]
            public static void ChangeThumbnailURL(ref string __result)
            {
                __result = config.GetValue(THUMBNAIL_URL);
            }
        }
		
	}
}
