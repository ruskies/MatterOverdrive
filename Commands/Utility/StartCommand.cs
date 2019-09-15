using System.Collections.Generic;
using MatterOverdrive.Players;

namespace MatterOverdrive.Commands.Utility
{
    public class StartCommand : Command
    {
        public StartCommand() : base("start")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            if (args.Count == 0)
            {
                moPlayer.TryStart();
                return true;
            }

            return true;
        }
    }
}