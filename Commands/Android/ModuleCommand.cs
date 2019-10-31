using System.Collections.Generic;
using MatterOverdrive.Modules;
using MatterOverdrive.Players;

namespace MatterOverdrive.Commands.Android
{
    public class ModuleCommand : AndroidCommand
    {
        public ModuleCommand() : base("module", new ModuleVersion[]
            {
                new ModuleVersion(ModuleManager.Instance.InformationModule, 1), 
            }, 
            "mdle")
        {
        }


        public override bool Run(MOPlayer moPlayer, string usedName, string inputLine, List<string> args)
        {
            throw new System.NotImplementedException();
        }
    }
}