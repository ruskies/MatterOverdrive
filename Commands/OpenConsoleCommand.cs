using System.Collections.Generic;
using MatterOverdrive.Android;
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
                AndroidConsole.Open();
                return;

                if (caller.Player == Main.LocalPlayer)
                    MOMod.Instance.TerminalLayer.TerminalUIState.Visible = true;

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

            CommandLoader.Instance.TryRunning(caller.Player.GetModPlayer<MOPlayer>(), commandName, input, parsedArgs);
        }


        public override string Command { get; } = "console";
        public override CommandType Type { get; } = CommandType.Chat;
    }
}