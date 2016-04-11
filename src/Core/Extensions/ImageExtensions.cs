using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Workshop.Extensions
{
    public static class ImageExtensions
    {
        public static byte[] ToByteArray(this Image image)
        {
            return image.ToByteArray(ImageFormat.Bmp);
        }
        
        public static byte[] ToByteArray(this Image image, ImageFormat imageFormat)
        {
            using (var stream = new MemoryStream())
            {
                image.Save(stream, imageFormat);
                return stream.ToArray();
            }
        }
    }
}