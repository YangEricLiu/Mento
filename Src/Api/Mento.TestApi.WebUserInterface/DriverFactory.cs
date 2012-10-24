using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver(string browserType)
        {
            switch (browserType)
            {
                case "IE":
                    return new InternetExplorerDriver();
                case "Chrome":
                    return new ChromeDriver();
                case "FireFox":
                    return new FirefoxDriver();
                default:
                    return null;
            }
        }
    }
}
