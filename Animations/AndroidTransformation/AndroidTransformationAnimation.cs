using MatterOverdrive.Android;
using MatterOverdrive.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MatterOverdrive.Animations.AndroidTransformation
{
    public class AndroidTransformationAnimation : StagedAndroidAnimation
    {
        public const string ANIMATION_NAME = "android.transformInto";


        public AndroidTransformationAnimation(MOPlayer moPlayer) : base(moPlayer, ANIMATION_NAME)
        {
            stages.Add(new AndroidTransformationBodyStage());
        }


        public override void Begin()
        {
            if (Main.LocalPlayer == MOPlayer.player)
                Main.blockInput = true;
        }

        public override void End()
        {
            if (Main.LocalPlayer == MOPlayer.player)
                Main.blockInput = false;

            MOPlayer.player.immune = false;
        }
    }
}