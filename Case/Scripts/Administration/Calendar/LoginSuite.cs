using Mento.Framework.Attributes;
using Mento.Framework.Execution;
using Mento.Framework.Script;
using Mento.TestApi.TestData;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Threading = System.Threading;
using System;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.ScriptCommon.Library.Functions;

namespace Mento.Script.Administration.Calendar
{
    [TestFixture]
    [ManualCaseID("TA-Trial-Login")]
    [CreateTime("2012-11-01")]
    [Owner("Aries")]
    public class LoginSuite : TestSuiteBase
    {
        [SetUp]
        public void SetUp()
        {
            ElementLocator.OpenJazz();
        }

        [TearDown]
        public void TearDown()
        {
            ElementLocator.QuitJazz();
        }

        [Test]
        [CaseID("TA-Trial-Login-001")]
        [MultipleTestDataSource(typeof(LoginData[]), typeof(LoginSuite), "TA-Trial-Login-001")]
        public void LoginToJazz(LoginData loginData)
        {
            //throw new Exception(loginData.ToString());


            //Threading.Thread.Sleep(10000);

            FunctionWrapper.Login.Login(loginData.InputData);

            Assert.IsTrue(ElementLocator.WaitForElement(new Locator("header-btn-homepage-btnEl", ByType.ID), 600));
        }

        [Test]
        [CaseID("TA-Trial-Login-002")]
        //[TestCase]
        //[TestCase]
        //[TestCase]
        //[TestCase]
        //[TestCase]
        public void LoginJazzAndNavigage()
        {
            FunctionWrapper.Login.Login();

            var navigator = ControlAccess.GetControl<Navigator>();

            navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
        }
        
        [Test]
        [CaseID("TA-Trial-Login-003")]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void NavigateTest()
        {
            FunctionWrapper.Login.Login();

            var navigator = ControlAccess.GetControl<Navigator>();

            navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);

            Assert.That(ElementLocator.FindElement(new Locator("st-menu-areadtags", ByType.ID)).GetAttribute("class").Contains("x-btn-pressed"));
        }
    }
}
