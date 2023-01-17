using System;

using BepInEx;
using HarmonyLib;
using BepInEx.Logging;


namespace CastleStory_MultiplayerPlusPlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]

    public class Plugin : BaseUnityPlugin
    {
        private static Plugin _instance;
        public static Plugin Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException();
                }
                return _instance;
            }
        }

        public ManualLogSource Log { get { return Logger; } }

        private void Awake()
        {
            _instance = this;

            new Harmony("com.wasikuss.castlestory.multiplayerplus").PatchAll();
        }
    }
}
