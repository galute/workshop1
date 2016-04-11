using Workshop.Xml;
using NUnit.Framework;

namespace Tests.XmlTests
{
    [TestFixture]
    public class XmlTests
    {
        private XmlHelper _xmlHelper;
        private DummyEntity _dummyEntity;
        private const string XmlToDeserialise = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                                                "<DummyEntity xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                                                "    <Name>Deserialised from string</Name>" +
                                                "</DummyEntity>";

        [SetUp]
        public void SetUp()
        {
            _xmlHelper = new XmlHelper();
            _dummyEntity = new DummyEntity { Name = "test" };
        }

        [Test]
        public void Should_SerializeUtf8Xml_When_GivenAnObjectToSerialize()
        {
            var serialisedString = _xmlHelper.SerializeUtf8(_dummyEntity);

            Assert.That(serialisedString, Contains.Substring("utf-8"));
        }

        [Test]
        public void Should_SerializeUtf16Xml_When_GivenAnObjectToSerialize()
        {
            var serialisedString = _xmlHelper.Serialize(_dummyEntity);

            Assert.That(serialisedString, Contains.Substring("utf-16"));
        }

        [Test]
        public void Should_DeserializeXmlString_When_ProvidedValidXml()
        {
            var entity = _xmlHelper.DeSerialize<DummyEntity>(XmlToDeserialise);

            Assert.That(entity.Name, Is.EqualTo("Deserialised from string"));
        }
    }
}