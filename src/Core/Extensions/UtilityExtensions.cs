using System;

namespace Workshop.Extensions
{
    public static class UtilityExtensions
    {
        public static SafeExecuteResponse<T> SafeExecute<T>(this object objectToInvokeOn, Func<T> function)
        {
            try
            {
                return new SafeExecuteResponse<T> { Result = function.Invoke() };
            }
            catch (Exception e)
            {
                return new SafeExecuteResponse<T> { Exception = e };
            }
        }
    }
}