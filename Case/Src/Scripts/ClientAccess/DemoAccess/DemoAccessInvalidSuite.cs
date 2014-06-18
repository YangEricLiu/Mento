using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Script;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;
using Mento.Framework.Execution;

namespace Mento.Script.ClientAccess.DemoAccess
{
    [TestFixture]
    [Owner("Amber")]
    [CreateTime("2014-3-19")]
    public class DemoAccessInvalidSuite : TestSuiteBase
    {
        private static DemoAccessSetting DemoAccessSetting = JazzFunction.Demo;

        private static HomePage HomePagePanel = JazzFunction.HomePage;
        #region  TestCase1  DemoAccessInvalid
        [Test]
        [CaseID("TC-J1-FVT-DemoAccess-001")]
        [MultipleTestDataSource(typeof(DemoAccessData[]), typeof(DemoAccessInvalidSuite), "TC-J1-FVT-DemoAccess-001")]
        public void DemoAccessInvalid(DemoAccessData  input)
        {
            //Open the SP2 system.
            //Verify demo link(产品试用) button in homepage,There is no Demo Link button.
            TestAssemblyInitializer.InitializeWithOption("SchneiderElectricChina", "P@ssw0rdChina", "$@Login.Label.SPManagement");
            TimeManager.LongPause();
            Assert.IsFalse(DemoAccessSetting.DemoAccessButton.IsExisted());
        }
        #endregion


        #region  TestCase2  DemoAccessCancelled
        [Test]
        [CaseID("TC-J1-FVT-DemoAccess-002")]
        [MultipleTestDataSource(typeof(DemoAccessData[]), typeof(DemoAccessInvalidSuite), "TC-J1-FVT-DemoAccess-002")]
        public void DemoAccessCancelled(DemoAccessData input)
        {
            //Open Jazz login page, Click the 'Demo' link (‘产品试用’).
            //Popup a dialog with email address field.
            DemoAccessSetting.DemoAccessButton.Click();
            TimeManager.LongPause();

            //Input the email with valid address and click the 返回首页 button.
            DemoAccessSetting.FillInDemoAccessEmailAddressInfo(input.InputData.Email);
            DemoAccessSetting.ReturnHomepageButton.Click();
            TimeManager.MediumPause();
        }
        #endregion

        #region  TestCase3  EmailAddressInvalid
        [Test]
        [CaseID("TC-J1-FVT-DemoAccess-003")]
        [IllegalInputValidation(typeof(DemoAccessData[]))]
        public void EmailAddressInvalid(DemoAccessData input)
        {
            JazzBrowseManager.OpenJazz();

            //Open Jazz login page, Click the 'Demo' link (‘产品试用’).
            //Popup a dialog with email address field.
            DemoAccessSetting.DemoAccessButton.Click();
            TimeManager.LongPause();
              
            //Input the email with invalid address and click the Send button.
            DemoAccessSetting.FillInDemoAccessEmailAddressInfo(input.InputData.Email);
            DemoAccessSetting.SendDemoAccessEmailButton.Click();

            //Pop up the wrong message
            DemoAccessSetting.GetEmailInvalidMessage();
      
        }
        #endregion
    }
}
 