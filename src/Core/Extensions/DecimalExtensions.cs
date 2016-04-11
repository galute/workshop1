using System;

namespace Workshop.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal RoundTo(this decimal val, int numberOfPlaces)
        {
            return Math.Round(val, numberOfPlaces);
        }

        public static decimal WithinBounds(this decimal val, decimal boundaryOne, decimal boundaryTwo)
        {
            var high = boundaryOne > boundaryTwo ? boundaryOne : boundaryTwo;
            var low = boundaryOne < boundaryTwo ? boundaryOne : boundaryTwo;
            if (val > high) return high;
            if (val < low) return low;
            return val;
        }
    }
}