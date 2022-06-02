using System.Collections.Generic;

namespace Nez
{
    /// <summary>
    /// Comparer for sorting IRenderables. Sorts first by RenderLayer, then LayerDepth. If there is a tie Materials
    /// are used for the tie-breaker to avoid render state changes.
    /// </summary>
    public class RenderableComparer : IComparer<IRenderable>
    {
        public int Compare(IRenderable self, IRenderable other)
        {
            var res = other.RenderLayer.CompareTo(self.RenderLayer);
            if (res == 0)
            {
                res = other.LayerDepth.CompareTo(self.LayerDepth);
                if (res == 0)
                {
                    // both null or equal
                    if (ReferenceEquals(self.Material, other.Material))
                        return 0;

                    if (other.Material == null)
                        return -1;

                    return 1;
                }
            }

            return res;
        }
    }
}