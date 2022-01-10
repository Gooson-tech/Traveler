using Microsoft.Xna.Framework;

namespace Nez.Tweens
{
    public class Vector4Tween : Tween<Vector4>
    {
        public static Vector4Tween Create()
        {
            return TweenManager.CacheVector4Tweens ? Pool<Vector4Tween>.Obtain() : new Vector4Tween();
        }


        public Vector4Tween()
        {
        }


        public Vector4Tween(ITweenTarget<Vector4> target, Vector4 to, float duration)
        {
            Initialize(target, to, duration);
        }


        public override ITween<Vector4> SetIsRelative()
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

            if (_shouldRecycleTween && TweenManager.CacheVector4Tweens)
                Pool<Vector4Tween>.Free(this);
        }
    }
}