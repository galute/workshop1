using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.Time.Clock
{
    [RequiresThread(ApartmentState.STA)]
    public class two_sets_for_two_tasks
    {
        readonly DateTimeOffset expectedFirstThreadTime;
        readonly DateTimeOffset expectedSecondThreadTime;
        DateTimeOffset firstThreadTime;
        DateTimeOffset secondThreadTime;

        public two_sets_for_two_tasks()
        {
            expectedFirstThreadTime = new DateTimeOffset(2010, 1, 1, 0, 0, 0, TimeSpan.Zero);
            expectedSecondThreadTime = new DateTimeOffset(2001, 1, 1, 0, 0, 0, TimeSpan.Zero);


            var thread1 = new Task(() =>
            {
                Workshop.Time.Clock.UtcNow = () => expectedFirstThreadTime;
                firstThreadTime = Workshop.Time.Clock.UtcNow();
                Workshop.Time.Clock.Reset();
            });

            var thread2 = new Task(() =>
            {
                Workshop.Time.Clock.UtcNow = () => expectedSecondThreadTime;
                secondThreadTime = Workshop.Time.Clock.UtcNow();
                Workshop.Time.Clock.Reset();
            });
            thread2.Start();
            thread1.Start();
            Task.WaitAll(thread1, thread2);
        }

        [Test]
        public void time_flows()
        {
            Assert.AreEqual(expectedFirstThreadTime, firstThreadTime);
            Assert.AreEqual(expectedSecondThreadTime, secondThreadTime);
        }

        [Test]
        public void time_resets()
        {
            Assert.That(Workshop.Time.Clock.UtcNow(),
                        Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(10)));

            Assert.Null(CallContext.LogicalGetData("ctm.clock"));
        }
    }
}
