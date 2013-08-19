using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class LoadingMask : JazzControl
    {
        private static Locator LoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.LoadingMask);
        private static Locator SubMaskLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.SubMaskLoadingLocator);
        private static Locator ChartMaskerLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.ChartMaskerLoadingLocator);
        private static Locator DashboardHeaderLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.DashboardHeaderLoadingLocator);
        private static Locator WidgetsContainerLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.WidgetsContainerLoadingLocator);  

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

        public void WaitChartMaskerLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(ChartMaskerLoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();

                ElementHandler.Wait(ChartMaskerLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 5 : maxtime);

                TimeManager.ShortPause();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        public void WaitDashboardHeaderLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(DashboardHeaderLoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();

                ElementHandler.Wait(DashboardHeaderLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 5 : maxtime);

                TimeManager.ShortPause();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        public void WaitWidgetsLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(WidgetsContainerLoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();

                ElementHandler.Wait(WidgetsContainerLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 5 : maxtime);

                TimeManager.ShortPause();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}
