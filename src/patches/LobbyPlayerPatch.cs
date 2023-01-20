using Brix.Network;
using Brix.UI.Builder.Menu;
using HarmonyLib;

namespace CastleStory_MultiplayerPlusPlugin
{
    [HarmonyPatch(typeof(LobbyPlayer), nameof(LobbyPlayer.CmdSendChatMessage))]
    public class LobbyPlayerPatch
    {

        static void Postfix(LobbyPlayer __instance, string message)
        {
            if (__instance.hasAuthority && message.Equals("/teams"))
            {
                int team = 0;
                UNetManager.instance.LobbyPlayerList.ForEach(delegate (LobbyPlayer lp)
                {
                    lp.CallCmdSetTeam(team);
                    string chatMessage = string.Format("<color=#{0}>{1} has changed team to {2}.</color>", BaseMenu.HexCastleYellow, lp.playerName, team);
                    lp.CallRpcServerNewChatMessage(chatMessage);
                    team++;
                });
            }
        }
    }
}
