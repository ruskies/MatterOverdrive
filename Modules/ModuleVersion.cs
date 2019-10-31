namespace MatterOverdrive.Modules
{
    public struct ModuleVersion
    {
        public readonly Module module;
        public readonly int version;


        public ModuleVersion(Module module, int version)
        {
            this.module = module;
            this.version = version;
        }
    }
}