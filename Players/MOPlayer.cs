using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer : ModPlayer
    {
        private void ResetManaRegen()
        {
            player.manaRegen = 0;
            player.manaRegenDelay = 999;
        }


        public override void ResetEffects()
        {
            base.ResetEffects();

            ResetManaRegen();
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            ProcessTriggersBinds(triggersSet);
        }


        public bool Android { get; private set; }
    }
}