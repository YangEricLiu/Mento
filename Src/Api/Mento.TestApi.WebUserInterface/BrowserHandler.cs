using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Exceptions;
using OpenQA.Selenium;
using System.Drawing.Imaging;

namespace Mento.TestApi.WebUserInterface
{
    public static class BrowserHandler
    {
        public static void Navigate(string url)
        {
            DriverFactory.Instance.Navigate().GoToUrl(url);
        }

        public static string GetPageTitle()
        {
            return DriverFactory.Instance.Title;
        }

        public static void Quit()
        {
            DriverFactory.Instance.Quit();
        }

        public static void TakeCapture(string fileName)
        {
            try
            {
                ITakesScreenshot ScreenShotter = (ITakesScreenshot)DriverFactory.Instance;

                Screenshot shot = ScreenShotter.GetScreenshot();
                shot.SaveAsFile(fileName, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw new ApiException(String.Format("Capture image failed, may caused by illegal image path :'{0}'", fileName), ex);
            }
        }

        public static object ExecuteJavaScript(string script, params object[] args)
        {
            try
            {
                IJavaScriptExecutor JavaScriptExecutor = (IJavaScriptExecutor)DriverFactory.Instance;

                return JavaScriptExecutor.ExecuteScript(script, args);
            }
            catch (Exception ex)
            {
                throw new ApiException(String.Format("Execution failed, please validate the provided javascript :'{0}'", script), ex);
            }
        }

        public static object ExecuteAsyncJavaScript(string script,params object[] args)
        {
            try
            {
                IJavaScriptExecutor JavaScriptExecutor = (IJavaScriptExecutor)DriverFactory.Instance;

                return JavaScriptExecutor.ExecuteAsyncScript(script, args);
            }
            catch (Exception ex)
            {
                throw new ApiException(String.Format("Execution failed, please validate the provided javascript :'{0}'", script), ex);
            }
        }

        public static void DeleteCookies()
        {
            DriverFactory.Instance.Manage().Cookies.DeleteAllCookies();
        }
    }
}
