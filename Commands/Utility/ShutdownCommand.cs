using System.Collections.Generic;
using MatterOverdrive.Players;
using Terraria;
using Terraria.ID;

namespace MatterOverdrive.Commands.Utility
{
    public class ShutdownCommand : Command
    {
        public ShutdownCommand() : base("shutdown")
        {
        }

        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            if (args.Count == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Main.NewText("This function is disabled in SinglePlayer.");
                return true;
            }

            moPlayer.Shutdown(0);
            return true;
        }
    }
}