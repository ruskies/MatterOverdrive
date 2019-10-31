using MatterOverdrive.Android;
using MatterOverdrive.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MatterOverdrive.Animations.AndroidTransformation
{
    public class AndroidTransformationBodyStage : AnimationStage
    {
        public AndroidTransformationBodyStage() : base(AndroidTransformationAnimation.ANIMATION_NAME + ".bodyStage", Constants.TICKS_PER_SECOND * 5)
        {
        }


        public override void UpdateAnimationStage(StagedAndroidAnimation animation)
        {
            animation.MOPlayer.player.immune = true;

            const int firstStageTicks = Constants.TICKS_PER_SECOND * 5;
            float timerPercentage = ElapsedTicks / (float)firstStageTicks;

            for (int i = 0; i < 5; i++)
                Dust.NewDust(animation.MOPlayer.player.position, 12, 12, DustID.Smoke, newColor: Color.White * timerPercentage, Scale: 2f);
        }
    }
}