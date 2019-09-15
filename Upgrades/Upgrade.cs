using WebmilioCommons.Managers;

namespace MatterOverdrive.Upgrades
{
    public abstract class Upgrade : IHasUnlocalizedName
    {
        protected Upgrade(string unlocalizedName)
        {
            UnlocalizedName = unlocalizedName; 
        }


        public string UnlocalizedName { get; }
    }
}