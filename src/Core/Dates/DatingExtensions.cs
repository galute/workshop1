using System;
using System.Globalization;

namespace Workshop.Dates
{   
    public static class DatingExtensions
    {
        public static DateTimeOffset January(this int day, int year)
        {
            return new DateTimeOffset(year,1,day,0,0,0,TimeSpan.Zero);
        }
        public static DateTimeOffset February(this int day, int year)
        {
            return new DateTimeOffset(year, 2, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset March(this int day, int year)
        {
            return new DateTimeOffset(year, 3, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset April(this int day, int year)
        {
            return new DateTimeOffset(year, 4, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset May(this int day, int year)
        {
            return new DateTimeOffset(year, 5, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset June(this int day, int year)
        {
            return new DateTimeOffset(year, 6, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset July(this int day, int year)
        {
            return new DateTimeOffset(year, 7, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset August(this int day, int year)
        {
            return new DateTimeOffset(year, 8, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset September(this int day, int year)
        {
            return new DateTimeOffset(year, 9, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset October(this int day, int year)
        {
            return new DateTimeOffset(year, 10, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset November(this int day, int year)
        {
            return new DateTimeOffset(year, 11, day, 0, 0, 0, TimeSpan.Zero);
        }
        public static DateTimeOffset December(this int day, int year)
        {
            return new DateTimeOffset(year, 12, day, 0, 0, 0, TimeSpan.Zero);
        }

        public static DateTimeOffset At(this DateTimeOffset dt, string timeOfDay)
        {
            return dt + TimeSpan.Parse(timeOfDay, CultureInfo.InvariantCulture);
        }
    }
}