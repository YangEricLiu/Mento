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

namespace Mento.Script.Administration.Calendar
{
    [TestFixture]
    [ManualCaseID("TC-J1-SmokeTest-027")]
    public class TimeManagementSuite: TestSuiteBase
    {
        //private TimeManagement TimeManagement = JazzFunction.PTagSettings;
        [SetUp]
        public void ScriptSetUp()
        {
            //TimeManagementSuite.NavigatorToWorkdayCalendarSetting();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.TimeSettingsWorkday);
        }

        [TearDown]
        public void ScriptTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-027"), CreateTime("2013-01-04"), Owner("Amy")]
        [MultipleTestDataSource(typeof(WorkdayCalendarData[]), typeof(TimeManagementSuite), "TC-J1-SmokeTest-027")]
        public void AddWorkdayCalendar()
        { 
            

        }

    }
}
