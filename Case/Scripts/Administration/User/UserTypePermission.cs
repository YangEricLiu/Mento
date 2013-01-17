﻿using System;
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
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.Script.Administration.User
{
    [TestFixture]
    public class UserTypePermission : TestSuiteBase
    {
        private UserTypePermissionSettings UserTypePermissionSettings = JazzFunction.UserTypePermissionSettings;

        [SetUp]
        [Owner("Alice")]
        [CreateTime("2013-01-17")]
        [ManualCaseID("TC-J1-SmokeTest")]
        public void CaseSetUp()
        {
            UserTypePermissionSettings.NavigatorToUserTypePermissionSetting();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            BrowserHandler.Refresh();
        }

        [Test]
        //[CaseID("TC-J1-SmokeTest-034-Modify"), CreateTime("2013-01-08"), Owner("Nancy")]
        //[MultipleTestDataSource(typeof(UserSettingsData[]), typeof(UserTypePermission), "TC-J1-SmokeTest-027")]
        public void ModifyUserTypePermission()
        {
            string usertypeName = "工程人员";
            UserTypePermissionSettings.FocusOnUserType(usertypeName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            Assert.IsFalse(UserTypePermissionSettings.UserTypeCostIsChecked());
            Assert.IsTrue(UserTypePermissionSettings.UserTypeEnergyUseIsChecked());
            
            //UserTypePermissionSettings.ClickModifyButton();
            //
            //UserTypePermissionSettings.ClickSaveButton();
            
            //Assert.IsTrue(UserTypePermissionSettings.UserTypeCostIsChecked());
            //Assert.IsFalse(UserTypePermissionSettings.UserTypeEnergyUseIsChecked());
            
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

           
        }
    
    }

}   
