using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;
using OpenQA.Selenium;

namespace Mento.ScriptCommon.Library.Functions
{
    /// <summary>
    /// The business logic implement of Login.
    /// </summary>
    public class LoginFunction
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();
        private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();

        /// <summary>
        /// Login Jazz with test data
        /// </summary>
        /// <param name="loginData">login test data</param>
        /// <returns></returns>
        public void Login(LoginInputData loginData)
        {
            TextField UserNameField = ControlAccess.GetControl<TextField>();
            TextField PasswordField = ControlAccess.GetControl<TextField>();

            UserNameField.FillIn(ElementKey.LoginName, loginData.UserName);
            PasswordField.FillIn(ElementKey.LoginPassword, loginData.Password);

            //ElementLocator.


            var ButtonSubmit = ElementLocator.FindElement(ElementDictionary[ElementKey.LoginSubmit]);

            ButtonSubmit.Submit();
            //ElementLocator.Driver.FindElement(By.Id("txtPassword")).SendKeys("\n");

            ElementLocator.Pause(5000);

            //Amy update starts: add customer selection for R1.0. so if running case in R1.0, these need to be uncomment.
            //comboBoxInstance.DisplayItems(ElementKey.CustomerSelection);
            //comboBoxInstance.SelectItem("Schneider");  //or "REMPlatform"
            //ElementLocator.FindElement(ElementDictionary[ElementKey.CustomerConfirmButton]).Click();
            //Amy update ends

            ElementLocator.WaitForElement(new Locator("header-btn-homepage-btnEl", ByType.ID), 150);
            //Amy comment: if running case in R1.0, below clause "ElementLocator.WaitForElementToDisappear.." needs to be commented out.
            ElementLocator.WaitForElementToDisappear(new Locator("mainLoadingMask", ByType.ID), 30);
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

            string defaultUserName = "demo";
            string defaultPassword = "password";

            var loginData = new LoginInputData() { UserName = defaultUserName, Password = defaultPassword };

            this.Login(loginData);
        }
    }
}
