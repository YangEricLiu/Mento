using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2015-04-27")]
    [ManualCaseID("TC-J1-FVT-Hierarchy-Administrator-101")]
    public class AdministratorInfoSuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static AdministratorInfoSetting AdministratorInfoSetting = JazzFunction.AdministratorInfoSetting;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();

            HierarchySetting.NavigatorToHierarchySetting();
            TimeManager.MediumPause();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HierarchySetting.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Administrator-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AdministratorInfoData[]), typeof(AdministratorInfoSuite), "TC-J1-FVT-Hierarchy-Administrator-Add-101-1")]
        public void AddValidAdministrator(AdministratorInfoData input)
        {
            //Click 楼宇A to 管理员 tab.
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoTab();
            TimeManager.MediumPause();

            //Click "+管理员"/"修改" button
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();
            
            //Input value and save
            AdministratorInfoSetting.FillInAdministratorInfo_N(input.InputData, 1);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //空格应该滤掉
            //Verify the input value displayed correct
            Assert.AreEqual(input.ExpectedData.RealName, AdministratorInfoSetting.GetRealNameValue_N(1));
            Assert.AreEqual(input.ExpectedData.Position, AdministratorInfoSetting.GetPositionValue_N(1));
            Assert.AreEqual(input.ExpectedData.Mobile, AdministratorInfoSetting.GetMobileValue_N(1));
            Assert.AreEqual(input.ExpectedData.Telephone, AdministratorInfoSetting.GetTelephoneValue_N(1));
            Assert.AreEqual(input.ExpectedData.Email, AdministratorInfoSetting.GetEmailValue_N(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Administrator-Add-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AdministratorInfoData[]), typeof(AdministratorInfoSuite), "TC-J1-FVT-Hierarchy-Administrator-Add-101-2")]
        public void AddValidAdministratorTelephoneOrMobile(AdministratorInfoData input)
        {
            //Click 楼宇A to 管理员 tab.
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoTab();
            TimeManager.MediumPause();

            //Click "+管理员"/"修改" button
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            //Input value and save
            AdministratorInfoSetting.FillInRealName_N(input.InputData.RealName, 1);
            AdministratorInfoSetting.FillInPosition_N(input.InputData.Position, 1);
            AdministratorInfoSetting.FillInMobile_N(input.InputData.Mobile, 1);
            AdministratorInfoSetting.FillInEmail_N(input.InputData.Email, 1);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //Verify the input value displayed correct
            Assert.AreEqual(input.ExpectedData.RealName, AdministratorInfoSetting.GetRealNameValue_N(1));
            Assert.AreEqual(input.ExpectedData.Position, AdministratorInfoSetting.GetPositionValue_N(1));
            Assert.AreEqual(input.ExpectedData.Mobile, AdministratorInfoSetting.GetMobileValue_N(1));
            Assert.AreEqual(input.ExpectedData.Email, AdministratorInfoSetting.GetEmailValue_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsTelephoneHidden_N(1));

            //Click "+管理员"/"修改" button
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoAppendButton();
            TimeManager.MediumPause();

            //Input value and save
            AdministratorInfoSetting.FillInRealName_N(input.InputData.RealName, 2);
            AdministratorInfoSetting.FillInPosition_N(input.InputData.Position, 2);
            AdministratorInfoSetting.FillInTelephone_N(input.InputData.Telephone, 2);
            AdministratorInfoSetting.FillInEmail_N(input.InputData.Email, 2);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            Assert.AreEqual(input.ExpectedData.RealName, AdministratorInfoSetting.GetRealNameValue_N(2));
            Assert.AreEqual(input.ExpectedData.Position, AdministratorInfoSetting.GetPositionValue_N(2));
            Assert.AreEqual(input.ExpectedData.Telephone, AdministratorInfoSetting.GetTelephoneValue_N(2));
            Assert.AreEqual(input.ExpectedData.Email, AdministratorInfoSetting.GetEmailValue_N(2));
            Assert.IsTrue(AdministratorInfoSetting.IsMobileHidden_N(2));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Administrator-Add-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AdministratorInfoData[]), typeof(AdministratorInfoSuite), "TC-J1-FVT-Hierarchy-Administrator-Add-101-3")]
        public void AddInvalidAdministrator(AdministratorInfoData input)
        {
            //Click 楼宇A to 管理员 tab.
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoTab();
            TimeManager.MediumPause();

            //Click "+管理员"/"修改" button
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            //Input value and save
            AdministratorInfoSetting.FillInAdministratorInfo_N(input.InputData, 1);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.IsTrue(AdministratorInfoSetting.IsRealNameInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.RealName, AdministratorInfoSetting.GetRealNameInvalidMsg_N(1));

            Assert.IsTrue(AdministratorInfoSetting.IsPositionInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.Position, AdministratorInfoSetting.GetPositionInvalidMsg_N(1));

            Assert.IsTrue(AdministratorInfoSetting.IsMobileInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.Mobile, AdministratorInfoSetting.GetMobileInvalidMsg_N(1));

            Assert.IsTrue(AdministratorInfoSetting.IsTelephoneInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.Telephone, AdministratorInfoSetting.GetTelephoneInvalidMsg_N(1));

            Assert.IsTrue(AdministratorInfoSetting.IsEmailInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.Email, AdministratorInfoSetting.GetEmailInvalidMsg_N(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Administrator-Add-101-4")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AdministratorInfoData[]), typeof(AdministratorInfoSuite), "TC-J1-FVT-Hierarchy-Administrator-Add-101-4")]
        public void AddInvalidAdministratorEmpty(AdministratorInfoData input)
        {
            //Click 楼宇A to 管理员 tab.
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoTab();
            TimeManager.MediumPause();

            //Click "+管理员"/"修改" button
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.IsTrue(AdministratorInfoSetting.IsRealNameInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.RealName, AdministratorInfoSetting.GetRealNameInvalidMsg_N(1));

            Assert.IsTrue(AdministratorInfoSetting.IsPositionInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.Position, AdministratorInfoSetting.GetPositionInvalidMsg_N(1));

            Assert.IsTrue(AdministratorInfoSetting.IsTelephoneInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.Telephone, AdministratorInfoSetting.GetTelephoneInvalidMsg_N(1));

            Assert.IsTrue(AdministratorInfoSetting.IsEmailInvalid_N(1));
            Assert.AreEqual(input.ExpectedData.Email, AdministratorInfoSetting.GetEmailInvalidMsg_N(1));

            //Change invalid fields to valid then save
            AdministratorInfoSetting.FillInAdministratorInfo_N(input.InputData, 1);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //Verify the input value displayed correct
            Assert.AreEqual(input.InputData.RealName, AdministratorInfoSetting.GetRealNameValue_N(1));
            Assert.AreEqual(input.InputData.Position, AdministratorInfoSetting.GetPositionValue_N(1));
            Assert.AreEqual(input.InputData.Mobile, AdministratorInfoSetting.GetMobileValue_N(1));
            Assert.AreEqual(input.InputData.Telephone, AdministratorInfoSetting.GetTelephoneValue_N(1));
            Assert.AreEqual(input.InputData.Email, AdministratorInfoSetting.GetEmailValue_N(1));
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Administrator-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AdministratorInfoData[]), typeof(AdministratorInfoSuite), "TC-J1-FVT-Hierarchy-Administrator-Modify-101-1")]
        public void ModifyValidAdministrator(AdministratorInfoData input)
        {
            //Click 楼宇A to 管理员 tab.
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoTab();
            TimeManager.MediumPause();

            //Click "+管理员"/"修改" button
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            // Save directly without input.
            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //Verify the input value displayed correct
            Assert.AreEqual(input.ExpectedData.RealName, AdministratorInfoSetting.GetRealNameValue_N(1));
            Assert.AreEqual(input.ExpectedData.Position, AdministratorInfoSetting.GetPositionValue_N(1));
            Assert.AreEqual(input.ExpectedData.Mobile, AdministratorInfoSetting.GetMobileValue_N(1));
            Assert.AreEqual(input.ExpectedData.Telephone, AdministratorInfoSetting.GetTelephoneValue_N(1));
            Assert.AreEqual(input.ExpectedData.Email, AdministratorInfoSetting.GetEmailValue_N(1));

            //Click 修改 button, Modify to valid fileds and save.
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            AdministratorInfoSetting.FillInRealName_N(input.InputData.RealName + input.InputData.ValidChar, 1);
            AdministratorInfoSetting.FillInPosition_N(input.InputData.Position + input.InputData.ValidChar, 1);
            AdministratorInfoSetting.FillInMobile_N(input.InputData.Mobile + input.InputData.ValidChar, 1);
            AdministratorInfoSetting.FillInTelephone_N(input.InputData.Telephone + input.InputData.ValidChar, 1);
            AdministratorInfoSetting.FillInEmail_N(input.InputData.Email + input.InputData.ValidChar, 1);

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //Verify the input value displayed correct
            Assert.AreEqual(input.ExpectedData.RealName + input.InputData.ValidChar, AdministratorInfoSetting.GetRealNameValue_N(1));
            Assert.AreEqual(input.ExpectedData.Position + input.InputData.ValidChar, AdministratorInfoSetting.GetPositionValue_N(1));
            Assert.AreEqual(input.ExpectedData.Mobile + input.InputData.ValidChar, AdministratorInfoSetting.GetMobileValue_N(1));
            Assert.AreEqual(input.ExpectedData.Telephone + input.InputData.ValidChar, AdministratorInfoSetting.GetTelephoneValue_N(1));
            Assert.AreEqual(input.ExpectedData.Email + input.InputData.ValidChar, AdministratorInfoSetting.GetEmailValue_N(1));

            //Click 修改 button, Modify to invalid fileds and save.
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            //Change invalid fields to valid, and save with valid.
            AdministratorInfoSetting.FillInRealName_N(input.InputData.RealName + input.InputData.InvalidChar, 1);
            AdministratorInfoSetting.FillInPosition_N(input.InputData.Position + input.InputData.InvalidChar, 1);
            AdministratorInfoSetting.FillInMobile_N(input.InputData.Mobile + input.InputData.InvalidChar, 1);
            AdministratorInfoSetting.FillInTelephone_N(input.InputData.Telephone + input.InputData.InvalidChar, 1);
            AdministratorInfoSetting.FillInEmail_N(input.InputData.Email + input.InputData.InvalidChar, 1);

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            Assert.IsTrue(AdministratorInfoSetting.IsRealNameInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsPositionInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsMobileInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsTelephoneInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsEmailInvalid_N(1));

            AdministratorInfoSetting.FillInRealName_N(input.InputData.RealName, 1);
            AdministratorInfoSetting.FillInPosition_N(input.InputData.Position, 1);
            AdministratorInfoSetting.FillInMobile_N(input.InputData.Mobile, 1);
            AdministratorInfoSetting.FillInTelephone_N(input.InputData.Telephone, 1);
            AdministratorInfoSetting.FillInEmail_N(input.InputData.Email, 1);

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //Verify the input value displayed correct
            Assert.AreEqual(input.ExpectedData.RealName, AdministratorInfoSetting.GetRealNameValue_N(1));
            Assert.AreEqual(input.ExpectedData.Position, AdministratorInfoSetting.GetPositionValue_N(1));
            Assert.AreEqual(input.ExpectedData.Mobile, AdministratorInfoSetting.GetMobileValue_N(1));
            Assert.AreEqual(input.ExpectedData.Telephone, AdministratorInfoSetting.GetTelephoneValue_N(1));
            Assert.AreEqual(input.ExpectedData.Email, AdministratorInfoSetting.GetEmailValue_N(1));
            
            //Click 修改 button, Modify to invalid fileds and save.
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            //Modify to click X to delete all 管理员 and saved.
            AdministratorInfoSetting.ClickDeleteAdministratorInfoButton(1);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //修改 buttong change to show +管理员.
            Assert.IsTrue(AdministratorInfoSetting.IsAdministratorInfoCreateButtonDisplayed());
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Administrator-Modify-101-2")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AdministratorInfoData[]), typeof(AdministratorInfoSuite), "TC-J1-FVT-Hierarchy-Administrator-Modify-101-2")]
        public void ModifyInvalidAdministrator(AdministratorInfoData input)
        {
            //Click 楼宇A to 管理员 tab.
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AdministratorInfoSetting.ClickAdministratorInfoTab();
            TimeManager.MediumPause();

            //Click 修改 button, Change all field to blank and saved.
            AdministratorInfoSetting.ClickAdministratorInfoCreateButton();
            TimeManager.MediumPause();

            AdministratorInfoSetting.FillInRealName_N("", 1);
            AdministratorInfoSetting.FillInPosition_N("", 1);
            AdministratorInfoSetting.FillInMobile_N("", 1);
            AdministratorInfoSetting.FillInTelephone_N("", 1);
            AdministratorInfoSetting.FillInEmail_N("", 1);

            // Save directly without input.
            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //Error redline and message display at the required fields.
            Assert.IsTrue(AdministratorInfoSetting.IsRealNameInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsPositionInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsTelephoneInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsEmailInvalid_N(1));

            //Change invalid fields to valid, and save with valid.
            AdministratorInfoSetting.FillInRealName_N(input.InputData.RealName + input.InputData.InvalidChar, 1);
            AdministratorInfoSetting.FillInPosition_N(input.InputData.Position + input.InputData.InvalidChar, 1);
            AdministratorInfoSetting.FillInMobile_N(input.InputData.Mobile + input.InputData.InvalidChar, 1);
            AdministratorInfoSetting.FillInTelephone_N(input.InputData.Telephone + input.InputData.InvalidChar, 1);
            AdministratorInfoSetting.FillInEmail_N(input.InputData.Email + input.InputData.InvalidChar, 1);

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //Error redline and message display at the required fields.
            Assert.IsTrue(AdministratorInfoSetting.IsRealNameInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsPositionInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsMobileInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsTelephoneInvalid_N(1));
            Assert.IsTrue(AdministratorInfoSetting.IsEmailInvalid_N(1));

            //Change invalid fields to valid.
            AdministratorInfoSetting.FillInRealName_N(input.InputData.RealName, 1);
            AdministratorInfoSetting.FillInPosition_N(input.InputData.Position, 1);
            AdministratorInfoSetting.FillInMobile_N(input.InputData.Mobile, 1);
            AdministratorInfoSetting.FillInTelephone_N(input.InputData.Telephone, 1);
            AdministratorInfoSetting.FillInEmail_N(input.InputData.Email, 1);

            AdministratorInfoSetting.ClickAdministratorInfoSaveButton();
            TimeManager.LongPause();

            //Verify the input value displayed correct
            Assert.AreEqual(input.ExpectedData.RealName, AdministratorInfoSetting.GetRealNameValue_N(1));
            Assert.AreEqual(input.ExpectedData.Position, AdministratorInfoSetting.GetPositionValue_N(1));
            Assert.AreEqual(input.ExpectedData.Mobile, AdministratorInfoSetting.GetMobileValue_N(1));
            Assert.AreEqual(input.ExpectedData.Telephone, AdministratorInfoSetting.GetTelephoneValue_N(1));
            Assert.AreEqual(input.ExpectedData.Email, AdministratorInfoSetting.GetEmailValue_N(1));
        }
    }
}
