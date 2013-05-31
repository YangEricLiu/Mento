using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class LoadingMask : JazzControl
    {
        private static Locator LoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.LoadingMask);
        private static Locator SubMaskLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.LoadingMask);

        public LoadingMask()
            : base(LoadingLocator)
        {
        }

        public void WaitLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(LoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();

                ElementHandler.Wait(LoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 5 : maxtime);

                TimeManager.ShortPause();
            }
            catch(Exception ex)
            {
                //throw;
            }
        }

        public void WaitSubMaskLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(SubMaskLoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();

                ElementHandler.Wait(SubMaskLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 5 : maxtime);

                TimeManager.ShortPause();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}
