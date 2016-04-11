using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Workshop.Extensions
{
    public static class StringExtensions
    {
        private const string FormatExceptionMessage = "Cannot parse {0} into bool.";
        public static string Remove(this string root, string toRemove)
        {
            return root.Replace(toRemove, String.Empty);
        }

        public static Uri AsUri(this string uri)
        {
            return String.IsNullOrEmpty(uri) ? null : new Uri(uri);
        }

        public static bool IsNullOrWhiteSpace(this string testString)
        {
            return String.IsNullOrWhiteSpace(testString);
        }

        public static bool IsNotNullOrWhiteSpace(this string testString)
        {
            return !String.IsNullOrWhiteSpace(testString);
        }

        public static string FormattedWith(this string template, params object[] parameters)
        {
            return String.Format(template, parameters);
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + Char.ToLower(m.Value[1]));
        }

        public static bool ToBool(this string obj)
        {
            try
            {
                return bool.Parse(obj);
            }
            catch (FormatException e)
            {
                throw new FormatException(string.Format(FormatExceptionMessage,obj),e);
            }
        }

        public static List<string> ToListSplitByComma(this string str)
        {
            if ( string.IsNullOrEmpty(str))
            {
                return new List<string>();
            }

            var pseudoResultList = new List<string>(str.Split(','));
            return pseudoResultList.Select(word => word.Trim()).ToList();
        }

        public static int ToIntStrippingOutCommas(this string value)
        {
            int temp;
            if (int.TryParse(value.Replace(",",""), out temp))
                return temp;

            return 0;
        }

        public static int ToInt(this string value)
        {
            int temp;
            if (int.TryParse(value, out temp))
                return temp;

            return 0;
        }

        public static double ToDoubleFromCurrency(this string value)
        {
            double temp;
            if (double.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentCulture, out temp))
                return temp;    

            return 0;
        }
    }
}