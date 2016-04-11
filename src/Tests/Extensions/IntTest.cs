using Workshop.Extensions;
using NUnit.Framework;

namespace Tests.Extensions
{
    [TestFixture]
    public class IntTest
    {
        [Test]
        public void ShouldBoundaryCheck()
        {
            var val = 7;
            Assert.AreEqual(val.WithinBounds(5, 8), val);
            Assert.AreEqual(val.WithinBounds(8, 10), 8);
            Assert.AreEqual(val.WithinBounds(10, 8), 8);
            Assert.AreEqual(val.WithinBounds(3, 4), 4);
            Assert.AreEqual(val.WithinBounds(4, 3), 4);
        }
    }
}