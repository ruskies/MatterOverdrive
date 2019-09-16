using WebmilioCommons.Networking.Packets;

namespace MatterOverdrive.Players
{
    public sealed class PlayerOSRunningStateChanged : ModPlayerNetworkPacket<MOPlayer>
    {
        public bool Running
        {
            get => ModPlayer.Running;
            set => ModPlayer.Running = value;
        }
    }
}