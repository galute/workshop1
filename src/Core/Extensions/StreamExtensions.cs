using System.IO;

namespace Workshop.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            var memoryStream = new MemoryStream();
            var buffer = new byte[0x1000];
            int bytes;
            while ((bytes = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                memoryStream.Write(buffer, 0, bytes);
            }
            return memoryStream.ToArray();
        }
    }
}