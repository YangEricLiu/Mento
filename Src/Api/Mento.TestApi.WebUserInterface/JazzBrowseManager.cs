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
        /// Open Jazz with special browser and maximize the window
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
