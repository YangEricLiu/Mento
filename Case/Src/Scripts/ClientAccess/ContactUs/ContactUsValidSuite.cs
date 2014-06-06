using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.ScriptCommon.Library.Functions;
using NUnit.Framework;
using Mento.Framework.Script;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.TestApi.TestData;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.ClientAccess.ContactUs
{
    [TestFixture]
    [Owner("Amber")]
    [CreateTime("2014-3-26")]
    public class ContactUsValidSuite : TestSuiteBase
    {
        private static ContactUsSetting ContactUsSetting = JazzFunction.ContactUsPage;

        #region  TestCase1  ContactUsValid
        [Test]
        [CaseID("TC-J1-FVT-ContactUs-101")]
        [MultipleTestDataSource(typeof(ContactUsData[]), typeof(ContactUsValidSuite), "TC-J1-FVT-ContactUs-101")]
        public void ContactUsValid(ContactUsData input)
        {
            //Open the homepage via click the hyperlink send for created demo user.
            JazzFunction.LoginPage.LoginCutomerOption(input.InputData.Customer);
            TimeManager.Pause(20000);

            //Go to verify Contact Us.
            Assert.IsTrue(ContactUsSetting.ContactUsButtonIsVisiable());

            //Click Contact Us.
            ContactUsSetting.ContactUsButton.Click();
            TimeManager.MediumPause();

            //Input valid info in Name, Telephone, Company, Title and Description fields.
            ContactUsSetting.FillInContactUsNameInfo(input.InputData.Name);
            ContactUsSetting.FillInContactUsTelephoneInfo(input.InputData.Telephone);
            ContactUsSetting.FillInContactUsCompanyInfo(input.InputData.Company);
            ContactUsSetting.FillInContactUsTitleInfo(input.InputData.Title);
            ContactUsSetting.FillInContactUsDescriptionFieldsInfo(input.InputData.DescriptionFields);
            TimeManager.ShortPause();

            // click Confirm button.
            ContactUsSetting.ContactUsConfirmButton.Click();

        }
        #endregion
    }
}