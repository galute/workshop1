using System.IO;
using System.Text;

namespace Workshop.Xml
{
    public class Utf8Writer : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}