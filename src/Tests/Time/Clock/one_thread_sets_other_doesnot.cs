using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.Time.Clock
{
    public class one_thread_sets_other_doesnot
    {
        DateTimeOffset firstThreadTime;
        DateTimeOffset secondThreadTime;
        DateTimeOffset expectedFirstThreadTime;

        public one_thread_sets_other_doesnot()
        {
            expectedFirstThreadTime = new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero);

            var thread1 = new Task(() =>
            {
                Workshop.Time.Clock.UtcNow = () => expectedFirstThreadTime;
                firstThreadTime = Workshop.Time.Clock.UtcNow();
                Workshop.Time.Clock.Reset();
            });

            var thread2 = new Task(() => secondThreadTime = Workshop.Time.Clock.UtcNow());
            thread1.Start();
            thread2.Start();
            Task.WaitAll(thread1, thread2);
        }
        [Test]
        public void time_flows()
        {
            Assert.AreEqual(expectedFirstThreadTime, firstThreadTime);
            Assert.That(DateTimeOffset.UtcNow-secondThreadTime, Is.LessThan(TimeSpan.FromSeconds(10)));
        }

        [Test]
        public void time_resets()
        {
            Assert.That(Workshop.Time.Clock.UtcNow(), Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(10)));
            Assert.Null(CallContext.LogicalGetData("ctm.clock"));
        }
    }
}