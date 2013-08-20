using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using System.IO;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.TestData.Attribute;
namespace Mento.Script.Administration.User
{
    [TestFixture]
    [Owner("Greenie")]
    [CreateTime("2013-08-13")]
    [ManualCaseID("TC-J1-FVT-UserDataScope-Modify-101")]
    public class ModifyMultiCustomerSuite : TestSuiteBase
    {
        private UserDataScopePermission UserDataPermissionSettings = JazzFunction.UserDataScopePermission;

        [SetUp]
        public void CaseSetUp()
        {
            UserDataPermissionSettings.NavigatorToUserSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-1")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-1")]
        public void ModifyThenSwitch(UserDataPermissionData input)
        {
            // Focus on a new created user, open datascope tab. 
            JazzFunction.UserSettings.FocusOnUser(input.InputData.UserName);
            UserDataPermissionSettings.SwitchToDataPermissionTab();
            TimeManager.ShortPause();
            UserDataPermissionSettings.ClickModifyButton();

            // Check multiple customers 
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[0]);
            UserDataPermissionSettings.UnCheckCustomer(input.InputData.CustomerList[1]);
            UserDataPermissionSettings.CheckCustomer(input.InputData.CustomerList[2]);
            UserDataPermissionSettings.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
           // View the data permission  
            Assert.IsFalse(UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[0]));
            Assert.IsFalse(UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[1]));
            UserDataPermissionSettings.ClickEditDataPermission(input.InputData.CustomerList[2]);

        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-2")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-2")]
        public void ModifyThenCancel(UserDataPermissionData input)
        {
         
        }

        [Test]
        [CaseID("TC-J1-FVT-UserDataScope-Modify-101-3")]
        [MultipleTestDataSource(typeof(UserDataPermissionData[]), typeof(ModifyMultiCustomerSuite), "TC-J1-FVT-UserDataScope-Modify-101-3")]
        public void SaveTreeThenCancel(UserDataPermissionData input)
        {
            
        }
    }
}
