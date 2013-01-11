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
    [CreateTime("2013-01-10")]
    [ManualCaseID("TC-J1-SmokeTest-018")]
    public class AddElectricfixedCostProperty :TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyCostSettings CostSettings = JazzFunction.HierarchyCostSettings;

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
        [CaseID("TC-J1-SmokeTest-018-001")]
        [Priority("P1")]
        [Type("Smoke")]
        public void AddCostforElectricfixed()
        {
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.FocusOnHierarchyNode("AddPeopleProperty");
            TimeManager.ShortPause();
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();
            CostSettings.SelectElectricEffectiveDate(new DateTime(2013,1,5));
            CostSettings.SelectElectricPriceMode("固定电价");

        }
    }
}
