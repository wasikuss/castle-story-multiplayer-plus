using Brix.Network;
using Brix.UI.Builder.Menu;
using HarmonyLib;

namespace CastleStory_MultiplayerPlusPlugin
{
    [HarmonyPatch(typeof(LobbyPlayer), nameof(LobbyPlayer.CmdSendChatMessage))]
    public class LobbyPlayerPatch
    { 
        static void Prefix(LobbyPlayer __instance, string message)
        {
            if (__instance.hasAuthority && message.Equals("/teams"))
			{
				int team = 0;
				UNetManager.instance.LobbyPlayerList.ForEach(delegate(LobbyPlayer lp)
				{
					lp.CallCmdSetTeam(team++);
				});
			}
        }
    }
}
