using System;

namespace Workshop.Extensions
{
    public static class IntExtensions
    {
        public static int WithinBounds(this int val, int boundaryOne, int boundaryTwo)
        {
            var high = boundaryOne > boundaryTwo ? boundaryOne : boundaryTwo;
            var low = boundaryOne < boundaryTwo ? boundaryOne : boundaryTwo;
            if (val > high) return high;
            if (val < low) return low;
            return val;
        }

        public static string ToCurrencyString(this int value)
        {
            return StringCurrency(value, "0#,##0");
        }

        public static string ToCurrencyStringLessThanTenThousand(this int value)
        {
            return StringCurrency(value, "#,#");
        }

        public static string StringCurrency(int value, string format)
        {
            var valueAsString = value.ToString(format);
            return String.Format("£{0}", valueAsString);
        }
    }
}
