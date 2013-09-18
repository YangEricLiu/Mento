using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.TimeManagement
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-01-04")]
    public class HeatingCoolingSeasonAddSuite : TestSuiteBase
    {
        private static TimeSettingsHeatingCoolingSeason TimeSettingsHeatingCoolingSeason = JazzFunction.TimeSettingsHeatingCoolingSeason;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsHeatingCoolingSeason.NavigatorToHeatingCoolingSeasonCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        #region TestCase1 AddValidHCSeason
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Add-101")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Add-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonAddSuite), "TC-J1-FVT-TimeManagementHCSeason-Add-101")]
        public void AddValidHCSeason(HeatingCoolingSeasonCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsHeatingCoolingSeason.PrepareToAddHeatingCoolingSeasonCalendar();
            TimeManager.ShortPause();

            //Input valid name
            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.CommonName);

            //Add warm and cold ranges.
            TimeSettingsHeatingCoolingSeason.AddWarmRanges(testData);
            TimeSettingsHeatingCoolingSeason.AddColdRanges(testData);

            //Click "Save" button
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify saved successfully.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));

            //Verify the name
            Assert.AreEqual(testData.InputData.CommonName, TimeSettingsHeatingCoolingSeason.GetNameValue());

            //Verify warm and cold ranges are added successfully.        
            Assert.AreEqual(testData.InputData.WarmRange.Length, TimeSettingsHeatingCoolingSeason.GetWarmRangeItemsNumber());
            Assert.AreEqual(testData.InputData.ColdRange.Length, TimeSettingsHeatingCoolingSeason.GetColdRangeItemsNumber()); 
        }
        #endregion

        #region TestCase1 AddHCSeasonCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Add-001")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Add-001")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonAddSuite), "TC-J1-FVT-TimeManagementHCSeason-Add-001")]
        public void AddHCSeasonCancelled(HeatingCoolingSeasonCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsHeatingCoolingSeason.PrepareToAddHeatingCoolingSeasonCalendar();
            TimeManager.ShortPause();

            //Click "Cancel" button directly without any input.
            TimeSettingsHeatingCoolingSeason.ClickCancelButton();
            TimeManager.ShortPause();

            //Click '+ Calendar' button again
            TimeSettingsHeatingCoolingSeason.PrepareToAddHeatingCoolingSeasonCalendar();
            TimeManager.ShortPause();

            //Input valid input
            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.CommonName);
            TimeSettingsHeatingCoolingSeason.AddWarmRanges(testData);
            TimeSettingsHeatingCoolingSeason.AddColdRanges(testData);

            //Click "Cancel" button
            TimeSettingsHeatingCoolingSeason.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the addition is cancelled and NOT exists in the list.
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCalendarExist(testData.InputData.CommonName));
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());

            //Click '+ Calendar' button again
            TimeSettingsHeatingCoolingSeason.PrepareToAddHeatingCoolingSeasonCalendar();
            TimeManager.ShortPause();

            //verify that the previous input has been cleared.
            Assert.AreEqual(testData.ExpectedData.CommonName, TimeSettingsHeatingCoolingSeason.GetNameValue());

            //Click "Cancel" button
            TimeSettingsHeatingCoolingSeason.ClickCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());
        }
        #endregion

        #region TestCase2 AddInvalidHCSeason
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementHCSeason-Add-002")]
        [CaseID("TC-J1-FVT-TimeManagementHCSeason-Add-002")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(HeatingCoolingSeasonCalendarData[]), typeof(HeatingCoolingSeasonAddSuite), "TC-J1-FVT-TimeManagementHCSeason-Add-002")]
        public void AddInvalidHCSeason(HeatingCoolingSeasonCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsHeatingCoolingSeason.PrepareToAddHeatingCoolingSeasonCalendar();
            TimeManager.ShortPause();

            //Input invalid inputs, e.g. required fields are null; duplicated name;  overlapped ranges            
            TimeSettingsHeatingCoolingSeason.AddWarmRanges(testData);
            TimeSettingsHeatingCoolingSeason.AddColdRanges(testData);
            TimeSettingsHeatingCoolingSeason.FillInName(testData.InputData.CommonName);

            //Click "Save" button.
            TimeSettingsHeatingCoolingSeason.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsHeatingCoolingSeason.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsWarmRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsWarmRangeInvalidMsgCorrect(testData.ExpectedData, 2));
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsColdRangeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TimeSettingsHeatingCoolingSeason.IsColdRangeInvalidMsgCorrect(testData.ExpectedData, 2));

            //Click 'Cancel' button to quit the addition.
            TimeSettingsHeatingCoolingSeason.ClickCancelButton();
            TimeManager.ShortPause();
        }
        #endregion
    }
}
