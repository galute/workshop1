using System.Linq;
using Workshop.Values;
using NUnit.Framework;

namespace Tests.Values
{
    [TestFixture]
    public class TinyTypeTests
    {
        [Test]
        public void ShouldIdentifyATinyTypeFromStringValue()
        {
            Assert.That(CrossingType.From("pelican"), Is.EqualTo(CrossingType.Pelican));
            Assert.That(CrossingType.From("zebra"), Is.EqualTo(CrossingType.Zebra));
        }

        [Test]
        public void ShouldNotBeCaseSensitiveWhenParsingTinyType()
        {
            Assert.That(CrossingType.From("PelIcan"), Is.EqualTo(CrossingType.Pelican));
        }
        
        [Test]
        public void ShouldExposeTypeSpecificValuesThroughAnEnumerable()
        {
            Assert.That(CrossingType.Has(CrossingType.Pelican));
            Assert.That(CrossingType.Has(CrossingType.Zebra));
        }

        

        private class CrossingType : TinyType<CrossingType>
        {
            public static readonly CrossingType Pelican = new CrossingType("pelican");
            public static readonly CrossingType Zebra = new CrossingType("zebra");

            private CrossingType(string value) : base(value)
            {
            }

            public static bool Has(CrossingType crossingType)
            {
                return All.Any(crossingType.Equals);
            }
        }
    }
}