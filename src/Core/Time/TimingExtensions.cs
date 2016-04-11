using System;
using System.Timers;

namespace Workshop.Time
{
    public static class TimingExtensions
    {

        public static TimeSpan Millisecond(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }
        public static TimeSpan Milliseconds(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static TimeSpan Second(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }
        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }


        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }
        public static TimeSpan Minute(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }


        public static TimeSpan Hour(this int hours)
        {
            return TimeSpan.FromHours(hours);
        }
        public static TimeSpan Hours(this int hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Day(this int days)
        {
            return TimeSpan.FromDays(days);
        }
        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays(days);
        }

        public static Timer InvokeEvery(this Timer timer, TimeSpan interval, Action action)
        {
            timer.Interval = interval.TotalMilliseconds;
            timer.Elapsed += (sender, args) => action();

            return timer;
        }
    }
}