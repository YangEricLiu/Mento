using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.TestData.ClientAccess;

namespace Mento.ScriptCommon.Library.Functions
{
    public class LoginFunction
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();

        public void Login(LoginInputData loginData)
        {
            TextField UserNameField = ControlAccess.GetControl<TextField>();
            TextField PasswordField = ControlAccess.GetControl<TextField>();

            UserNameField.FillIn(ElementKey.LoginName, loginData.UserName);
            PasswordField.FillIn(ElementKey.LoginPassword, loginData.Password);

            var ButtonSubmit = ElementLocator.FindElement(ElementDictionary[ElementKey.LoginSubmit]);

            ButtonSubmit.Submit();
        }

        public void Login()
        {
            TextField UserNameField = ControlAccess.GetControl<TextField>();
            TextField PasswordField = ControlAccess.GetControl<TextField>();

            UserNameField.FillIn(ElementKey.LoginName, "demo");
            PasswordField.FillIn(ElementKey.LoginPassword, "password");

            var ButtonSubmit = ElementLocator.FindElement(ElementDictionary[ElementKey.LoginSubmit]);

            ButtonSubmit.Submit();

            //2012-11-05
            //test in cn proxy schneider intranet
            //load time: 27s, render time: 7s, total: 34s
            //test in fr proxy schneider intranet
            //load time: 66s, render time: 26s, total: 92s
            //load time: 72s, render time: 45s, total: 117s

            //pause 2.5 minutes to let ext render Jazz layout

            //ElementLocator.Pause(150000);
            ElementLocator.WaitForElement(new Locator("header-btn-homepage-btnEl", ByType.ID), 150);
            ElementLocator.WaitForElementToDisappear(new Locator("mainLoadingMask", ByType.ID), 30);
        }
    }
}
