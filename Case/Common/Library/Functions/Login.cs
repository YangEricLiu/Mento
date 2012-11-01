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
    }
}
