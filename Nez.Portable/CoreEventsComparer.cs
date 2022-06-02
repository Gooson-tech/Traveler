using System.Collections.Generic;

namespace Nez
{
    /// <summary>
    /// comparer that should be passed to a dictionary constructor to avoid boxing/unboxing when using an enum as a key
    /// on Mono
    /// </summary>
    public struct CoreEventsComparer : IEqualityComparer<CoreEvents>
    {
        public bool Equals(CoreEvents x, CoreEvents y)
        {
            return x == y;
        }


        public int GetHashCode(CoreEvents obj)
        {
            return (int) obj;
        }
    }
}