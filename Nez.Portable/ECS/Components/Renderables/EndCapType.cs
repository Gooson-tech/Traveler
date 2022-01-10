namespace Nez
{
    public enum EndCapType
    {
        /// <summary>
        /// will not attempt to add any extra verts at joints
        /// </summary>
        Standard,

        /// <summary>
        /// all joints will be extruded out with an extra vert resulting in jagged, pointy joints
        /// </summary>
        Jagged,

        /// <summary>
        /// the same as jagged but uses cutoffAngleForEndCapSubdivision to decide if a joint should be Jagged or Standard
        /// </summary>
        JaggedWithCutoff,

        /// <summary>
        /// joints are smoothed with some extra geometry. Uses degreesPerSubdivision to decide how smooth to make each joint.
        /// </summary>
        Smooth
    }
}