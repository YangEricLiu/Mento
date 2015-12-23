using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Execution;
using Mento.Framework;

namespace Mento.TestApi.WebUserInterface
{
    public static class JazzBrowseManager
    {
        /// <summary>
        /// Open Jazz with special browser and maximize the window,OK
        /// </summary>
        /// <returns></returns>
        public static void OpenJazz()
        {
            BrowserHandler.Navigate(ExecutionContext.Url);

            if (ExecutionContext.Browser == Browser.IE)
            {
                ClickHttpsSecurityWarning();
            }
        }

        /// <summary>
        /// Close the browser but NOT log out from Jazz
        /// </summary>
        /// <returns></returns>
        public static void CloseJazz()
        {
            BrowserHandler.Quit();
        }

        public static void RefreshJazz()
        {
            BrowserHandler.Refresh();
        }

        public static void SwitchToWidnow(string windowTitle)
        {
            BrowserHandler.switchToWindow(windowTitle);
        }

        //临时的
        public static void SwitchToEmptyWidnow()
        {
            BrowserHandler.switchToEmptyWindow();
        }

        public static void CloseTheWidnow(string windowTitle)
        {
            BrowserHandler.CloseTheWindow(windowTitle);
        }

        public static void CloseTheCurrentWidnow()
        {
            BrowserHandler.CloseTheCurrentWindow();
        }

        public static void SwitchToWindowByHandle(string windowHandle)
        {
            BrowserHandler.switchToWindowByHandle(windowHandle);
        }

        public static string GetMainWindowHandle()
        {
            return BrowserHandler.GetMainWindowHandle();
        }
        
        
        private static void ClickHttpsSecurityWarning()
        {
            string title = BrowserHandler.GetPageTitle();

            if (title.StartsWith("Certificate Error"))
            {
                BrowserHandler.Navigate("javascript:document.getElementById('overridelink').click()");
            }
        }
    }
}
