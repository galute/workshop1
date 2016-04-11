using System.ComponentModel;

namespace Workshop.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this System.Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }
    }
}