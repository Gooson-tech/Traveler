namespace Nez.Tweens
{
    public class FloatTween : Tween<float>
    {
        public static FloatTween Create()
        {
            return TweenManager.CacheFloatTweens ? Pool<FloatTween>.Obtain() : new FloatTween();
        }


        public FloatTween()
        {
        }


        public FloatTween(ITweenTarget<float> target, float to, float duration)
        {
            Initialize(target, to, duration);
        }


        public override ITween<float> SetIsRelative()
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

            if (_shouldRecycleTween && TweenManager.CacheFloatTweens)
                Pool<FloatTween>.Free(this);
        }
    }
}