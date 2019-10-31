using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatterOverdrive.Modules;
using MatterOverdrive.Players;
using Terraria;

namespace MatterOverdrive.Commands.Utility
{
    public class HelpAndroidCommand : AndroidCommand
    {
        public HelpAndroidCommand() : base("help", "?")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            List<AndroidCommand> commands = CommandLoader.Instance.GetAvailableCommands(moPlayer).OrderBy(c => c.Command).ToList();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < commands.Count; i++)
                sb.AppendLine(commands[i].Command);

            Main.NewTextMultiline(sb.ToString());
            return true;
        }
    }
}