namespace Nez
{
	public static class Coroutine
	{
		/// <summary>
		/// causes a Coroutine to pause for the specified duration. Yield on Coroutine.waitForSeconds in a coroutine to use.
		/// </summary>
		/// <returns>The for seconds.</returns>
		/// <param name="seconds">Seconds.</param>
		public static object WaitForSeconds(float seconds)
		{
			return Nez.WaitForSeconds.waiter.Wait(seconds);
		}
	}
}