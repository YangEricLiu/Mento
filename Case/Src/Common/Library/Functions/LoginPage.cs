using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;
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

        #region Old Jazz

        private static int WAITVERYLONGTIME = 10000;
        private static Locator HomePageNavigationLocator = JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.ButtonNavigatorHomePage);
        private static Locator OptionWindowLocator = JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.WindowLoginOption);
        private static ComboBox LoginCustomerOption = JazzComboBox.LoginCustomerOptionComboBox;
        private static Button LoginCustomerOptionConfirm = JazzButton.LoginCustomerOptionConfirmButton;
        //private ComboBox comboBoxInstance = ControlAccess.GetControl<ComboBox>();
        //private static Locator HomePageNavigationLocator = JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.ButtonNavigatorHomePage);
        private static Button ButtonNavigatorSelectedCustomer = JazzButton.NavigatorSelectedCustomerButton;
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
            string defaultPassword = "P@ssw0rd";

            var loginData = new LoginInputData() { UserName = defaultUserName, Password = defaultPassword };

            this.Login(loginData);
        }

        /// <summary>
        /// Switch to a certain customer
        /// </summary>
        /// <returns></returns>
        public void SwtichCustomer(string customername)
        {
            ButtonNavigatorSelectedCustomer.Click();
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
            string defaultPassword = "P@ssw0rd";

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


        public void LoginWithOption(string userName, string passWord, string customerName)
        {
            JazzTextField.LoginUserNameTextField.Fill(userName);
            JazzTextField.LoginPasswordTextField.Fill(passWord);

            JazzButton.LoginSubmitButton.Click();
            TimeManager.Pause(WAITVERYLONGTIME);

            if (String.IsNullOrEmpty(customerName))
            {
                if (JazzMessageBox.MessageBox.Exists())
                {
                    if (JazzMessageBox.MessageBox.GetMessage().Contains("地图不可用") || JazzMessageBox.MessageBox.GetMessage().Contains("map is unavailable"))
                    {
                        JazzMessageBox.MessageBox.OK();
                    }
                }

                if (JazzMessageBox.MessageBox.Exists())
                {
                    if (JazzMessageBox.MessageBox.GetMessage().Contains("服务器错误") || JazzMessageBox.MessageBox.GetMessage().Contains("Server error"))
                    {
                        JazzMessageBox.MessageBox.OK();
                    }
                }

                ElementHandler.Wait(HomePageNavigationLocator, WaitType.ToAppear, timeout: 5);
            }
            else
            {
                ElementHandler.Wait(OptionWindowLocator, WaitType.ToAppear, timeout: 30);

                if (ElementHandler.Exists(OptionWindowLocator))
                {
                    LoginCustomerOption.SelectItem(customerName);
                    TimeManager.ShortPause();
                    LoginCustomerOptionConfirm.Click();
                    TimeManager.LongPause();

                    if (JazzMessageBox.MessageBox.Exists())
                    {
                        if (JazzMessageBox.MessageBox.GetMessage().Contains("地图不可用") || JazzMessageBox.MessageBox.GetMessage().Contains("Google map is unavailable"))
                        {
                            JazzMessageBox.MessageBox.OK();
                        }
                    }

                    if (JazzMessageBox.MessageBox.Exists())
                    {
                        if (JazzMessageBox.MessageBox.GetMessage().Contains("服务器错误") || JazzMessageBox.MessageBox.GetMessage().Contains("Server error"))
                        {
                            JazzMessageBox.MessageBox.OK();
                        }
                    }
                    ElementHandler.Wait(HomePageNavigationLocator, WaitType.ToAppear, timeout: 5);
                }
                else
                {
                    throw new Exception("Login error, no popup option window and can't login");
                }
            }
        }

        public void LoginCutomerOption(string customer)
        {
            if (ElementHandler.Exists(OptionWindowLocator))
            {
                LoginCustomerOption.SelectItem(customer);
                TimeManager.ShortPause();
                LoginCustomerOptionConfirm.Click();
                ElementHandler.Wait(HomePageNavigationLocator, WaitType.ToAppear, timeout: 150);
                TimeManager.MediumPause();
            }
        }

        public bool IsAlreadyLogin()
        {
            var HomePageNavigationLocator = JazzControlLocatorRepository.GetLocator(JazzControlLocatorKey.ButtonNavigatorHomePage);
            return ElementHandler.Exists(HomePageNavigationLocator);
        }

        public bool IsOptionWindowPopup()
        {
            return ElementHandler.Exists(OptionWindowLocator);
        }

        public void RefreshJazz(string customerName = null)
        {
            JazzBrowseManager.RefreshJazz();
            if (String.IsNullOrEmpty(customerName))
            {
                if (JazzMessageBox.MessageBox.Exists())
                {
                    if (JazzMessageBox.MessageBox.GetMessage().Contains("地图不可用") || JazzMessageBox.MessageBox.GetMessage().Contains("Google map is unavailable"))
                    {
                        JazzMessageBox.MessageBox.OK();
                    }
                }

                TimeManager.ShortPause();

                if (JazzMessageBox.MessageBox.Exists())
                {
                    if (JazzMessageBox.MessageBox.GetMessage().Contains("服务器错误") || JazzMessageBox.MessageBox.GetMessage().Contains("Server error"))
                    {
                        JazzMessageBox.MessageBox.OK();
                    }
                }

                ElementHandler.Wait(HomePageNavigationLocator, WaitType.ToAppear, timeout: 300);
                TimeManager.MediumPause();
            }
            else
            {
                ElementHandler.Wait(OptionWindowLocator, WaitType.ToAppear, timeout: 300);
                TimeManager.MediumPause();

                if (ElementHandler.Exists(OptionWindowLocator))
                {
                    LoginCustomerOption.SelectItem(customerName);
                    TimeManager.ShortPause();
                    LoginCustomerOptionConfirm.Click();
                    TimeManager.Pause(5000);

                    if (JazzMessageBox.MessageBox.Exists())
                    {
                        if (JazzMessageBox.MessageBox.GetMessage().Contains("地图不可用") || JazzMessageBox.MessageBox.GetMessage().Contains("Google map is unavailable"))
                        {
                            JazzMessageBox.MessageBox.OK();
                        }
                    }

                    TimeManager.ShortPause();

                    if (JazzMessageBox.MessageBox.Exists())
                    {
                        if (JazzMessageBox.MessageBox.GetMessage().Contains("服务器错误") || JazzMessageBox.MessageBox.GetMessage().Contains("Server error"))
                        {
                            JazzMessageBox.MessageBox.OK();
                        }
                    }

                    ElementHandler.Wait(HomePageNavigationLocator, WaitType.ToAppear, timeout: 300);
                    TimeManager.MediumPause();
                }
            }
        }

        #endregion

        #region New Jazz

        private static Button SwitchLanguageLoginPageButton = JazzButton.SwitchLanguageLoginPageButton;

        public void SwitchLanguageOnLoginPage()
        {
            if (SwitchLanguageLoginPageButton.NewJazz_GetButtonText().Contains("中文版"))
            { 
                SwitchLanguageLoginPageButton.Click();
                TimeManager.LongPause();
                TimeManager.LongPause();
            }
        }          

        #endregion
    }
}
