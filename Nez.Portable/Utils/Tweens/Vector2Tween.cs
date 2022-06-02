using Microsoft.Xna.Framework;

namespace Nez.Tweens
{
    public class Vector2Tween : Tween<Vector2>
    {
        public static Vector2Tween Create()
        {
            return TweenManager.CacheVector2Tweens ? Pool<Vector2Tween>.Obtain() : new Vector2Tween();
        }


        public Vector2Tween()
        {
        }


        public Vector2Tween(ITweenTarget<Vector2> target, Vector2 to, float duration)
        {
            Initialize(target, to, duration);
        }


        public override ITween<Vector2> SetIsRelative()
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

            if (_shouldRecycleTween && TweenManager.CacheVector2Tweens)
                Pool<Vector2Tween>.Free(this);
        }
    }
}