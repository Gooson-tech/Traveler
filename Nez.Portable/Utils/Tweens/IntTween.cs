


// concrete implementations of all tweenable types
namespace Nez.Tweens
{
	public class IntTween : Tween<int>
	{
		public static IntTween Create()
		{
			return TweenManager.CacheIntTweens ? Pool<IntTween>.Obtain() : new IntTween();
		}


		public IntTween()
		{
		}


		public IntTween(ITweenTarget<int> target, int to, float duration)
		{
			Initialize(target, to, duration);
		}


		public override ITween<int> SetIsRelative()
		{
			_isRelative = true;
			_toValue += _fromValue;
			return this;
		}


		protected override void UpdateValue()
		{
			_target.SetTweenedValue((int) Lerps.Ease(_easeType, _fromValue, _toValue, _elapsedTime, _duration));
		}


		public override void RecycleSelf()
		{
			base.RecycleSelf();

			if (_shouldRecycleTween && TweenManager.CacheIntTweens)
				Pool<IntTween>.Free(this);
		}
	}
}