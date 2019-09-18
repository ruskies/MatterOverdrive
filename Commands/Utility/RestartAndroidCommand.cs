using System.Collections.Generic;
using MatterOverdrive.Players;

namespace MatterOverdrive.Commands.Utility
{
    public class RestartAndroidCommand : AndroidCommand
    {
        public RestartAndroidCommand() : base("restart")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            CommandLoader.Instance.New<ShutdownAndroidCommand>().Run(moPlayer, usedName, inputLine, args);
            CommandLoader.Instance.New<StartAndroidCommand>().Run(moPlayer, usedName, inputLine, args);

            return true;
        }
    }
}