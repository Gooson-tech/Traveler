namespace Nez
{
    /// <summary>
    /// helper class for when a coroutine wants to pause for some duration. Returning Coroutine.waitForSeconds returns one of these
    /// to avoid having to return an int/float and paying the boxing penalty.
    /// </summary>
    class WaitForSeconds
    {
        internal static WaitForSeconds waiter = new WaitForSeconds();
        internal float waitTime;

        internal WaitForSeconds Wait(float seconds)
        {
            waiter.waitTime = seconds;
            return waiter;
        }
    }
}