using System.Collections.Generic;
using MatterOverdrive.Players;

namespace MatterOverdrive.Commands.Utility
{
    public class UnbindAllCommand : Command
    {
        public UnbindAllCommand() : base("unbindall")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            moPlayer.UnbindAll();
            return true;
        }
    }
}