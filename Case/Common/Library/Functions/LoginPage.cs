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

            TimeManager.PauseLong();

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
        /// Login Jazz with default data
        /// </summary>
        /// <returns></returns>
        public void Login()
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

            string defaultUserName = "demo";
            string defaultPassword = "password";

            var loginData = new LoginInputData() { UserName = defaultUserName, Password = defaultPassword };

            this.Login(loginData);
        }

        public bool IsAlreadyLogin()
        {
            return ElementHandler.Exists(HomePageNavigationLocator);
        }
    }
}
