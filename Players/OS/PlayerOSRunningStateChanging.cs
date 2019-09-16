using WebmilioCommons.Networking.Packets;

namespace MatterOverdrive.Players
{
    public sealed class PlayerOSRunningStateChanging : ModPlayerNetworkPacket<MOPlayer>
    {
        public PlayerOSRunningStateChanging()
        {
        }

        public PlayerOSRunningStateChanging(bool futureState)
        {
            FutureState = futureState;
        }


        public bool FutureState { get; set; }
    }
}