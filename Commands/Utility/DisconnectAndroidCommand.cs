using System.Collections.Generic;
using MatterOverdrive.Players;
using Terraria;

namespace MatterOverdrive.Commands.Utility
{
    public class DisconnectAndroidCommand : AndroidCommand
    {
        public DisconnectAndroidCommand() : base("disconnect")
        {
        }
        

        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            WorldGen.SaveAndQuit();

            return true;
        }
    }
}