using System;

namespace Workshop.Extensions
{
    public static class DateTimeExtensions
    {
        public static Boolean Within(this DateTime now, DateTime then, TimeSpan withinSpan)
        {
            DateTime earliest;
            DateTime latest;

            if(now > then )
            {
                earliest = then;
                latest = now;
            }
            else
            {
                earliest = now;
                latest = then;
            }
            var duration = latest.Subtract(earliest);
            return duration < withinSpan;
        }
        
        public static DateTime WithoutSeconds(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);
        }
        
        public static double ToJavascriptUtcDate(this DateTime time)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return time.ToUniversalTime().Subtract(epoch).TotalMilliseconds;
        }

        public static DateTime InUtc(this DateTime dt)
        {
            return DateTime.SpecifyKind(dt, DateTimeKind.Utc);
        }

        public static DateTime InLocal(this DateTime dt)
        {
            return DateTime.SpecifyKind(dt, DateTimeKind.Local);
        }

        public static string WhenValid(this DateTime dt, Func<DateTime, string> format, Func<DateTime, string> alternate)
        {
            return dt.Equals(DateTime.MinValue) ? alternate(dt) : format(dt);
        }
    }
}