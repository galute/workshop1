using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Workshop.Time
{
    public static class Clock
    {
        static int setCount;

        public static Func<DateTimeOffset> UtcNow
        {
            get
            {
                return setCount <= 0
                           ? Default
                           : (Func<DateTimeOffset>)CallContext.LogicalGetData("ctm.clock") ?? Default;
            }
            set
            {
                if (ExecutionContext.IsFlowSuppressed())
                    throw new InvalidOperationException(
                        "ExecutionContext flowing has been disabled by a naughty component. Make sure you fix the component, or re-enable flowing of the execution context using 'ExectuionContext.RestoreFlow()' somewhere before the test (or after the faulty component was disposed.");
                CallContext.LogicalSetData("ctm.clock", value);
                Interlocked.Increment(ref setCount);
            }
        }

        public static void Reset()
        {
            var result = Interlocked.Decrement(ref setCount);
            if (result < 0)
                throw new InvalidOperationException("Clock has been reset once too many. Fix all the codez!"); 


            if (result >0)
                CallContext.LogicalSetData("ctm.clock", (Func<DateTimeOffset>)Default);
            else
                CallContext.FreeNamedDataSlot("ctm.clock");
        }

        static DateTimeOffset Default()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}
