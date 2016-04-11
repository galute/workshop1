using System;
using System.Collections.Generic;
using System.Linq;

namespace Workshop.Extensions
{
    public static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            enumeration.ToList().ForEach(action);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumeration)
        {
            return (enumeration == null) || (enumeration.Count()==0);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumeration)
        {
            return enumeration.Count() == 0;
        }

        public static bool IsNotEmpty<T>(this IEnumerable<T> enumeration)
        {
            return !enumeration.IsEmpty();
        }

        public static T Second<T>(this IEnumerable<T> enumeration)
        {
            return enumeration.ElementAt(1);
        }

        public static T Third<T>(this IEnumerable<T> enumeration)
        {
            return enumeration.ElementAt(2);
        }

        public static T FirstOrNull<T>(this IEnumerable<T> enumeration) where T : class
        {
            try
            {
                return enumeration.First();
            } catch (InvalidOperationException)
            {
                return null;
            }
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
        {
            var result = source.FirstOrDefault(predicate);
            return Equals(result, default(T)) ? defaultValue : result;
        }

        public static ISet<T> ToSet<T>(this IEnumerable<T> enumeration)
        {
            return new HashSet<T>(enumeration);
        }
    }
}