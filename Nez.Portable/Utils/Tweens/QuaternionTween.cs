using Microsoft.Xna.Framework;

namespace Nez.Tweens
{
    public class QuaternionTween : Tween<Quaternion>
    {
        public static QuaternionTween Create()
        {
            return TweenManager.CacheQuaternionTweens ? Pool<QuaternionTween>.Obtain() : new QuaternionTween();
        }


        public QuaternionTween()
        {
        }


        public QuaternionTween(ITweenTarget<Quaternion> target, Quaternion to, float duration)
        {
            Initialize(target, to, duration);
        }


        public override ITween<Quaternion> SetIsRelative()
        {
            _isRelative = true;
            _toValue *= _fromValue;
            return this;
        }


        protected override void UpdateValue()
        {
            _target.SetTweenedValue(Lerps.Ease(_easeType, _fromValue, _toValue, _elapsedTime, _duration));
        }


        public override void RecycleSelf()
        {
            base.RecycleSelf();

            if (_shouldRecycleTween && TweenManager.CacheQuaternionTweens)
                Pool<QuaternionTween>.Free(this);
        }
    }
}