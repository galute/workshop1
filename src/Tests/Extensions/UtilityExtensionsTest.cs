using System;
using Workshop.Extensions;
using NUnit.Framework;

namespace Tests.Extensions
{
    [TestFixture]
    public class UtilityExtensionsTest
    {
        private ClassToTestUtilityExtensions testClass;

        [SetUp]
        public void SetUp()
        {
            testClass = new ClassToTestUtilityExtensions();
        }

        [Test]
        public void ShouldPopulateAndReturnErrorsIfTheInvocationThrowsAnException()
        {
            var response = testClass.SafeExecute(testClass.ThrowAnException);

            Assert.That(response.Exception,Is.Not.Null);
        }

        [Test]
        public void ShouldPopulateAndReturnTheResultIfTheInvocationReturnsAValue()
        {
            var response = testClass.SafeExecute(testClass.ReturnTrue);

            Assert.That(response.Result,Is.True);
        }
    }

    internal class ClassToTestUtilityExtensions
    {
        public bool ThrowAnException()
        {
            throw new Exception();
        }

        public bool ReturnTrue()
        {
            return true;
        }
    }
}