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

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2012-12-31")]
    [ManualCaseID("TC-J1-SmokeTest-019")]
    public class AddCalendarProperty : TestSuiteBase
    {
        private static Mento.ScriptCommon.Library.Functions.HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;
        private static HierarchyPropertySettings HPropertySettings = JazzFunction.HierarchyPropertySettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-017")]
        public void AddCalendarforWorkday()
        {
            HierarchySettings.ExpandNode("自动化测试");
            HierarchySettings.FocusOnHierarchyNode("AddCalendarProperty");

            HPropertySettings.ClickCalendarTab();
            TimeManager.ShortPause();
            HPropertySettings.ClickCreateCalendarButton();
            TimeManager.ShortPause();

            HPropertySettings.ClickWorkdayCreateButton();
            TimeManager.ShortPause();

            HPropertySettings.SelectWorkdayEffectiveYear("2002",1);
            HPropertySettings.SelectWorkdayCalendarName("foraddcalendar1",1);
            TimeManager.MediumPause();
            HPropertySettings.ClickAddWorktimeLinkButton();
            TimeManager.ShortPause();
        }
    }
}
