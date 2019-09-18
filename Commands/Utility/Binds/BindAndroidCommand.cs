using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MatterOverdrive.Players;
using Microsoft.Xna.Framework.Input;
using Terraria;

namespace MatterOverdrive.Commands.Utility.Binds
{
    public class BindAndroidCommand : AndroidCommand
    {
        public BindAndroidCommand() : base("bind")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            if (args.Count == 1)
            {
                string arg = args[0].ToLower();

                if (arg == "-l" || arg == "-list")
                    ListBinds(moPlayer.Binds);

                return true;
            }

            if (args.Count < 2)
                return false;

            if (!Enum.TryParse(args[0], true, out Keys key))
            {
                Main.NewText($"Key {args[0]} not found.", 255, 0, 0);
                return true;
            }

            string[] splitLine = inputLine.Split(' ');
            string toBind = null;

            if (splitLine.Length < 2)
            {
                Main.NewText("Bind failed.", 255, 0, 0);
                return true;
            }

            if (!CommandLoader.Instance.Exists(splitLine[2]))
            {
                Main.NewText($"Command {splitLine[2]} does not exist.");
                return true;
            }

            for (int i = 2; i < splitLine.Length; i++)
            {
                toBind += splitLine[i];

                if (i + 1 < splitLine.Length)
                    toBind += " ";
            }

            moPlayer.Bind(key, toBind);

            return true;
        }

        private void ListBinds(IReadOnlyDictionary<Keys, string> binds)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<Keys, string> bind in binds)
                sb.AppendLine($"{bind.Key}: {bind.Value}");

            Main.NewTextMultiline(sb.ToString());
        }
    }
}