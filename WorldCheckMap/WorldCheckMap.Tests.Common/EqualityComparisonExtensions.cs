using System.Collections.Generic;
using KellermanSoftware.CompareNetObjects;

namespace WorldCheckMap.Tests.Common
{
    internal static class EqualityComparisonExtensions
    {
        private static readonly ICompareLogic Comparer = new CompareLogic(new ComparisonConfig
        {
            IgnoreCollectionOrder = true,
            IgnoreObjectTypes = true, // Need to compare different implementations of navigation ICollection property
            MembersToIgnore = new List<string> { "Id" }
        });

        internal static bool IsEqual<T>(this T obj1, T obj2)
        {
            return Comparer.Compare(obj1, obj2).AreEqual;
        }
    }
}