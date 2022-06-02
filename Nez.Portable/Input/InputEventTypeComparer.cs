using System.Collections.Generic;

namespace Nez
{
    /// <summary>
    /// comparer that should be passed to a dictionary constructor to avoid boxing/unboxing when using an enum as a key
    /// on Mono
    /// </summary>
    public struct InputEventTypeComparer : IEqualityComparer<InputEventType>
    {
        public bool Equals(InputEventType x, InputEventType y)
        {
            return x == y;
        }


        public int GetHashCode(InputEventType obj)
        {
            return (int) obj;
        }
    }
}