using System;

namespace Phoneword
{

    public class UtcTimestamper : IGetTimestamp
    {
        DateTime startTime;

        public UtcTimestamper()
        {
            startTime = DateTime.UtcNow;
        }

        public string GetFormattedTimestamp()
        {
            TimeSpan duration = DateTime.UtcNow.Subtract(startTime);
            return $"Service started at {startTime} ({duration:c} ago).";
        }

    }

}