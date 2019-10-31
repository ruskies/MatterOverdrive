using System.IO;
using MatterOverdrive.Modules;
using WebmilioCommons.Networking.Packets;

namespace MatterOverdrive.Players
{
    public class PlayerModuleStateChanged : ModPlayerNetworkPacket<MOPlayer>
    {
        public PlayerModuleStateChanged()
        {
        }

        public PlayerModuleStateChanged(string unlocalizedName, int version)
        {
            UnlocalizedName = unlocalizedName;
            Version = version;
        }


        public override bool PostReceive(BinaryReader reader, int fromWho)
        {
            ModPlayer.InstallOrUpgradeModule(ModuleManager.Instance[UnlocalizedName], Version);

            return base.PostReceive(reader, fromWho);
        }


        public string UnlocalizedName { get; set; }

        public int Version { get; set; }
    }
}