using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.NewControls
{
    public static class TimeManager
    {
        public const int WAITELEMENTTIMEOUT = 30; //seconds

        private const int PAUSESHORT = 500; //mili seconds
        private const int PAUSEMEDIUM = 1000; //mili seconds
        private const int PAUSELONG = 2000; //mili seconds

        public static void PauseShort()
        {
            Pause(PAUSESHORT);
        }

        public static void PauseMedium()
        {
            Pause(PAUSEMEDIUM);
        }

        public static void PauseLong()
        {
            Pause(PAUSELONG);
        }

        public static void Pause(int milliseconds)
        {
            System.Threading.Thread.Sleep(milliseconds);
        }
    }
}
