using System.Collections.Generic;

namespace Nez
{
    /// <summary>
    /// Comparer for sorting IUpdatables
    /// </summary>
    public class IUpdatableComparer : IComparer<IUpdatable>
    {
        public int Compare(IUpdatable a, IUpdatable b)
        {
            return a.UpdateOrder.CompareTo(b.UpdateOrder);
        }
    }
}