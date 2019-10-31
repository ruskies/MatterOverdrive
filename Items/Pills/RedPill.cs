using MatterOverdrive.Players;
using Terraria;
using Terraria.ID;

namespace MatterOverdrive.Items.Pills
{
    public class RedPill : MOItem
    {
        public RedPill() : base("Red Pill", "Makes you woke", 32, 32, rarity: ItemRarityID.Red)
        {
        }


        public override void SetDefaults()
        {
            item.consumable = true;
            item.maxStack = 99;

            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTime = 15;
            item.useAnimation = item.useTime;

            base.SetDefaults();
        }


        public override bool UseItem(Player player) =>
            MOPlayer.Get(player).BecomeAndroid();
    }
}