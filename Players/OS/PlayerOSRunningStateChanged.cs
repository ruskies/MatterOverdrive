using WebmilioCommons.Networking.Packets;

namespace MatterOverdrive.Players
{
    public class PlayerOSRunningStateChanged : ModPlayerNetworkPacket<MOPlayer>
    {
        public bool Running
        {
            get => ModPlayer.Running;
            set => ModPlayer.Running = value;
        }
    }
}