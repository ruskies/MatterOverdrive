using MatterOverdrive.Modules;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer
    {
        public bool HasModule(Module module) => true;

        public bool HasModules(params Module[] modules)
        {
            for (int i = 0; i < modules.Length; i++)
                if (!HasModule(modules[i]))
                    return false;

            return true;
        }
    }
}
