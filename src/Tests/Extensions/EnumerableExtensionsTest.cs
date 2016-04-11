using System;
using System.Collections.Generic;
using Workshop.Extensions;
using NUnit.Framework;

namespace Tests.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        public void ShouldReturnTrueIfIEnumerableIsNullOrEmpty()
        {
            Assert.That(new List<string>().IsNullOrEmpty(),Is.True);

            List<string> nullCollection = null;
            Assert.That(nullCollection.IsNullOrEmpty(), Is.True);
        }

        [Test]
        public void ShouldReturnFalseIfIEnumerableIsNotEmpty()
        {
            Assert.That(new List<string> {"one", "two"}.IsNullOrEmpty(), Is.False);
        }

        [Test]
        public void ShouldReturnTheFirstMatch()
        {
            IEnumerable<String> sources = new[] { "", "match" };
            
            Assert.That(sources.FirstOrDefault(s => s.IsNotNullOrWhiteSpace(), "default"), Is.EqualTo("match"));
        }

        [Test]
        public void ShouldReturnOrIfThereIsNoMatch()
        {
            const string defaultValue = "default";
            
            IEnumerable<String> sources = new[] { null, "  ", "" };
            
            Assert.That(sources.FirstOrDefault(s => s.IsNotNullOrWhiteSpace(), defaultValue), Is.EqualTo(defaultValue));
        }
    }
}