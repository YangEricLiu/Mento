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
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-07-22")]
    [ManualCaseID("TC-J1-FVT-TargetConfiguration-View-101")]
    public class ViewTargetBaselineCalendarSuite : TestSuiteBase
    {
        private static TagTargetBaselineSettings PVtagTargetBaselineSettings = JazzFunction.TagTargetBaselineSettings;
        private static PTagSettings PtagSettings = JazzFunction.PTagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            PVtagTargetBaselineSettings.TagTargetBaselineSettingsCaseSetUp();
        }

        [TearDown]
        public void CaseTearDown()
        {
            PVtagTargetBaselineSettings.TagTargetBaselineSettingsCaseTearDown();
        }

        private void PickupPtagOrVtag(KPITargetBaselineData input)
        {
            if (String.Equals(input.InputData.TagType, "Ptag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
                TimeManager.LongPause();
                PVtagTargetBaselineSettings.FocusOnPTagByName(input.InputData.TagName);
                TimeManager.MediumPause();
            }

            if (String.Equals(input.InputData.TagType, "Vtag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
                TimeManager.LongPause();
                PVtagTargetBaselineSettings.FocusOnVTagByName(input.InputData.TagName);
                TimeManager.MediumPause();
            } 
        }
      
        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-TargetConfiguration-View-101-1")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ViewTargetBaselineCalendarSuite), "TC-J1-FVT-TargetConfiguration-View-101-1")]
        public void NonAssocTagNoCalendar(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips[0]));
            //PVtagTargetBaselineSettings.GetCalendarFieldLabelText();
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-TargetConfiguration-View-101-2")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ViewTargetBaselineCalendarSuite), "TC-J1-FVT-TargetConfiguration-View-101-2")]
        public void AssocTagNoCalendar(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips[0]));
            //PVtagTargetBaselineSettings.GetCalendarFieldLabelText();
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-TargetConfiguration-View-101-3")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ViewTargetBaselineCalendarSuite), "TC-J1-FVT-TargetConfiguration-View-101-3")]
        public void AssocTagWithCalendar(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            string[] years = { "2010", "2011", "2012" }; 

            //selelct year
            PVtagTargetBaselineSettings.SelectYear(years[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips[0]));

            PVtagTargetBaselineSettings.SelectYear(years[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips[1]));

            PVtagTargetBaselineSettings.ClickBaselineCalendarInfoLinkButton();
            TimeManager.ShortPause();
            Assert.IsTrue(PVtagTargetBaselineSettings.IsCalendarInfoWindowDisplayed());
            Assert.IsTrue(PVtagTargetBaselineSettings.IsCalendarInfoCorrect(input.ExpectedData.CalendarInfoOnWindow));
            PVtagTargetBaselineSettings.CloseCalendarInfoWindow();

            PVtagTargetBaselineSettings.SelectYear(years[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips[1]));

            PVtagTargetBaselineSettings.ClickBaselineCalendarInfoLinkButton();
            TimeManager.ShortPause();
            Assert.IsTrue(PVtagTargetBaselineSettings.IsCalendarInfoWindowDisplayed());
            Assert.IsTrue(PVtagTargetBaselineSettings.IsCalendarInfoCorrect(input.ExpectedData.CalendarInfoOnWindow));
            PVtagTargetBaselineSettings.CloseCalendarInfoWindow();
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-TargetConfiguration-View-101-4")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ViewTargetBaselineCalendarSuite), "TC-J1-FVT-TargetConfiguration-View-101-4")]
        public void AssocTagWithOtherCalendar(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            string[] years = { "2011", "2012", "2013" };
    
            //selelct year
            PVtagTargetBaselineSettings.SelectYear(years[0]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips[0]));

            PVtagTargetBaselineSettings.SelectYear(years[1]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips[1]));

            PVtagTargetBaselineSettings.ClickBaselineCalendarInfoLinkButton();
            TimeManager.ShortPause();
            Assert.IsTrue(PVtagTargetBaselineSettings.IsCalendarInfoWindowDisplayed());
            Assert.IsTrue(PVtagTargetBaselineSettings.IsCalendarInfoCorrect(input.ExpectedData.CalendarInfoOnWindow));
            PVtagTargetBaselineSettings.CloseCalendarInfoWindow();

            PVtagTargetBaselineSettings.SelectYear(years[2]);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips[1]));

            PVtagTargetBaselineSettings.ClickBaselineCalendarInfoLinkButton();
            TimeManager.ShortPause();
            Assert.IsTrue(PVtagTargetBaselineSettings.IsCalendarInfoWindowDisplayed());
            Assert.IsTrue(PVtagTargetBaselineSettings.IsCalendarInfoCorrect(input.ExpectedData.CalendarInfoOnWindow));
            PVtagTargetBaselineSettings.CloseCalendarInfoWindow();
        } 
    }
}
