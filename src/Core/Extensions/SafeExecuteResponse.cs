using System;

namespace Workshop.Extensions
{
    public class SafeExecuteResponse<T>
    {
        public Exception Exception { get; set; }

        public T Result { get; set; }
    }
}