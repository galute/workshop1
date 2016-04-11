using System;
using System.Linq;
using System.Text;

namespace Workshop.ReflectionHelpers
{
    public static class ToStringBuilder
    {
        public static string ReflectivelyOverProperties(object objectToReflectOver)
        {
            if (objectToReflectOver == null)
            {
                return "null";
            }

            var objectType = objectToReflectOver.GetType();

            var propertyString = objectType.GetProperties().Select(
                property =>
                    {
                        var propertyName = property.Name;
                        var propertyValue = property.GetValue(objectToReflectOver, null);
                        var propertyValueAsString = propertyValue == null ? "null" : propertyValue.ToString();
                        var decoratedPropertyValueAsString = propertyValue is string
                                                                 ? String.Format("\"{0}\"", propertyValueAsString)
                                                                 : propertyValueAsString;
                        return String.Format(
                            "{0}=<{1}>",
                            propertyName,
                            decoratedPropertyValueAsString);
                    })
                .Aggregate(
                    (first, second) => String.Format("{0}, {1}", first, second));

            return new StringBuilder(objectType.FullName)
                .Append("[")
                .Append(propertyString)
                .Append("]")
                .ToString();
        }
    }
}