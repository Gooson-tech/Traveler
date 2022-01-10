namespace Nez
{
    /// <summary>
    /// interface returned by startCoroutine which provides the ability to stop the coroutine mid-flight
    /// </summary>
    public interface ICoroutine
    {
        /// <summary>
        /// stops the Coroutine
        /// </summary>
        void Stop();

        /// <summary>
        /// sets whether the Coroutine should use deltaTime or unscaledDeltaTime for timing
        /// </summary>
        /// <returns>The use unscaled delta time.</returns>
        /// <param name="useUnscaledDeltaTime">If set to <c>true</c> use unscaled delta time.</param>
        ICoroutine SetUseUnscaledDeltaTime(bool useUnscaledDeltaTime);
    }
}