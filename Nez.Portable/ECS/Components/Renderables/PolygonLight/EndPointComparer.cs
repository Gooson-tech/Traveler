using System.Collections.Generic;

namespace Nez.Shadows
{
    internal class EndPointComparer : IComparer<EndPoint>
    {
        internal EndPointComparer()
        {
        }


        // Helper: comparison function for sorting points by angle
        public int Compare(EndPoint a, EndPoint b)
        {
            // Traverse in angle order
            if (a.angle > b.angle)
                return 1;

            if (a.angle < b.angle)
                return -1;

            // But for ties we want Begin nodes before End nodes
            if (!a.begin && b.begin)
                return 1;

            if (a.begin && !b.begin)
                return -1;

            return 0;
        }
    }
}