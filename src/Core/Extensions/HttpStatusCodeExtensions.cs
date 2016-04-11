using System.Net;

namespace Workshop.Extensions
{
    public static class HttpStatusCodeExtensions
    {
         public static string StatusCode(this HttpStatusCode codeEnum)
         {
             return ((int) codeEnum).ToString();
         }
    }
}