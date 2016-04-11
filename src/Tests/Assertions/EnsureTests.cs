using System;
using System.IO;
using System.Linq;
using Workshop.Assertions;
using NUnit.Framework;

namespace Tests.Assertions
{
    [TestFixture]
    public class EnsureTests
    {
        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfArgumentIsNull()
        {
            Ensure.NotNull(null, "MyArgument");
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionIfArgumentIsEmpty()
        {
            Ensure.NotNull(string.Empty, "MyArgument");
        }  
        
        [Test]
        public void ShouldNotThrowExceptionIfArgumentIsNotNullOrEmpty()
        {
            Ensure.NotNull("I am not null", "MyArgument");
        }

        [Test, ExpectedException(typeof(InvalidDataException))]
        public void ShouldThrowExceptionIfEnumerationIsNull()
        {
            Ensure.AtLeastOne<string>(null, "empty collection");
        }     
        
        [Test, ExpectedException(typeof(InvalidDataException))]
        public void ShouldThrowExceptionIfEnumerationIsEmpty()
        {
            Ensure.AtLeastOne(Enumerable.Empty<string>(), "empty collection");
        }
    
        [Test]
        public void ShouldNotThrowExceptionIfEnumerationIsNotEmpty()
        {
            Ensure.AtLeastOne(new[]{"wibble"}, "empty collection");
        }
    }
}