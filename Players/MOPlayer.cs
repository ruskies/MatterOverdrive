using System.Collections.Generic;
using MatterOverdrive.Modules;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer : ModPlayer
    {
        


        public static MOPlayer Get() => Get(Main.LocalPlayer);
        public static MOPlayer Get(Player player) => player.GetModPlayer<MOPlayer>();


        private void ResetManaRegen()
        {
            player.manaRegen = 0;
            player.manaRegenDelay = 999;
        }


        #region Hooks

        public override void Initialize()
        {
            InitializeAnimations();
            InitializeModules();
        }

        public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
        {
            ModifyWeaponDamageModules(item, ref add, ref mult, ref flat);
        }

        public override void NaturalLifeRegen(ref float regen)
        {
            NaturalLifeRegenModules(ref regen);
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            OnHitNPCModules(item, target, damage, knockback, crit);
        }

        public override void PreUpdate()
        {
            PreUpdateMovementAnimations();
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            ProcessTriggersBinds(triggersSet);
        }

        public override void ResetEffects()
        {
            base.ResetEffects();

            ResetManaRegen();
            ResetEffectsModules();
        }

        #endregion


        public bool Android { get; private set; }
    }
}