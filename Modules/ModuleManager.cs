using WebmilioCommons.Managers;

namespace MatterOverdrive.Modules
{
    public sealed class ModuleManager : SingletonManager<ModuleManager, Module>
    {
        public override void DefaultInitialize()
        {
            InformationModule = Add(new InformationModule());

            base.DefaultInitialize();
        }


        public InformationModule InformationModule { get; private set; }
    }
}