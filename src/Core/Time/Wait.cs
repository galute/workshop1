using System;
using System.Threading;

namespace Workshop.Time
{
    public class Wait
    {
        private readonly TimeSpan timeout;
        private readonly TimeSpan interval;
        private const int DefaultInterval = 100;

        private Wait(TimeSpan timeout, TimeSpan? interval = null)
        {
            this.interval = interval ?? TimeSpan.FromMilliseconds(DefaultInterval);
            this.timeout = timeout;
        }

        public static Wait For(TimeSpan timing)
        {
            return new Wait(timing);    
        }

        public void Until(Func<bool> condition)
        {
            Until(condition,
                  () =>
                      {
                          throw new TimeoutException(string.Format("Expected {0} after waiting for {1} milliseconds",
                                                                   condition, timeout));
                      });
        }

        public void Until(Func<bool> condition, Action success, Action failure)
        {
            var timeIsUp = DateTime.Now.Add(timeout);
            while (DateTime.Now.CompareTo(timeIsUp) < 0)
            {
                if (condition())
                {
                    success();
                    return;
                }
                new ManualResetEvent(false).WaitOne(interval);
            }
            failure();
        }

        public void Until(Func<bool> condition, Action failure)
        {
            Until(condition, () => {}, failure);
        }

        public void ThenContinue()
        {
            new ManualResetEvent(false).WaitOne(timeout);
        }
    }
}