using System;

namespace Workshop.Extensions
{
    public static class SafeStringExtensions
    {
        public static string EnsureSafe(this string possiblyUnsafeString)
        {
            return Uri.EscapeUriString(possiblyUnsafeString);
        }
    }
}