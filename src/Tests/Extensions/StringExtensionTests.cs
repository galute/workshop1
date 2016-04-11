using Workshop.Extensions;
using NUnit.Framework;

namespace Tests.Extensions
{
    [TestFixture, SetCulture("en-gb")]
    public class StringExtensionTest
    {
        [TestCase("£1.23", 1.23)]
        [TestCase("£002.34", 2.34)]
        [TestCase("£345.67", 345.67)]
        [TestCase("£999", 999.0)]
        public void ShouldConvertCurrencyStringsToDoubles(string testValue, double result)
        {
            Assert.That(testValue.ToDoubleFromCurrency(), Is.EqualTo(result));
        }
    }
}

