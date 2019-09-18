using System;
using System.Collections.Generic;
using MatterOverdrive.Players;
using Terraria.ModLoader;
using WebmilioCommons.Loaders;

namespace MatterOverdrive.Commands
{
    public class CommandLoader : SingletonLoader<CommandLoader, AndroidCommand>
    {
        protected Dictionary<string, Type> typeByName = new Dictionary<string, Type>();


        protected override void PostAdd(Mod mod, AndroidCommand item)
        {
            typeByName.Add(item.Command.ToLower(), item.GetType());

            for (int i = 0; i < item.Aliases.Count; i++)
                typeByName.Add(item.Aliases[i], item.GetType());
        }


        public List<AndroidCommand> GetAvailableCommands(MOPlayer moPlayer)
        {
            List<AndroidCommand> commands = new List<AndroidCommand>();

            foreach (Type type in idByType.Keys)
            {
                AndroidCommand androidCommand = New(type);

                if (androidCommand.CanUse(moPlayer))
                    commands.Add(androidCommand);
            }

            return commands;
        }


        public bool TryRunning(MOPlayer moPlayer, string commandName, string input, List<string> args)
        {
            AndroidCommand command = New(commandName);

            if (!command.CanUse(moPlayer))
                return false;

            return command.Run(moPlayer, commandName, input, args);
        }

        public bool TryRunning(MOPlayer moPlayer, AndroidCommand command, string input, List<string> args)
        {
            if (!command.CanUse(moPlayer))
                return false;

            return command.Run(moPlayer, command.Command, input, args);
        }


        public bool Exists(string command) => typeByName.ContainsKey(command);


        public AndroidCommand New(string commandName) => New(typeByName[commandName.ToLower()]);
    }
}