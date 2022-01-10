using Microsoft.Xna.Framework;

namespace Nez.Tweens
{
    public class ColorTween : Tween<Color>
    {
        public static ColorTween Create()
        {
            return TweenManager.CacheColorTweens ? Pool<ColorTween>.Obtain() : new ColorTween();
        }


        public ColorTween()
        {
        }


        public ColorTween(ITweenTarget<Color> target, Color to, float duration)
        {
            Initialize(target, to, duration);
        }


        public override ITween<Color> SetIsRelative()
        {
            _isRelative = true;
            _toValue.R += _fromValue.R;
            _toValue.G += _fromValue.G;
            _toValue.B += _fromValue.B;
            _toValue.A += _fromValue.A;
            return this;
        }


        protected override void UpdateValue()
        {
            _target.SetTweenedValue(Lerps.Ease(_easeType, _fromValue, _toValue, _elapsedTime, _duration));
        }


        public override void RecycleSelf()
        {
            base.RecycleSelf();

            if (_shouldRecycleTween && TweenManager.CacheColorTweens)
                Pool<ColorTween>.Free(this);
        }
    }
}