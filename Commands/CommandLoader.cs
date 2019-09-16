using System;
using System.Collections.Generic;
using MatterOverdrive.Players;
using Terraria.ModLoader;
using WebmilioCommons.Loaders;

namespace MatterOverdrive.Commands
{
    public class CommandLoader : SingletonLoader<CommandLoader, Command>
    {
        protected Dictionary<string, Type> typeByName = new Dictionary<string, Type>();


        protected override void PostAdd(Mod mod, Command item)
        {
            typeByName.Add(item.Name.ToLower(), item.GetType());

            for (int i = 0; i < item.Aliases.Count; i++)
                typeByName.Add(item.Aliases[i], item.GetType());
        }


        public List<Command> GetAvailableCommands(MOPlayer moPlayer)
        {
            List<Command> commands = new List<Command>();

            foreach (Type type in idByType.Keys)
            {
                Command command = New(type);

                if (command.CanUse(moPlayer))
                    commands.Add(command);
            }

            return commands;
        }


        public bool Exists(string command) => typeByName.ContainsKey(command);


        public Command New(string commandName) => New(typeByName[commandName.ToLower()]);
    }
}