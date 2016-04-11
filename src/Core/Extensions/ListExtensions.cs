using System.Collections.Generic;

namespace Workshop.Extensions
{
    public static class ListExtensions
    {
        public static bool HasItems<T>(this List<T> val)
        {
            return ((val != null) && val.Count != 0);
        }
    }
}