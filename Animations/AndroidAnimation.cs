using MatterOverdrive.Players;
using WebmilioCommons.Managers;

namespace MatterOverdrive.Animations
{
    public abstract class AndroidAnimation : IHasUnlocalizedName
    {
        protected AndroidAnimation(MOPlayer moPlayer, string unlocalizedName, int tickRate = 1, bool unique = false)
        {
            MOPlayer = moPlayer;

            UnlocalizedName = unlocalizedName;
            TickRate = tickRate;
            Unique = unique;
        }


        public virtual void Begin() { }
        public virtual void End() { }


        public virtual void PlayerPreUpdateMovement()
        {
            UpdateAnimation();

            ElapsedFrames++;
        }

        protected abstract void UpdateAnimation();


        public MOPlayer MOPlayer { get; }

        public string UnlocalizedName { get; }
        public int TickRate { get; }
        public bool Unique { get; }

        public int ElapsedFrames { get; private set; }
        public int ElapsedTicks { get; private set; }
    }
}