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
        [SetUp]
        public void CaseSetUp()
        {
            PVtagTargetBaselineSettings.NavigatorToTagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private void PickupPtagOrVtag(KPITargetBaselineData input)
        {
            if (String.Equals(input.InputData.TagType, "Ptag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
                PVtagTargetBaselineSettings.FocusOnPTagByName(input.InputData.TagName);
                TimeManager.MediumPause();
            }

            if (String.Equals(input.InputData.TagType, "Vtag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
                PVtagTargetBaselineSettings.FocusOnVTagByName(input.InputData.TagName);
                TimeManager.MediumPause();
            }
            
        }
      
        [Test]
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

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips));
            //PVtagTargetBaselineSettings.GetCalendarFieldLabelText();
        }

        [Test]
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

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips));
            //PVtagTargetBaselineSettings.GetCalendarFieldLabelText();
        }

        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-View-101-3")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ViewTargetBaselineCalendarSuite), "TC-J1-FVT-TargetConfiguration-View-101-3")]
        public void AssocTagWithCalendar(KPITargetBaselineData input)
        {
            PickupPtagOrVtag(input);

            PVtagTargetBaselineSettings.SwitchToBaselinePropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            //string 
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            Assert.IsTrue(PVtagTargetBaselineSettings.GetCalendarFieldLabelText().Contains(input.ExpectedData.CalendarInfoTips));
            //PVtagTargetBaselineSettings.GetCalendarFieldLabelText();
        } 
    }
}
