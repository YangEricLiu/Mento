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

namespace Mento.Script.Administration.Tag
{
    [TestFixture]
    [ManualCaseID("TA-Trial-Login")]
    [CreateTime("2012-11-04")]
    [Owner("Aries")]
    public class VtagManagement : TestSuiteBase
    {
        private static Dictionary<string, Locator> ElementDictionary = ResourceManager.GetElementDictionary();
        private Navigator NavigatorIns = ControlAccess.GetControl<Navigator>();
        [SetUp]
        public void SetUp()
        {
            ElementLocator.OpenJazz();
        }

        [Test]
        //[CaseID("TA-Trial-Login-001")]
        //[MultipleTestDataSource(typeof(LoginData[]), typeof(VtagManagement), "TA-Trial-Login-001")]
        public void LoginToJazz(LoginData loginData)
        {
            //throw new Exception(loginData.ToString());

            //Threading.Thread.Sleep(10000);

            FunctionWrapper.Login.Login(loginData.InputData);
            Assert.IsTrue(ElementLocator.WaitForElement(new Locator("header-btn-homepage-btnEl", ByType.ID), 600));

            //Navigate to Vtag setting
            NavigatorIns.NavigateToTarget(NavigationTarget.TagSettingsV);
        }   
        FunctionWrapper.Vtag.ClickVtagConfigButton();

    }
}
