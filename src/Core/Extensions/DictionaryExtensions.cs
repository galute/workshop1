using System.Collections.Generic;

namespace Workshop.Extensions
{
    public static class DictionaryExtensions
    {
        public static bool DoesNotContainEntryFor<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return !dictionary.ContainsKey(key);
        }
    }
}