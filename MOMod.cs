using System.Collections.Generic;
using System.IO;
using MatterOverdrive.Upgrades;
using MatterOverdrive.UserInterfaces.Terminal;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
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

            if(!Main.dedServ)
            {
                TerminalLayer = new TerminalLayer();
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if(TerminalLayer.TerminalUIState.Visible)
                TerminalLayer.TerminalInterface.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Insert(layers.FindIndex(x => x.Name == "Vanilla: Mouse Text"), TerminalLayer); 
        }

        public override void Unload()
        {
            UpgradeLoader.Instance.Unload();

            Instance = null;
        }


        public override void HandlePacket(BinaryReader reader, int whoAmI) => NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);


        public static MOMod Instance { get; private set; }

        public TerminalLayer TerminalLayer { get; private set; }
    }
}