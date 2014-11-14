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
using Mento.Script.ClientAccess;
using Mento.TestApi.WebUserInterface;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.ClientAccess.ContactUs
{
    [TestFixture]
    [Owner("Amber")]
    [CreateTime("2014-3-27")]
    public class ContactUsInvalidSuite : TestSuiteBase
    {
        private static ContactUsSetting ContactUsSetting = JazzFunction.ContactUsPage;

        #region  TestCase1  ContactUsWithRequiredFieldsEmpty
        [Test]
        [CaseID("TC-J1-FVT-ContactUs-001")]
        [MultipleTestDataSource(typeof(ContactUsData[]), typeof(ContactUsInvalidSuite), "TC-J1-FVT-ContactUs-001")]
        public void ContactUsWithRequiredFieldsEmpty(ContactUsData input)
        {
            //Open the homepage via click the hyperlink send for created demo user.
            JazzFunction.LoginPage.LoginCutomerOption(input.InputData.Customer);
            TimeManager.LongPause();

            //Click Contact Us.
            ContactUsSetting.ContactUsButton.Click();
            TimeManager.ShortPause();

            //Click Confirm button without add information. 
            //The message showing that Name, Telephone, Company should not be empty.
            ContactUsSetting.ContactUsConfirmButton.Click();
            Assert.AreEqual(input.ExpectedData.InvalidMessages[0], ContactUsSetting.GetTextFieldContactUsNameInvalidMsg());
            Assert.AreEqual(input.ExpectedData.InvalidMessages[0], ContactUsSetting.GetTextFieldContactUsTelephoneInvalidMsg());
            Assert.AreEqual(input.ExpectedData.InvalidMessages[0], ContactUsSetting.GetTextFieldContactUsCompanyInvalidMsg());

            //Add information for Name and Click Send button.
            //The message showing that Telephone, Company should not be empty.
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsNameInfo(input.InputData.Name);
            ContactUsSetting.ContactUsConfirmButton.Click();
            Assert.AreEqual(input.ExpectedData.InvalidMessages[0], ContactUsSetting.GetTextFieldContactUsTelephoneInvalidMsg());
            Assert.AreEqual(input.ExpectedData.InvalidMessages[0], ContactUsSetting.GetTextFieldContactUsCompanyInvalidMsg());

            //Add information for Telephone and Click Send button.
            //The message showing that Company should not be empty.
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsTelephoneInfo(input.InputData.Telephone);
            ContactUsSetting.ContactUsConfirmButton.Click();
            Assert.AreEqual(input.ExpectedData.InvalidMessages[0], ContactUsSetting.GetTextFieldContactUsCompanyInvalidMsg());

            //Add information for Company and Click Send button.
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsCompanyInfo(input.InputData.Company);
            ContactUsSetting.ContactUsConfirmButton.Click();
        }
        #endregion

        #region  TestCase2  ContactUsWithInvalid
        [Test]
        [CaseID("TC-J1-FVT-ContactUs-002")]
        [MultipleTestDataSource(typeof(ContactUsData[]), typeof(ContactUsInvalidSuite), "TC-J1-FVT-ContactUs-002")]
        public void ContactUsWithInvalid(ContactUsData input)
        {
            //Open the homepage via click the hyperlink send for created demo user.
            JazzFunction.LoginPage.LoginCutomerOption(input.InputData.Customer);
            TimeManager.LongPause();

            //Click Contact Us.
            ContactUsSetting.ContactUsButton.Click();
            TimeManager.ShortPause();
            
            //There are five groups of illegal data
            int InvalidNumber=5;
            for(int i=0;i<InvalidNumber;i++)
            {
                //Add invalid information for Name and Click Send button.
                //The message showing that Name is invalid.
                ContactUsSetting.FillInContactUsNameInfo(input.InputData.Names[i]);
                TimeManager.ShortPause();
                ContactUsSetting.ContactUsConfirmButton.Click();
                Assert.AreEqual(input.ExpectedData.Name, ContactUsSetting.getContactUsInvalidNameMessage());
                TimeManager.ShortPause();

                //Add invalid information for Telephone and Click Send button.
                //The message showing that Telephone is invalid.
                ContactUsSetting.FillInContactUsTelephoneInfo(input.InputData.Telephones[i]);
                TimeManager.ShortPause();
                ContactUsSetting.ContactUsConfirmButton.Click();
                // Assert.IsTrue(ContactUsSetting.IsTextFieldContactUsTelephoneDisplayed());
                Assert.AreEqual(input.ExpectedData.Telephone, ContactUsSetting.getContactUsInvalidTelephoneMessage());

                //Add invalid information for Company and Click Send button.
                //The message showing that Company is invalid.
                ContactUsSetting.FillInContactUsCompanyInfo(input.InputData.Companys[i]);
                TimeManager.ShortPause();
                ContactUsSetting.ContactUsConfirmButton.Click();
                Assert.AreEqual(input.ExpectedData.Company, ContactUsSetting.getContactUsInvalidCompanyMessage());

                //Add invalid information for Title and Click Send button.
                //The message showing that Title is invalid.
                ContactUsSetting.FillInContactUsTitleInfo(input.InputData.Titles[i]);
                TimeManager.ShortPause();
                ContactUsSetting.ContactUsConfirmButton.Click();
                Assert.AreEqual(input.ExpectedData.Title, ContactUsSetting.getContactUsInvalidTitleMessage());

                //Add invalid information for Description fields and Click Send button.
                //The message showing that Description fields is invalid.
                ContactUsSetting.FillInContactUsDescriptionFieldsInfo(input.InputData.DescriptionFieldss[i]);
                TimeManager.ShortPause();
                ContactUsSetting.ContactUsConfirmButton.Click();
                Assert.AreEqual(input.ExpectedData.DescriptionFields, ContactUsSetting.getContactUsInvalidDescriptionFieldsMessage());
            }
            
            //Add valid information for Name, Telephone, Company, Title and Description fields. And then click Send button.
            ContactUsSetting.FillInContactUsNameInfo(input.InputData.Names[5]);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsTelephoneInfo(input.InputData.Telephones[5]);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsCompanyInfo(input.InputData.Companys[5]);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsTitleInfo(input.InputData.Titles[5]);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsDescriptionFieldsInfo(input.InputData.DescriptionFieldss[5]);
            TimeManager.ShortPause();

            // click Confirm button.
            ContactUsSetting.ContactUsConfirmButton.Click();
        }

        #endregion

        #region  TestCase3  ContactUsCancelledandClosed
        [Test]
        [CaseID("TC-J1-FVT-ContactUs-003")]
        [MultipleTestDataSource(typeof(ContactUsData[]), typeof(ContactUsInvalidSuite), "TC-J1-FVT-ContactUs-003")]
        public void ContactUsCancelledandClosed(ContactUsData input)
        {
            //Open the homepage via click the hyperlink send for created demo user.
            JazzFunction.LoginPage.LoginCutomerOption(input.InputData.Customer);
            TimeManager.LongPause();

            //Click Contact Us.
            ContactUsSetting.ContactUsButton.Click();
            TimeManager.ShortPause();

            //Input valid info in Name, Telephone, Company, Title and Description fields.
            ContactUsSetting.FillInContactUsNameInfo(input.InputData.Name);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsTelephoneInfo(input.InputData.Telephone);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsCompanyInfo(input.InputData.Company);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsTitleInfo(input.InputData.Title);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsDescriptionFieldsInfo(input.InputData.DescriptionFields);
            TimeManager.ShortPause();

            //Click Cancel button
            ContactUsSetting.ContactUsCancelButton.Click();

            //Click Contact Us.
            ContactUsSetting.ContactUsButton.Click();
            TimeManager.ShortPause();

            //Input valid info in Name, Telephone, Company, Title and Description fields.
            ContactUsSetting.FillInContactUsNameInfo(input.InputData.Name);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsTelephoneInfo(input.InputData.Telephone);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsCompanyInfo(input.InputData.Company);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsTitleInfo(input.InputData.Title);
            TimeManager.ShortPause();
            ContactUsSetting.FillInContactUsDescriptionFieldsInfo(input.InputData.DescriptionFields);
            TimeManager.ShortPause();

            //Click Close button
            ContactUsSetting.ContactUsCloseButton.Click();
        }
        #endregion


    }
}
