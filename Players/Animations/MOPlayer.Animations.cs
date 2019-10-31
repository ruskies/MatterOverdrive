using System.Collections.Generic;
using MatterOverdrive.Animations;
using MatterOverdrive.Animations.AndroidTransformation;

namespace MatterOverdrive.Players
{
    public sealed partial class MOPlayer
    {
        private List<AndroidAnimation> _currentAndroidAnimations;


        public bool BecomeAndroid() => BeginAnimation(new AndroidTransformationAnimation(this));


        public bool BeginAnimation(AndroidAnimation androidAnimation)
        {
            if (_currentAndroidAnimations.Find(a => a.UnlocalizedName == androidAnimation.UnlocalizedName && a.Unique) != null)
                return false;

            _currentAndroidAnimations.Add(androidAnimation);
            androidAnimation.Begin();

            return true;
        }

        public bool EndAnimation(AndroidAnimation androidAnimation)
        {
            if (!_currentAndroidAnimations.Contains(androidAnimation))
                return false;

            androidAnimation.End();
            return true;
        }


        #region Hooks

        private void InitializeAnimations()
        {
            _currentAndroidAnimations = new List<AndroidAnimation>();
        }

        private void PreUpdateMovementAnimations()
        {
            for (int i = 0; i < _currentAndroidAnimations.Count; i++)
                _currentAndroidAnimations[i].PlayerPreUpdateMovement();
        }

        #endregion

    }
}
