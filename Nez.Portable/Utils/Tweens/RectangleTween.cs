using Microsoft.Xna.Framework;

namespace Nez.Tweens
{
    public class RectangleTween : Tween<Rectangle>
    {
        public static RectangleTween Create()
        {
            return TweenManager.CacheRectTweens ? Pool<RectangleTween>.Obtain() : new RectangleTween();
        }


        public RectangleTween()
        {
        }


        public RectangleTween(ITweenTarget<Rectangle> target, Rectangle to, float duration)
        {
            Initialize(target, to, duration);
        }


        public override ITween<Rectangle> SetIsRelative()
        {
            _isRelative = true;
            _toValue = new Rectangle
            (
                _toValue.X + _fromValue.X,
                _toValue.Y + _fromValue.Y,
                _toValue.Width + _fromValue.Width,
                _toValue.Height + _fromValue.Height
            );

            return this;
        }


        protected override void UpdateValue()
        {
            _target.SetTweenedValue(Lerps.Ease(_easeType, _fromValue, _toValue, _elapsedTime, _duration));
        }


        public override void RecycleSelf()
        {
            base.RecycleSelf();

            if (_shouldRecycleTween && TweenManager.CacheRectTweens)
                Pool<RectangleTween>.Free(this);
        }
    }
}