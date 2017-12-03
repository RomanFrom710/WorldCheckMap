using KellermanSoftware.CompareNetObjects;

namespace WorldCheckMap.Tests.Helpers.EqualityComparison
{
    internal static class EqualityComparisonExtensions
    {
        private static readonly ICompareLogic Comparer = new CompareLogic(new ComparisonConfig { IgnoreCollectionOrder = true });

        internal static bool IsEqual<T>(this T obj1, T obj2)
        {
            return Comparer.Compare(obj1, obj2).AreEqual;
        }
    }
}