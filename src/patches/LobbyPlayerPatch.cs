using HarmonyLib;
using Brix.Network;

namespace CastleStory_MultiplayerPlusPlugin
{
    [HarmonyPatch(typeof(LobbyPlayer), nameof(LobbyPlayer.CmdSendChatMessage))]
    public class LobbyPlayerPatch
    { 
        static bool Prefix(LobbyPlayer __instance, string message)
        {
            if (__instance.hasAuthority && message.Equals("/teams"))
			{
				int team = 0;
				UNetManager.instance.LobbyPlayerList.ForEach(delegate(LobbyPlayer lp)
				{
					lp.CallCmdSetTeam(team++);
				});
				return false;
			}
            return true;
        }
    }
}
