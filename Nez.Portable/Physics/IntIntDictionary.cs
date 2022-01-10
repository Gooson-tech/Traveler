using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Nez.Spatial
{
    /// <summary>
    /// wraps a Unit32,List<Collider> Dictionary. It's main purpose is to hash the int,int x,y coordinates into a single
    /// Uint32 key which hashes perfectly resulting in an O(1) lookup.
    /// </summary>
    class IntIntDictionary
    {
        Dictionary<long, List<Collider>> _store = new Dictionary<long, List<Collider>>();


        /// <summary>
        /// computes and returns a hash key based on the x and y value. basically just packs the 2 ints into a long.
        /// </summary>
        /// <returns>The key.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        long GetKey(int x, int y)
        {
            return unchecked((long) x << 32 | (uint) y);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(int x, int y, List<Collider> list)
        {
            _store.Add(GetKey(x, y), list);
        }


        /// <summary>
        /// removes the collider from the Lists the Dictionary stores using a brute force approach
        /// </summary>
        /// <param name="obj">Object.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(Collider obj)
        {
            foreach (var list in _store.Values)
            {
                if (list.Contains(obj))
                    list.Remove(obj);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(int x, int y, out List<Collider> list)
        {
            return _store.TryGetValue(GetKey(x, y), out list);
        }


        /// <summary>
        /// gets all the Colliders currently in the dictionary
        /// </summary>
        /// <returns>The all objects.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HashSet<Collider> GetAllObjects()
        {
            var set = new HashSet<Collider>();

            foreach (var list in _store.Values)
                set.UnionWith(list);

            return set;
        }


        /// <summary>
        /// clears the backing dictionary
        /// </summary>
        public void Clear()
        {
            _store.Clear();
        }
    }
}