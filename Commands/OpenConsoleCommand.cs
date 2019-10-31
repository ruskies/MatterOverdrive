using System.Collections.Generic;
using MatterOverdrive.Android;
using MatterOverdrive.Players;
using Terraria;
using Terraria.ModLoader;

namespace MatterOverdrive.Commands
{
    public sealed class OpenConsoleCommand : AndroidCommand
    {
        public OpenConsoleCommand() : base("console")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            if (args.Count == 0)
            {
                //AndroidConsole.Open();
                //return;

                if (moPlayer.player == Main.LocalPlayer)
                    MOMod.Instance.TerminalLayer.TerminalUIState.Visible = true;

                return true;
            }

            List<string> parsedArgs = inputLine.ParseLine();
            parsedArgs.RemoveAt(0);

            string commandName = parsedArgs[0];
            parsedArgs.RemoveAt(0);

            if (!CommandLoader.Instance.Exists(commandName))
            {
                Main.NewText($"Command '{commandName}' not found. Use /help for a list of available commands.");
                return true;
            }

            return CommandLoader.Instance.TryRunning(moPlayer.player.GetModPlayer<MOPlayer>(), commandName, inputLine, parsedArgs);
        }


        public override CommandType Type { get; } = CommandType.Chat;
    }
}