using System.Collections.Generic;
using MatterOverdrive.Players;
using Terraria;
using Terraria.ModLoader;

namespace MatterOverdrive.Commands
{
    public sealed class OpenConsoleCommand : ModCommand
    {
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (args.Length == 0)
            {
                // TODO Open console
                return;
            }

            List<string> parsedArgs = input.ParseLine();
            parsedArgs.RemoveAt(0);

            string commandName = parsedArgs[0];
            parsedArgs.RemoveAt(0);

            if (!CommandLoader.Instance.Exists(commandName))
            {
                Main.NewText($"Command '{commandName}' not found. Use /help for a list of available commands.");
                return;
            }

            Command command = CommandLoader.Instance.New(commandName);

            MOPlayer moPlayer = caller.Player.GetModPlayer<MOPlayer>();

            if (!command.CanUse(moPlayer))
                return;

            command.Run(moPlayer, commandName, input, parsedArgs);
        }


        public override string Command { get; } = "console";
        public override CommandType Type { get; } = CommandType.Chat;
    }
}