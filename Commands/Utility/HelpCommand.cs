using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatterOverdrive.Modules;
using MatterOverdrive.Players;
using Terraria;

namespace MatterOverdrive.Commands.Utility
{
    public class HelpCommand : Command
    {
        public HelpCommand() : base("help", new Module[0], "?")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            List<Command> commands = CommandLoader.Instance.GetAvailableCommands(moPlayer).OrderBy(c => c.Name).ToList();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < commands.Count; i++)
                sb.AppendLine(commands[i].Name);

            Main.NewTextMultiline(sb.ToString());
            return true;
        }
    }
}