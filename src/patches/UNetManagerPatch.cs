
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

using HarmonyLib;
using Brix.Network;

namespace CastleStory_MultiplayerPlusPlugin
{
    [HarmonyPatch(typeof(UNetManager), nameof(UNetManager.Initialize))]
    public class UNetManagerPatch
    {
        static void Postfix(UNetManager __instance)
        {
            __instance.maxConnections = 10;
            __instance.maxPlayers = 10;
        }

        [HarmonyTranspiler]
        [HarmonyPatch(nameof(UNetManager.StartHostMultiplayer))]
        static IEnumerable<CodeInstruction> StartHostMultiplayerTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            for (var i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldc_I4_2)
                {
                    if (codes[i + 1].opcode == OpCodes.Ldc_I4_4)
                    {
                        if (codes[i + 2].opcode == OpCodes.Call)
                        {
                            codes[i + 1] = new CodeInstruction(OpCodes.Ldc_I4, 10);
                        }
                    }
                }
            }
            return codes.AsEnumerable();
        }
    }
}
