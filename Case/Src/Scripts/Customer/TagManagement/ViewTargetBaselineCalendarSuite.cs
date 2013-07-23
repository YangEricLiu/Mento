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
        }
      
        [Test]
        [CaseID("TC-J1-FVT-TargetConfiguration-View-101-1")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(ViewTargetBaselineCalendarSuite), "TC-J1-FVT-TargetConfiguration-View-101-1")]
        public void NonAssocTagNoCalendar(KPITargetBaselineData input)
        {
            if (String.Equals(input.InputData.TagType, "Ptag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsP);
            }

            if (String.Equals(input.InputData.TagType, "Vtag"))
            {
                JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TagSettingsV);
            }

            PVtagTargetBaselineSettings.FocusOnTagByName(input.InputData.TagName);
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.SwitchToTargetPropertyTab();
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            PVtagTargetBaselineSettings.SelectYear(input.InputData.Year);
            TimeManager.ShortPause();

          
        }       
    }
}
