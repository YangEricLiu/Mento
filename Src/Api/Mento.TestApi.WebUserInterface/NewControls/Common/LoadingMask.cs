using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.NewControls
{
    public class LoadingMask : JazzControl
    {
        private const string LOADINGMASKID = "mainLoadingMask";
        private static Locator LoadingLocator = new Locator(LOADINGMASKID, ByType.ID);

        public LoadingMask()
            : base(LoadingLocator)
        {
        }

        public static void WaitLoading()
        {
            try
            {
                ElementHandler.Wait(LoadingLocator, WaitType.ToAppear, timeOut: 1);

                TimeManager.PauseShort();

                ElementHandler.Wait(LoadingLocator, WaitType.ToDisappear, timeOut: 5);

                TimeManager.PauseShort();
            }
            catch
            { 
            }
        }
    }
}
