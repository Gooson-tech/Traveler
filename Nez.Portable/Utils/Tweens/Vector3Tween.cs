using Microsoft.Xna.Framework;

namespace Nez.Tweens
{
    public class Vector3Tween : Tween<Vector3>
    {
        public static Vector3Tween Create()
        {
            return TweenManager.CacheVector3Tweens ? Pool<Vector3Tween>.Obtain() : new Vector3Tween();
        }


        public Vector3Tween()
        {
        }


        public Vector3Tween(ITweenTarget<Vector3> target, Vector3 to, float duration)
        {
            Initialize(target, to, duration);
        }


        public override ITween<Vector3> SetIsRelative()
        {
            _isRelative = true;
            _toValue += _fromValue;
            return this;
        }


        protected override void UpdateValue()
        {
            _target.SetTweenedValue(Lerps.Ease(_easeType, _fromValue, _toValue, _elapsedTime, _duration));
        }


        public override void RecycleSelf()
        {
            base.RecycleSelf();

            if (_shouldRecycleTween && TweenManager.CacheVector3Tweens)
                Pool<Vector3Tween>.Free(this);
        }
    }
}