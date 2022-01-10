using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Nez.Spatial
{
    class RaycastResultParser
    {
        public int HitCounter;

        static Comparison<RaycastHit> compareRaycastHits = (a, b) => { return a.Distance.CompareTo(b.Distance); };

        //int _cellSize;
        //Rectangle _hitTesterRect; see note in checkRayIntersection
        RaycastHit[] _hits;
        RaycastHit _tempHit;
        List<Collider> _checkedColliders = new List<Collider>();
        List<RaycastHit> _cellHits = new List<RaycastHit>();
        Ray2D _ray;
        int _layerMask;


        public void Start(ref Ray2D ray, RaycastHit[] hits, int layerMask)
        {
            _ray = ray;
            _hits = hits;
            _layerMask = layerMask;
            HitCounter = 0;
        }


        /// <summary>
        /// returns true if the hits array gets filled. cell must not be null!
        /// </summary>
        /// <returns><c>true</c>, if ray intersection was checked, <c>false</c> otherwise.</returns>
        /// <param name="ray">Ray.</param>
        /// <param name="cellX">Cell x.</param>
        /// <param name="cellY">Cell y.</param>
        /// <param name="cell">Cell.</param>
        /// <param name="hits">Hits.</param>
        /// <param name="hitCounter">Hit counter.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool CheckRayIntersection(int cellX, int cellY, List<Collider> cell)
        {
            float fraction;
            for (var i = 0; i < cell.Count; i++)
            {
                var potential = cell[i];

                // manage which colliders we already processed
                if (_checkedColliders.Contains(potential))
                    continue;

                _checkedColliders.Add(potential);

                // only hit triggers if we are set to do so
                if (potential.IsTrigger && !Physics.RaycastsHitTriggers)
                    continue;

                // make sure the Collider is on the layerMask
                if (!Flags.IsFlagSet(_layerMask, potential.PhysicsLayer))
                    continue;

                // TODO: is rayIntersects performant enough? profile it. Collisions.rectToLine might be faster
                // TODO: if the bounds check returned more data we wouldnt have to do any more for a BoxCollider check
                // first a bounds check before doing a shape test
                var colliderBounds = potential.Bounds;
                if (colliderBounds.RayIntersects(ref _ray, out fraction) && fraction <= 1.0f)
                {
                    if (potential.Shape.CollidesWithLine(_ray.Start, _ray.End, out _tempHit))
                    {
                        // check to see if the raycast started inside the collider if we should excluded those rays
                        if (!Physics.RaycastsStartInColliders && potential.Shape.ContainsPoint(_ray.Start))
                            continue;

                        // TODO: make sure the collision point is in the current cell and if it isnt store it off for later evaluation
                        // this would be for giant objects with odd shapes that bleed into adjacent cells
                        //_hitTesterRect.X = cellX * _cellSize;
                        //_hitTesterRect.Y = cellY * _cellSize;
                        //if( !_hitTesterRect.Contains( _tempHit.point ) )

                        _tempHit.Collider = potential;
                        _cellHits.Add(_tempHit);
                    }
                }
            }

            if (_cellHits.Count == 0)
                return false;

            // all done processing the cell. sort the results and pack the hits into the result array
            _cellHits.Sort(compareRaycastHits);
            for (var i = 0; i < _cellHits.Count; i++)
            {
                _hits[HitCounter] = _cellHits[i];

                // increment the hit counter and if it has reached the array size limit we are done
                HitCounter++;
                if (HitCounter == _hits.Length)
                    return true;
            }

            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset()
        {
            _hits = null;
            _checkedColliders.Clear();
            _cellHits.Clear();
        }
    }
}