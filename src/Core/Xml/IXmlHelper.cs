namespace Workshop.Xml
{
    public interface IXmlHelper
    {
        string SerializeUtf8<T>(T obj);
        string Serialize<T>(T obj);
        T DeSerialize<T>(string serializedObject);
    }
}