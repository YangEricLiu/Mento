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
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.TestData.Administration;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Administration.TimeManagement
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-01-04")]
    public class DayNightAddSuite : TestSuiteBase
    {
        private static TimeSettingsDayNight TimeSettingsDayNight = JazzFunction.TimeSettingsDayNight;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsDayNight.NavigatorToDaynightCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
            //TimeManager.MediumPause();
        }

        #region TestCase1 AddValidDayNight
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Add-101")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Add-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightAddSuite), "TC-J1-FVT-TimeManagementDayNight-Add-101")]
        public void AddValidDayNight(DayNightCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsDayNight.PrepareToAddDaynightCalendar();
            TimeManager.ShortPause();

            //Verify the label text
            Assert.IsTrue(TimeSettingsDayNight.IsDayNightCalendarTextCorrect(testData.ExpectedData.LabelText));

            //Input valid name
            TimeSettingsDayNight.FillInName(testData.InputData.CommonName);

            //Add time ranges.
            TimeSettingsDayNight.AddTimeRanges(testData);

            //Click "Save" button
            TimeSettingsDayNight.ClickSaveButton();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify saved successfully.
            Assert.IsFalse(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsCalendarExist(testData.ExpectedData.CommonName));

            //Verify TimeRanges are added successfully.        
            Assert.AreEqual(testData.InputData.TimeRange.Length, TimeSettingsDayNight.GetTimeRangeItemsNumber());
            for (int elementPosition = 1; elementPosition <= testData.InputData.TimeRange.Length; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                Assert.AreEqual(testData.InputData.TimeRange[inputDataArrayPosition].StartTime, TimeSettingsDayNight.GetStartTimeValue(elementPosition));
                Assert.AreEqual(testData.InputData.TimeRange[inputDataArrayPosition].EndTime, TimeSettingsDayNight.GetEndTimeValue(elementPosition));
            }
        }
        #endregion

        #region TestCase1 AddDayNightCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Add-001")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Add-001")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightAddSuite), "TC-J1-FVT-TimeManagementDayNight-Add-001")]
        public void AddDayNightCancelled(DayNightCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsDayNight.PrepareToAddDaynightCalendar();
            TimeManager.ShortPause();

            //Click "Cancel" button directly without any input.
            TimeSettingsDayNight.ClickCancelButton();
            TimeManager.ShortPause();

            //Click '+ Calendar' button again
            TimeSettingsDayNight.PrepareToAddDaynightCalendar();
            TimeManager.ShortPause();

            //Input valid input
            TimeSettingsDayNight.FillInName(testData.InputData.CommonName);

            //Add time ranges.
            TimeSettingsDayNight.AddTimeRanges(testData);

            //Click "Cancel" button
            TimeSettingsDayNight.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the addition is cancelled and NOT exists in the list.
            Assert.IsFalse(TimeSettingsDayNight.IsCalendarExist(testData.InputData.CommonName));
            Assert.IsFalse(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsDayNight.IsCancelButtonDisplayed());

            //Click '+ Calendar' button again
            TimeSettingsDayNight.PrepareToAddDaynightCalendar();
            TimeManager.ShortPause();

            //verify that the previous input has been cleared.
            Assert.AreEqual(testData.ExpectedData.CommonName, TimeSettingsDayNight.GetNameValue());

            //Click "Cancel" button
            TimeSettingsDayNight.ClickCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(TimeSettingsDayNight.IsCancelButtonDisplayed());
        }
        #endregion

        #region TestCase2 AddInvalidDayNight
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Add-002")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Add-002")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(DayNightCalendarData[]), typeof(DayNightAddSuite), "TC-J1-FVT-TimeManagementDayNight-Add-002")]
        public void AddInvalidDayNight(DayNightCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsDayNight.PrepareToAddDaynightCalendar();
            TimeManager.ShortPause();

            //Input invalid inputs, e.g. required fields are null; duplicated name;  overlapped ranges
            TimeSettingsDayNight.AddTimeRanges(testData);
            TimeSettingsDayNight.FillInName(testData.InputData.CommonName);            

            //Click "Save" button.
            TimeSettingsDayNight.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsDayNight.IsModifyButtonDisplayed());

            Assert.IsTrue(TimeSettingsDayNight.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsDayNight.IsRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            //Click 'Cancel' button to quit the addition.
            TimeSettingsDayNight.ClickCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(TimeSettingsDayNight.IsCancelButtonDisplayed());
            TimeManager.ShortPause();
        }
        #endregion

        #region TestCase3 AddCommonFieldsIllegal
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementDayNight-Add-003")]
        [CaseID("TC-J1-FVT-TimeManagementDayNight-Add-003")]
        [Priority("6")]        
        [IllegalInputValidation(typeof(DayNightCalendarData[]))]
        public void AddCommonFieldsIllegal(DayNightCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsDayNight.PrepareToAddDaynightCalendar();
            TimeManager.ShortPause();

            //Input illegal inputs for common fields: name
            TimeSettingsDayNight.FillInName(testData.InputData.CommonName);

            //Click "Save" button.
            TimeSettingsDayNight.ClickSaveButton();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsDayNight.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsDayNight.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsDayNight.IsModifyButtonDisplayed());

            Assert.IsTrue(TimeSettingsDayNight.IsNameInvalidMsgCorrect(testData.ExpectedData));
            
            //Click 'Cancel' button to quit the addition.
            TimeSettingsDayNight.ClickCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(TimeSettingsDayNight.IsCancelButtonDisplayed());
            TimeManager.ShortPause();
        }
        #endregion
    }
}
