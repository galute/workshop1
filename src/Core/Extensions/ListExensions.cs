using System.Collections.Generic;

namespace Workshop.Extensions
{
    public static class ListExensions
    {
        public static string ToCommaSeparatedString( this List<string> stringList )
        {
            var result = "";
            if (stringList != null)
            {
                var firstWord = true;
                foreach (var item in stringList)
                {
                    if (firstWord )
                    {
                        firstWord = false;
                        result += item;
                    }
                    else
                    {
                        result += "," + item ;    
                    }
                }
            }
            return result;
        }

    }
}