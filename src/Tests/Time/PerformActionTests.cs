using System.Timers;
using Workshop.Time;
using NUnit.Framework;

namespace Tests.Time
{
    [TestFixture]
    public class PerformActionTests
    {
        [Test]
        public void ShouldPerformAnActionPeriodically()
        {
            var count = 0;
            new Timer().InvokeEvery(100.Milliseconds(), () => count++).Start();
            Wait.For(200.Milliseconds()).ThenContinue();
            Assert.That(count > 0);
        }
    }
}