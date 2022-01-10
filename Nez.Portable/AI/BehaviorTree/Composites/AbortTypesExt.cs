namespace Nez.AI.BehaviorTrees
{
    public static class AbortTypesExt
    {
        public static bool Has(this AbortTypes self, AbortTypes check)
        {
            return (self & check) == check;
        }
    }
}