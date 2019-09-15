using System;
using System.Collections.Generic;
using MatterOverdrive.Players;
using Microsoft.Xna.Framework.Input;
using Terraria;

namespace MatterOverdrive.Commands.Utility
{
    public class UnbindCommand : Command
    {
        public UnbindCommand() : base("unbind")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            if (!Enum.TryParse(args[0], true, out Keys key))
            {
                Main.NewText($"Key {args[0]} not found.", 255, 0, 0);
                return true;
            }

            moPlayer.Unbind(key);
            return true;
        }
    }
}