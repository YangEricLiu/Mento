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
using Mento.Framework.Execution;

namespace Mento.Script.ClientAccess.DemoAccess
{
    [TestFixture]
    [Owner("Amber")]
    [CreateTime("2014-3-18")]
    public class DemoAccessValidSuite : TestSuiteBase
    {
        private static DemoAccessSetting DemoAccessSetting = JazzFunction.Demo;
        
        #region  TestCase1  DemoAccessValid
        [Test]
        [CaseID("TC-J1-FVT-DemoAccess-101")]
        [MultipleTestDataSource(typeof(DemoAccessData[]), typeof(DemoAccessValidSuite), "TC-J1-FVT-DemoAccess-101")]
        public void DemoAccessValid(DemoAccessData input)
        {
            //Open Jazz login page, Click the 'Demo' link (‘产品试用’).
            //Popup a dialog with email address field.
            DemoAccessSetting.DemoAccessButton.Click();
            TimeManager.ShortPause();
             
            //Input the email with valid address.
            DemoAccessSetting.FillInDemoAccessEmailAddressInfo(input.InputData.Email);

            //click the Send button.
            DemoAccessSetting.SendDemoAccessEmailButton.Click();
            TimeManager.MediumPause();

            //验证email输入的是否有效，若地址有效则发送成功.
            Assert.AreEqual(input.ExpectedData.Email, DemoAccessSetting.GetEmailSendedMessage());
        }
        #endregion

        #region  TestCase2  EmailAddressValid
        [Test]
        [CaseID("TC-J1-FVT-DemoAccess-102")]
        [MultipleTestDataSource(typeof(DemoAccessData[]), typeof(DemoAccessValidSuite), "TC-J1-FVT-DemoAccess-102")]
        public void EmailAddressValid(DemoAccessData input)
        {
            JazzBrowseManager.OpenJazz();

            //Open Jazz login page, Click the 'Demo' link (‘产品试用’).
            //Popup a dialog with email address field.
            DemoAccessSetting.DemoAccessButton.Click();
            TimeManager.LongPause();

            //Input the email with Valid address and click the Send button.
            DemoAccessSetting.FillInDemoAccessEmailAddressInfo(input.InputData.Email);
            DemoAccessSetting.SendDemoAccessEmailButton.Click();
            TimeManager.ShortPause();

            //验证email输入的是否有效，若地址有效则发送成功.
            Assert.AreEqual(input.ExpectedData.EmailSendedSuccessMessage, DemoAccessSetting.GetEmailSendedMessage());

        }
        #endregion

    }
}
