using System.Collections.Generic;
using MatterOverdrive.Players;

namespace MatterOverdrive.Commands.Utility.Binds
{
    public class UnbindAllAndroidCommand : AndroidCommand
    {
        public UnbindAllAndroidCommand() : base("unbindall")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            moPlayer.UnbindAll();
            return true;
        }
    }
}