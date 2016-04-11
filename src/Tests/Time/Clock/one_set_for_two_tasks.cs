using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.Time.Clock
{
    public class one_set_for_two_tasks
    {
        DateTimeOffset firstThreadTime;
        DateTimeOffset secondThreadTime;
        DateTimeOffset expectedThreadTime;

        public one_set_for_two_tasks()
        {
            expectedThreadTime = new DateTimeOffset(2010,1,1,0,0,0,TimeSpan.Zero);

            Workshop.Time.Clock.UtcNow = () => expectedThreadTime;

            var thread1 =  new Task(() => firstThreadTime = Workshop.Time.Clock.UtcNow());
            var thread2 = new Task(() => secondThreadTime = Workshop.Time.Clock.UtcNow());
            thread1.Start();
            thread2.Start();
            Task.WaitAll(thread1, thread2);
            Workshop.Time.Clock.Reset();
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
            Assert.That(Workshop.Time.Clock.UtcNow(), Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(10)));

            Assert.Null(CallContext.LogicalGetData("ctm.clock"));
        }
    }
}