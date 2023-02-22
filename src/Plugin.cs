using System;
using System.Linq;

using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

using Brix.Game;
using Brix.UI.Icons;

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

            FixFlagIcons();
        }

        private void FixFlagIcons()
        {
            Enumerable.Range(0, 100).Do(i => Faction.IconKeyMap.Add(i.ToString(), IconKeys._UI_FlagSmall));
        }
    }
}
