using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using NUnit.Framework;

namespace Tests.Time.Clock
{
    using Clock = Workshop.Time.Clock;
    public class one_set_for_two_threads
    {
        DateTimeOffset firstThreadTime;
        DateTimeOffset secondThreadTime;
        DateTimeOffset expectedThreadTime;

        public one_set_for_two_threads()
        {
            expectedThreadTime = new DateTimeOffset(2010,1,1,0,0,0,TimeSpan.Zero);

            var thread1 = new Thread(() => firstThreadTime = Clock.UtcNow());
            var thread2 = new Thread(() => secondThreadTime = Clock.UtcNow());
            Clock.UtcNow = () => expectedThreadTime;
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Clock.Reset();
        }
        [Test]
        public void time_flows()
        {
            Assert.AreEqual(expectedThreadTime, firstThreadTime);
            Assert.AreEqual(expectedThreadTime, secondThreadTime);
        }

        [Test]
        public void time_resets()
        {
            Assert.That(Clock.UtcNow(), Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(10)));

            Assert.Null(CallContext.LogicalGetData("ctm.clock"));
        }
    }
}