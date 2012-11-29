using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public static class TimeManager
    {
        public const int WAITELEMENTTIMEOUT = 30; //seconds

        private const int PAUSESHORT = 500; //mili seconds
        private const int PAUSEMEDIUM = 1000; //mili seconds
        private const int PAUSELONG = 2000; //mili seconds

        /// <summary>
        /// Pause for 0.5 seconds
        /// </summary>
        public static void PauseShort()
        {
            Pause(PAUSESHORT);
        }

        /// <summary>
        /// Pause for 1 second
        /// </summary>
        public static void PauseMedium()
        {
            Pause(PAUSEMEDIUM);
        }

        /// <summary>
        /// Pause for 2 seconds
        /// </summary>
        public static void PauseLong()
        {
            Pause(PAUSELONG);
        }

        /// <summary>
        /// Pause for a specified time
        /// </summary>
        /// <param name="milliseconds"></param>
        public static void Pause(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}
