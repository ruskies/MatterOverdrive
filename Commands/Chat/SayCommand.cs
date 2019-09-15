using System.Collections.Generic;
using MatterOverdrive.Players;
using Terraria;

namespace MatterOverdrive.Commands.Chat
{
    public class SayCommand : Command
    {
        public SayCommand() : base("say")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            if (args.Count == 0)
                return false;

            Main.NewText($"{moPlayer.player.name} says {string.Join(" ", args)}");
            return true;
        }
    }
}