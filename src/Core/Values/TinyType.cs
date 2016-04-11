using System.Collections.Generic;
using System.Linq;

namespace Workshop.Values
{
    public abstract class TinyType<T> where T : TinyType<T>
    {
        private static readonly IDictionary<string, TinyType<T>> all = new Dictionary<string, TinyType<T>>();
        public string Value { get; private set; }

        protected TinyType(string value)
        {
            Value = value;
            all.Add(value.ToLowerInvariant(), this);
        }

        protected static IEnumerable<T> All
        {
            get { return all.Values.Select(v => (T)v); }
        }

        public override string ToString()
        {
            return string.Format("[{0}]:[{1}]", typeof(T), Value);
        }

        public static T From(string value)
        {
            try
            {
                return (T)all[value.ToLowerInvariant()];
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(string.Format("TinyType Mapping error :: {0} in {1} not found", value, typeof(T).Name), ex);
            }
        }
    }
}