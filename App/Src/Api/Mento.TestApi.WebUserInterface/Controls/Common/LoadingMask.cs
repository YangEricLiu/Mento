﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface.Controls
{
    public class LoadingMask : JazzControl
    {
        #region Old Jazz       

        private static Locator LoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.LoadingMask);
        private static Locator SubMaskLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.SubMaskLoadingLocator);
        private static Locator ChartMaskerLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.ChartMaskerLoadingLocator);
        private static Locator DashboardHeaderLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.DashboardHeaderLoadingLocator);
        private static Locator WidgetsContainerLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.WidgetsContainerLoadingLocator);
        private static Locator CalendarLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.CalendarLoadingLocator);
        private static Locator JumpLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.JumpLoadingLocator);
        private static Locator PopNotesLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.PopNotesLocator);
        private static Locator MyShareLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.MyShareLocator);

        public LoadingMask()
            : base(LoadingLocator)
        {
        }

        public void WaitLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(LoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 10 : maxtime);

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

                ElementHandler.Wait(SubMaskLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 30 : maxtime);

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

                ElementHandler.Wait(ChartMaskerLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 30 : maxtime);
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

        public void WaitMyShareLoading(int maxtime = 0)
        {
            try
            {
                //ElementHandler.Wait(MyShareLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                //TimeManager.ShortPause();

                ElementHandler.Wait(MyShareLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 60 : maxtime);

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

        public void WaitCalendarPropertyLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(CalendarLoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();

                ElementHandler.Wait(CalendarLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 5 : maxtime);

                TimeManager.ShortPause();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        public void WaitJumpFavoriteLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(JumpLoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();

                ElementHandler.Wait(JumpLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 5 : maxtime);

                TimeManager.ShortPause();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        public void WaitPopNotesAppear(int maxtime = 0)
        {
            try
            {
                ElementHandler.Wait(PopNotesLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        #endregion

        #region New Jazz

        private static Locator NewJazzChartMaskerLoadingLocator = ControlLocatorRepository.GetLocator(ControlLocatorKey.NewReactJSjazzChartMaskerLoadingLocator);

        public void NewJazz_WaitChartMaskerLoading(int maxtime = 0)
        {
            try
            {
                ElementHandler.NewJazz_Wait(NewJazzChartMaskerLoadingLocator, WaitType.ToAppear, timeout: maxtime <= 0 ? 1 : maxtime);

                TimeManager.ShortPause();

                ElementHandler.NewJazz_Wait(NewJazzChartMaskerLoadingLocator, WaitType.ToDisappear, timeout: maxtime <= 0 ? 30 : maxtime);
                TimeManager.ShortPause();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }


        #endregion
    }
}
