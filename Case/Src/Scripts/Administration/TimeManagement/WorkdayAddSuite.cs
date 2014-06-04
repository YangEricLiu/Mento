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
    public class WorkdayAddSuite : TestSuiteBase
    {
        private static TimeSettingsWorkday TimeSettingsWorkday = JazzFunction.TimeSettingsWorkday;
        [SetUp]
        public void CaseSetUp()
        {
            TimeSettingsWorkday.NavigatorToWorkdayCalendarSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {

            TimeManager.MediumPause();
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorktime);
            //TimeManager.MediumPause();
        }

        #region TestCase1 AddValidWorkday
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Add-101")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Add-101")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayAddSuite), "TC-J1-FVT-TimeManagementWorkday-Add-101")]
        public void AddValidWorkday(WorkdayCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeManager.ShortPause();

            //Verify the label text
            Assert.IsTrue(TimeSettingsWorkday.IsWorkdayCalendarTextCorrect(testData.ExpectedData.LabelText));
            
            //Input valid name
            TimeSettingsWorkday.FillInName(testData.InputData.CommonName);

            //Add special dates (including type and time range).
            TimeSettingsWorkday.AddSpecialDates(testData);

            //Click "Save" button
            TimeSettingsWorkday.ClickSaveButton();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify saved successfully.
            Assert.IsFalse(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.ExpectedData.CommonName));                      

            //Verify special dates are added successfully.        
            Assert.AreEqual(testData.InputData.SpecialDate.Length, TimeSettingsWorkday.GetSpecialDateItemsNumber());
            for (int elementPosition = 1; elementPosition <= testData.InputData.SpecialDate.Length; elementPosition++)
            {
                int inputDataArrayPosition = testData.InputData.SpecialDate.Length - elementPosition;
                Assert.AreEqual(testData.InputData.SpecialDate[inputDataArrayPosition].Type, TimeSettingsWorkday.GetSpecialDateTypeValue(elementPosition));
                Assert.AreEqual(testData.InputData.SpecialDate[inputDataArrayPosition].StartMonth, TimeSettingsWorkday.GetStartMonthValue(elementPosition));
                Assert.AreEqual(testData.InputData.SpecialDate[inputDataArrayPosition].StartDate, TimeSettingsWorkday.GetStartDateValue(elementPosition));
                Assert.AreEqual(testData.InputData.SpecialDate[inputDataArrayPosition].EndMonth, TimeSettingsWorkday.GetEndMonthValue(elementPosition));
                Assert.AreEqual(testData.InputData.SpecialDate[inputDataArrayPosition].EndDate, TimeSettingsWorkday.GetEndDateValue(elementPosition));
            }
        }
        #endregion

        #region TestCase2 AddNoSpecialDate
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Add-102")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Add-102")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayAddSuite), "TC-J1-FVT-TimeManagementWorkday-Add-102")]
        public void AddNoSpecialDate(WorkdayCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeManager.ShortPause();

            //Input valid name
            TimeSettingsWorkday.FillInName(testData.InputData.CommonName);            

            //Click "Save" button without any special date
            TimeSettingsWorkday.ClickSaveButton();
            TimeManager.MediumPause();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify saved successfully.
            Assert.IsFalse(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));
            
            //Verify the label text
            Assert.IsTrue(TimeSettingsWorkday.IsWorkdayCalendarTextCorrect(testData.ExpectedData.LabelText));
            
            //Verify there is no any special date added.
            Assert.AreEqual(testData.InputData.SpecialDate.Length, TimeSettingsWorkday.GetSpecialDateItemsNumber());
        }
        #endregion

        #region TestCase1 AddWorkdayCancelled
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Add-001")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Add-001")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayAddSuite), "TC-J1-FVT-TimeManagementWorkday-Add-001")]
        public void AddWorkdayCancelled(WorkdayCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeManager.ShortPause();

            //Click "Cancel" button directly without any input.
            TimeSettingsWorkday.ClickCancelButton();
            TimeManager.ShortPause();

            //Click '+ Calendar' button again
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeManager.ShortPause();

            //Input valid input
            TimeSettingsWorkday.FillInName(testData.InputData.CommonName);

            //Click "Cancel" button
            TimeSettingsWorkday.ClickCancelButton();
            TimeManager.ShortPause();

            //verify that the addition is cancelled and NOT exists in the list.
            Assert.IsFalse(TimeSettingsWorkday.IsCalendarExist(testData.InputData.CommonName));
            Assert.IsFalse(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorkday.IsCancelButtonDisplayed());

            //Click '+ Calendar' button again
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeManager.ShortPause();

            //verify that the previous input has been cleared.
            Assert.AreEqual(testData.ExpectedData.CommonName, TimeSettingsWorkday.GetNameValue());

            //Click "Cancel" button
            TimeSettingsWorkday.ClickCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(TimeSettingsWorkday.IsCancelButtonDisplayed());
        }
        #endregion

        #region TestCase2 AddInvalidWorkday
        [Test]
        [ManualCaseID("TC-J1-FVT-TimeManagementWorkday-Add-002")]
        [CaseID("TC-J1-FVT-TimeManagementWorkday-Add-002")]
        [Priority("6")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(WorkdayAddSuite), "TC-J1-FVT-TimeManagementWorkday-Add-002")]
        public void AddInvalidWorkday(WorkdayCalendarData testData)
        {
            //Click '+ Calendar' button.
            TimeSettingsWorkday.PrepareToAddWorkdayCalendar();
            TimeManager.ShortPause();

            //Input invalid inputs, e.g. required fields are null; duplicated name;  overlapped ranges            
            TimeSettingsWorkday.AddSpecialDates(testData);
            TimeManager.ShortPause();

            TimeSettingsWorkday.FillInName(testData.InputData.CommonName);
            TimeManager.ShortPause();

            //Click "Save" button.
            TimeSettingsWorkday.ClickSaveButton();
            TimeManager.LongPause();            

            //verify that the saving is failed and error messages are displayed below the fields.
            Assert.IsTrue(TimeSettingsWorkday.IsSaveButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsCancelButtonDisplayed());
            Assert.IsFalse(TimeSettingsWorkday.IsModifyButtonDisplayed());
            Assert.IsTrue(TimeSettingsWorkday.IsNameInvalidMsgCorrect(testData.ExpectedData));
            Assert.IsTrue(TimeSettingsWorkday.IsTypeInvalidMsgCorrect(testData.ExpectedData, 1));
            Assert.IsTrue(TimeSettingsWorkday.IsRangeInvalidMsgCorrect(testData.ExpectedData, 1));

            //Click 'Cancel' button to quit the addition.
            TimeSettingsWorkday.ClickCancelButton();
            TimeManager.ShortPause();
            Assert.IsFalse(TimeSettingsWorkday.IsCancelButtonDisplayed());
        }
        #endregion
    }
}
