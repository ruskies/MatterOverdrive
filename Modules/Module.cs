using MatterOverdrive.Players;
using Terraria;
using WebmilioCommons.Managers;

namespace MatterOverdrive.Modules
{
    public class Module : IHasUnlocalizedName
    {
        public Module(string unlocalizedName)
        {
            UnlocalizedName = unlocalizedName;
        }


        #region Hooks

        #region Player

        public virtual void ModifyPlayerWeaponDamage(MOPlayer moPlayer, int version, Item item, ref float add, ref float mult, ref float flat) { }

        public virtual void NaturalPlayerLifeRegen(MOPlayer moPlayer, int version, ref float regen) { }

        public virtual void OnPlayerHitNPC(MOPlayer moPlayer, Item item, NPC target, int damage, float knockback, bool crit) { }

        public virtual void ResetPlayerEffects(MOPlayer moPlayer, int version) { }

        #endregion

        #endregion


        public string UnlocalizedName { get; }
    }
}