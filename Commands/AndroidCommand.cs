using System.Collections.Generic;
using MatterOverdrive.Modules;
using MatterOverdrive.Players;
using Terraria;
using Terraria.ModLoader;

namespace MatterOverdrive.Commands
{
    public abstract class AndroidCommand : ModCommand
    {
        protected AndroidCommand(string name, params string[] aliases) : this(name, new ModuleVersion[0], aliases) { }

        protected AndroidCommand(string name, ModuleVersion[] requiredModuleVersions, params string[] aliases)
        {
            Command = name;
            RequiredModulesVersions = requiredModuleVersions;

            Aliases = new List<string>(aliases).AsReadOnly();
        }


        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (caller.Player == null)
                return;

            Action(caller.Player, input, args);
        }

        public void Action(Player player, string input, string[] args)
        {
            MOPlayer moPlayer = player.GetModPlayer<MOPlayer>();

            if (!CanUse(moPlayer))
                return;

            if (player == Main.LocalPlayer)
                Main.NewText($"Executed command {input}");

            input = input.TrimStart('/');

            Run(moPlayer, input.Split(' ')[0], input, string.Join(" ", args).ParseLine());
        }


        public abstract bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args);


        public virtual bool CanUse(MOPlayer moPlayer)
        {
            if (!moPlayer.Android)
                return false;

            for (int i = 0; i < RequiredModulesVersions.Length; i++)
                if (!moPlayer.HasModule(RequiredModulesVersions[i]))
                    return false;

            return true;
        }

        public virtual string GetUsage(MOPlayer player) => "";


        public override string Command { get; }
        public override string Usage => GetUsage(MOPlayer.Get());

        public override CommandType Type { get; } = CommandType.Chat;

        public ModuleVersion[] RequiredModulesVersions { get; }

        public IReadOnlyList<string> Aliases { get; }
    }
}