using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.TestApi.TestData;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface;
using OpenQA.Selenium;
using Mento.ScriptCommon.Library.Functions;

namespace Mento.Script.Administration.Calendar
{
    [TestFixture]
    [ManualCaseID("TA-Example")]
    [CreateTime("2012-10-13")]
    [Owner("Aries")]
    public class ShowTimeSuite : TestSuiteBase
    {
        private Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();

        [SetUp]
        public void SetUp()
        {
            ElementLocator.OpenJazz();


        }
        
        [TearDown]
        public void TearDown()
        {
            //ElementLocator.QuitJazz();
        }
        
        [Test]
        [CreateTime("2012-11-08")]
        [Owner("Emma")]
        [CaseID("TC-J1-ShowTime-001")]
        public void LoginAndNavigateToPTag()
        {
            //Load login data
            LoginData loginData = TestContext.CurrentContext.GetTestData<LoginData>();

            TextField textField = ControlAccess.GetControl<TextField>();

            ElementLocator.WaitForElement(ElementDictionary[ElementKey.LoginName], 60);

            textField.FillIn(ElementKey.LoginName, loginData.InputData.UserName);
            textField.FillIn(ElementKey.LoginPassword, loginData.InputData.Password);

            IWebElement button = ElementLocator.FindElement(ElementDictionary[ElementKey.LoginSubmit]);
            button.Click();

            //wait
            ElementLocator.WaitForElement(new Locator("header-btn-homepage-btnInnerEl",ByType.ID), 60);
            ElementLocator.WaitForElementToDisappear(new Locator("mainLoadingMask", ByType.ID), 30);

            //navigate to ptag settings
            var settings = ElementLocator.FindElement(new Locator("header-btn-setting-btnEl", ByType.ID));
            settings.Click();

            ElementLocator.Pause(50);
            ElementLocator.WaitForElementToDisappear(new Locator("mainLoadingMask", ByType.ID), 30);

            var tagSettings = ElementLocator.FindElement(new Locator("setting-tab-tagmrg-btn-btnEl", ByType.ID));
            tagSettings.Click();

            ElementLocator.Pause(50);
            ElementLocator.WaitForElementToDisappear(new Locator("mainLoadingMask", ByType.ID), 30);

            var pTagSettings = ElementLocator.FindElement(new Locator("st-menu-ptagmgr-btnEl", ByType.ID));
            pTagSettings.Click();
        }


        [Test]
        [CreateTime("2012-11-08")]
        [Owner("Emma")]
        [CaseID("TC-J1-ShowTime-002")]
        public void LoginAndNavigateToPTagWithFunction()
        {
            LoginData loginData = TestContext.CurrentContext.GetTestData<LoginData>();

            FunctionWrapper.Login.Login(loginData.InputData);

            Navigator navigator = ControlAccess.GetControl<Navigator>();

            navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
        }
    }
}
