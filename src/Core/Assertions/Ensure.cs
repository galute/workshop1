using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Workshop.Extensions;

namespace Workshop.Assertions
{
    public static class Ensure
    {
        public static void NotNull(string argument, string argumentName)
        {
            if (String.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(string.Format("The argument [{0}] cannot be null or empty", argumentName));
            }
        }

        public static void NotNull(object argument, string argumentName)
        {
            if (argument.IsNull()) // <- This will work because it is an object extension - spooky!
            {
                throw new ArgumentNullException(string.Format("The argument [{0}] cannot be null or empty", argumentName));
            }
        }

        public static void AtLeastOne<T>(IEnumerable<T> enumeration, string message)
        {
            if (enumeration == null || !enumeration.Any())
            {
                throw new InvalidDataException(message);
            }
        }
    }
}