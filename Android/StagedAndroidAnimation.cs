using System.Collections.Generic;
using MatterOverdrive.Animations;
using MatterOverdrive.Players;

namespace MatterOverdrive.Android
{
    public abstract class StagedAndroidAnimation : AndroidAnimation
    {
        protected readonly List<AnimationStage> stages = new List<AnimationStage>();


        protected StagedAndroidAnimation(MOPlayer moPlayer, string name, int tickRate = 1, bool unique = false) : base(moPlayer, name, tickRate, unique)
        {
        }


        protected override void UpdateAnimation()
        {
            if (CurrentStage == null)
            {
                CurrentStage = this[0];
                CurrentStage.Begin();
            }

            CurrentStage.UpdateAnimationStage(this);

            if (CurrentStage.ElapsedTicks >= CurrentStage.RunDuration)
            {
                int currentStageIndex = stages.IndexOf(CurrentStage);

                if (currentStageIndex >= stages.Count - 1)
                    MOPlayer.EndAnimation(this);
                else
                {
                    CurrentStage = this[currentStageIndex + 1];
                    CurrentStage.Begin();
                }
            }

            CurrentStage.ElapsedTicks++;
        }


        public AnimationStage CurrentStage { get; private set; }

        public AnimationStage this[int index] => stages[index];
        public AnimationStage this[string name] => stages.Find(a => a.UnlocalizedName == name);
    }
}