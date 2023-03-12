using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudeRunnerCH.Logic
{
    public class Time
    {
        private static readonly long TimeStarted = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        private static long TimeElapsed = 0;

        public int Ticks { get; set; } = 0;

        public bool TimeElapsed1()
        {
            var currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            TimeElapsed = currentTime - TimeStarted;
            return TimeElapsed >= Ticks * 1000;
        }

        public void SetTimer(int seconds)
        {
            Ticks = seconds;
            TimeElapsed = 0;
        }
        public Time NewTimer() 
        {
            return new Time();
        }
    }
}
