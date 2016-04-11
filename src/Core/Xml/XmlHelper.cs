using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Workshop.Xml
{

    public class XmlHelper : IXmlHelper
    {
        private static IXmlHelper _xmlHelper = new XmlHelper();

        public static IXmlHelper Instance
        {
            get { return _xmlHelper; }
            set { _xmlHelper = value; }
        }

        public string SerializeUtf8<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new Utf8Writer())
            {
                var settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = false,
                    OmitXmlDeclaration = false
                };

                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(writer, obj);
                }
                var str = stringWriter.ToString();
                return str;
            }
        }

        public string Serialize<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings
                {
                    Encoding = new UnicodeEncoding(false, false),
                    Indent = false,
                    OmitXmlDeclaration = false
                };

                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    serializer.Serialize(writer, obj);
                }
                var str = stringWriter.ToString();
                return str;
            }
        }

        public T DeSerialize<T>(string serializedObject)
        {
            var serializer = new XmlSerializer(typeof(T));

            using (var rdr = new StringReader(serializedObject))
            {
                var deserializedObject = (T)serializer.Deserialize(rdr);

                return deserializedObject;
            }
        }
    }
}
