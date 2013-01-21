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
    [CreateTime("2013-01-11")]
    [ManualCaseID("TC-J1-SmokeTest-020")]
    public class AddOtherCostProperty : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyElectricCostSettings CostSettings = JazzFunction.HierarchyElectricCostSettings;
        private static HierarchyOtherCostPropertySettings OtherCostSettings = JazzFunction.HierarchyOtherCostPropertySettings;

        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-020-001")]
        [Priority("P1")]
        [Type(ScriptType.BVT)]
        public void AddCostforGas()
        {
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.FocusOnHierarchyNode("AddPeopleProperty");
            TimeManager.ShortPause();
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();
            OtherCostSettings.ClickGasCostCreateButton();
            TimeManager.ShortPause();
            OtherCostSettings.SelectGasCostEffectiveDate(new DateTime(2012,6,7));
            TimeManager.ShortPause();
            OtherCostSettings.FillGasCostPrice("60");
            TimeManager.ShortPause();
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();
            Assert.AreEqual(OtherCostSettings.GetGasCostEffectiveDate(), "2012-06");
            Assert.AreEqual(OtherCostSettings.GetGasCostPrice(), "60");
        }
    }
}
