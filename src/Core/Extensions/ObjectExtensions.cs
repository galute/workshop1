namespace Workshop.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static string AssemblyName(this object obj)
        {
            return obj.GetType().Assembly.GetName().Name;
        }
    }
}