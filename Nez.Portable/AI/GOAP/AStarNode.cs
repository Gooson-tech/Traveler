using System;

namespace Nez.AI.GOAP
{
    public class AStarNode : IComparable<AStarNode>, IEquatable<AStarNode>, IPoolable
    {
        /// <summary>
        /// The state of the world at this node.
        /// </summary>
        public WorldState WorldState;

        /// <summary>
        /// The cost so far.
        /// </summary>
        public int CostSoFar;

        /// <summary>
        /// The heuristic for remaining cost (don't overestimate!)
        /// </summary>
        public int HeuristicCost;

        /// <summary>
        /// costSoFar + heuristicCost (g+h) combined.
        /// </summary>
        public int CostSoFarAndHeuristicCost;

        /// <summary>
        /// the Action associated with this node
        /// </summary>
        public Action Action;

        // Where did we come from?
        public AStarNode Parent;
        public WorldState ParentWorldState;
        public int Depth;


        #region IEquatable and IComparable

        public bool Equals(AStarNode other)
        {
            long care = WorldState.DontCare ^ -1L;
            return (WorldState.Values & care) == (other.WorldState.Values & care);
        }


        public int CompareTo(AStarNode other)
        {
            return CostSoFarAndHeuristicCost.CompareTo(other.CostSoFarAndHeuristicCost);
        }

        #endregion


        public void Reset()
        {
            Action = null;
            Parent = null;
        }


        public AStarNode Clone()
        {
            return (AStarNode) MemberwiseClone();
        }


        public override string ToString()
        {
            return string.Format("[cost: {0} | heuristic: {1}]: {2}", CostSoFar, HeuristicCost, Action);
        }
    }
}