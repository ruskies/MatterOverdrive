using MatterOverdrive.Android;
using WebmilioCommons.Managers;

namespace MatterOverdrive.Animations
{
    public class AnimationStage : IHasUnlocalizedName
    {
        public AnimationStage(string unlocalizedName, int runDuration)
        {
            UnlocalizedName = unlocalizedName;
            RunDuration = runDuration;
        }


        public virtual void Begin() { }

        public virtual void UpdateAnimationStage(StagedAndroidAnimation animation) { }


        public string UnlocalizedName { get; }

        public int RunDuration { get; }
        public int ElapsedTicks { get; internal set; }
    }
}