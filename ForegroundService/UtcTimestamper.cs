﻿using System;

namespace Phoneword.ForegroundService
{
    public class UtcTimestamper
    {
        DateTime startTime;
        bool wasReset = false;

        public UtcTimestamper()
        {
            startTime = DateTime.UtcNow;
        }

        public string GetFormattedTimestamp()
        {
            TimeSpan duration = DateTime.UtcNow.Subtract(startTime);
            return wasReset ? $"Service restarted at {startTime} ({duration:c} ago)." : $"Service started at {startTime} ({duration:c}).";
        }

        public void Restart()
        {
            startTime = DateTime.UtcNow;
            wasReset = true;
        }
    }
}