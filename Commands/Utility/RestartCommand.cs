using System.Collections.Generic;
using MatterOverdrive.Players;

namespace MatterOverdrive.Commands.Utility
{
    public class RestartCommand : Command
    {
        public RestartCommand() : base("restart")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            CommandLoader.Instance.New<ShutdownCommand>().Run(moPlayer, usedName, inputLine, args);
            CommandLoader.Instance.New<StartCommand>().Run(moPlayer, usedName, inputLine, args);

            return true;
        }
    }
}