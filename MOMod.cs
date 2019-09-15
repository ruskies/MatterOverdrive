using System.IO;
using MatterOverdrive.Upgrades;
using Terraria.ModLoader;
using WebmilioCommons.Networking;

namespace MatterOverdrive
{
	public class MOMod : Mod
	{
		public MOMod()
		{
            Instance = this;
		}


        public override void Load()
        {
            UpgradeLoader.Instance.Load();
        }

        public override void Unload()
        {
            UpgradeLoader.Instance.Unload();

            Instance = null;
        }


        public override void HandlePacket(BinaryReader reader, int whoAmI) => NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);


        public static MOMod Instance { get; private set; }
    }
}