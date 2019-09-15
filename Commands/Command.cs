using System.Collections.Generic;
using MatterOverdrive.Modules;
using MatterOverdrive.Players;
using MatterOverdrive.Upgrades;

namespace MatterOverdrive.Commands
{
    public abstract class Command
    {
        protected Command(string name, params Module[] requiredModules) : this(name, requiredModules, new string[0]) { }

        protected Command(string name, Module[] requiredModule, params string[] aliases)
        {
            Name = name;

            RequiredModules = requiredModule;

            Aliases = new List<string>(aliases).AsReadOnly();
        }


        public abstract bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args);


        public virtual bool CanUse(MOPlayer moPlayer)
        {
            //if (moPlayer.HasModule())
            return true;
        }


        public string Name { get; }

        public Module[] RequiredModules { get; }

        public IReadOnlyList<string> Aliases { get; }
    }
}