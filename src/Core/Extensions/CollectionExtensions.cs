using System.Collections.Generic;

namespace Workshop.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddAll<T>(this ICollection<T> collection, IEnumerable<T> additionalElements)
        {
            foreach (var additionalElement in additionalElements)
            {
                collection.Add(additionalElement);
            }
        }
    }
}