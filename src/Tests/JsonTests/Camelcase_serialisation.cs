using CTM.Serialisation;
using NUnit.Framework;

namespace Tests.JsonTests
{
    class Camelcase_serialisation
    {
        [Test]
        public void Serialises_object_to_camelcase()
        {
            var objectToSerialise = new ObjectUnderTest
            {
                MyUsername = "rgparkins"
            };

            var serialisedObject = JsonNet.CamelCase.Serialise(objectToSerialise);

            Assert.That(serialisedObject, Is.EqualTo(@"{""myUsername"":""rgparkins""}"));
        }

        [Test]
        public void Deserialises_camelcase_string_to_object()
        {
            const string stringToDeserialise = @"{""myUsername"":""rgparkins""}";
            
            var deserialisedObject = JsonNet.CamelCase.Deserialise<ObjectUnderTest>(stringToDeserialise);

            Assert.That(deserialisedObject.MyUsername, Is.EqualTo("rgparkins"));
        }

        [Test]
        public void Ignores_missing_properties()
        {
            const string stringToDeserialise = @"{""UnkownProperty"":""1""}";

            var deserialisedObject = JsonNet.CamelCase.Deserialise<ObjectUnderTest>(stringToDeserialise);

            Assert.That(deserialisedObject.MyUsername, Is.Null);
        }
    }
}
