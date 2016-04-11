using System;
using Workshop.Extensions;
using NUnit.Framework;

namespace Tests.Extensions
{
    [TestFixture]
    public class DateTimeExtensionsTest
    {
        [Test]
        public void ShouldBeAbleToTellIfCurrentTimeWithinAMinuteOfTomorrow()
        {
            var now = DateTime.Now;
            var tomorrow = now.AddDays(1);
            var withinAMinute = now.Within(tomorrow, new TimeSpan(0, 0, 1, 0));
            Assert.That(withinAMinute, Is.EqualTo(false));
        }
        [Test]
        public void ShouldBeAbleToTellIfCurrentTimeWithinAMinuteOfYesterday()
        {
            var now = DateTime.Now;
            var tomorrow = now.AddDays(-1);
            var withinAMinute = now.Within(tomorrow, new TimeSpan(0, 0, 1, 0));
            Assert.That(withinAMinute, Is.EqualTo(false));
        }

        [Test]
        public void ShouldBeAbleToTellIfCurrentTimeWithinTwoDaysOfTomorrow()
        {
            var now = DateTime.Now;
            var tomorrow = now.AddDays(1);
            var withinAMinute = now.Within(tomorrow, new TimeSpan(2, 0, 0, 0));
            Assert.That(withinAMinute, Is.EqualTo(true));
        }
        [Test]
        public void ShouldBeAbleToTellIfCurrentTimeWithinTwoDaysOfYesterday()
        {
            var now = DateTime.Now;
            var tomorrow = now.AddDays(-1);
            var withinAMinute = now.Within(tomorrow, new TimeSpan(2, 0, 0, 0));
            Assert.That(withinAMinute, Is.EqualTo(true));
        }

    }
}
