using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public static class TimeManager
    {
        public const int WAITELEMENTTIMEOUT = 30; //seconds

        private static int PauseFlash = 50; //mili seconds
        private static int PauseShort = 500; //mili seconds
        private static int PauseMedium = 1000; //mili seconds
        private static int PauseLong = 2000; //mili seconds

        /// <summary>
        /// Pause for 0.05 seconds
        /// </summary>
        public static void FlashPause()
        {
            Pause(PauseFlash);
        }

        /// <summary>
        /// Pause for 0.5 seconds
        /// </summary>
        public static void ShortPause()
        {
            Pause(PauseShort);
        }

        /// <summary>
        /// Pause for 1 second
        /// </summary>
        public static void MediumPause()
        {
            Pause(PauseMedium);
        }

        /// <summary>
        /// Pause for 2 seconds
        /// </summary>
        public static void LongPause()
        {
            Pause(PauseLong);
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
