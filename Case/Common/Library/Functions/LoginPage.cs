using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;
using OpenQA.Selenium;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of Login.
    /// </summary>
    public class LoginPage
    {
        internal LoginPage()
        {
        }

        //private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();
        private static Locator HomePageNavigationLocator = JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.ButtonNavigatorHomePage);

        /// <summary>
        /// Login Jazz with test data
        /// </summary>
        /// <param name="loginData">login test data</param>
        /// <returns></returns>
        public void Login(LoginInputData loginData)
        {
            JazzTextField.LoginUserNameTextField.Fill(loginData.UserName);
            JazzTextField.LoginPasswordTextField.Fill(loginData.Password);

            JazzButton.LoginSubmitButton.Click();
            //ElementLocator.Driver.FindElement(By.Id("txtPassword")).SendKeys("\n");

            TimeManager.LongPause();

            //Amy update starts: add customer selection for R1.0. so if running case in R1.0, these need to be uncomment.
            //comboBoxInstance.DisplayItems(ElementKey.CustomerSelection);
            //comboBoxInstance.SelectItem("Schneider");  //or "REMPlatform"
            //ElementLocator.FindElement(ElementDictionary[ElementKey.CustomerConfirmButton]).Click();
            //Amy update ends

            ElementHandler.Wait(HomePageNavigationLocator, WaitType.ToAppear, timeout: 150);

            //Amy comment: if running case in R1.0, below clause "ElementLocator.WaitForElementToDisappear.." needs to be commented out.
            //ElementLocator.WaitForElementToDisappear(new Locator("mainLoadingMask", ByType.ID), 30);
        }

        /// <summary>
        /// Login Jazz with Customer
        /// </summary>
        /// <returns></returns>
        public void LoginToCustomer()
        {
            //TextField UserNameField = ControlAccess.GetControl<TextField>();
            //TextField PasswordField = ControlAccess.GetControl<TextField>();

            //UserNameField.FillIn(ElementKey.LoginName, "demo");
            //PasswordField.FillIn(ElementKey.LoginPassword, "password");

            //var ButtonSubmit = ElementLocator.FindElement(ElementDictionary[ElementKey.LoginSubmit]);

            //ButtonSubmit.Submit();

            //2012-11-05
            //test in cn proxy schneider intranet
            //load time: 27s, render time: 7s, total: 34s
            //test in fr proxy schneider intranet
            //load time: 66s, render time: 26s, total: 92s
            //load time: 72s, render time: 45s, total: 117s

            //Pause 2.5 minutes to let ext render Jazz layout

            //ElementLocator.Pause(150000);
            if (IsAlreadyLogin())
                return;

            string defaultUserName = "AutoCustomer";
            string defaultPassword = "123456qq";

            var loginData = new LoginInputData() { UserName = defaultUserName, Password = defaultPassword };

            this.Login(loginData);
        }

        /// <summary>
        /// Login Jazz with Admin
        /// </summary>
        /// <returns></returns>
        public void LoginToAdmin()
        {
            //TextField UserNameField = ControlAccess.GetControl<TextField>();
            //TextField PasswordField = ControlAccess.GetControl<TextField>();

            //UserNameField.FillIn(ElementKey.LoginName, "demo");
            //PasswordField.FillIn(ElementKey.LoginPassword, "password");

            //var ButtonSubmit = ElementLocator.FindElement(ElementDictionary[ElementKey.LoginSubmit]);

            //ButtonSubmit.Submit();

            //2012-11-05
            //test in cn proxy schneider intranet
            //load time: 27s, render time: 7s, total: 34s
            //test in fr proxy schneider intranet
            //load time: 66s, render time: 26s, total: 92s
            //load time: 72s, render time: 45s, total: 117s

            //Pause 2.5 minutes to let ext render Jazz layout

            //ElementLocator.Pause(150000);
            if (IsAlreadyLogin())
                return;

            string defaultUserName = "Admin";
            string defaultPassword = "123456qq";

            var loginData = new LoginInputData() { UserName = defaultUserName, Password = defaultPassword };

            JazzTextField.LoginUserNameTextField.Fill(loginData.UserName);
            JazzTextField.LoginPasswordTextField.Fill(loginData.Password);


            string selectUserInputButtonXpath = "//div[contains(@class, 'x-window-body')]//input";
            JazzButton.LoginSubmitButton.Click();
            ElementHandler.Wait(new Locator(selectUserInputButtonXpath, ByType.XPath), WaitType.ToAppear, timeout: 150);
            TimeManager.ShortPause();

            //Click user selection button
            ElementHandler.FindElement(new Locator(selectUserInputButtonXpath, ByType.XPath)).Click();
            TimeManager.ShortPause();

            //Select Admin
            string remAdminXpath = "//div[contains(@class, 'x-boundlist-floating')]//ul/li[1]";
            ElementHandler.FindElement(new Locator(remAdminXpath, ByType.XPath)).Click();
            TimeManager.ShortPause();

            //Confirm
            string confirmButtonXpath = "//div[contains(@id, 'toolbar')]//em/button";
            ElementHandler.FindElement(new Locator(confirmButtonXpath, ByType.XPath)).Click();
            TimeManager.LongPause();
        }

        public bool IsAlreadyLogin()
        {
            return ElementHandler.Exists(HomePageNavigationLocator);
        }
    }
}
