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
    public class AddElectricfixedCostPropertySuite :TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyElectricCostSettings CostSettings = JazzFunction.HierarchyElectricCostSettings;

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
        [CaseID("TC-J1-SmokeTest-018-001")]
        [Priority("35")]
        [Type(ScriptType.BVT)]
        public void AddCostforElectricfixed()
        {
            /// <summary>
            /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"/"AddPeopleProperty"
            /// </summary>  
            ///
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.FocusOnHierarchyNode("AddPeopleProperty");
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "电力"
            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();

            //select effective year and input value, save it
            CostSettings.SelectElectricEffectiveDate(new DateTime(2013,1,5));
            CostSettings.SelectElectricPriceMode("固定电价");
            CostSettings.FillElectricPrice("50");
            TimeManager.ShortPause();
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.AreEqual(CostSettings.GetElectricCostEffectiveDateValue(), "2013-01");
            Assert.AreEqual(CostSettings.GetElectricPriceMode(), "固定电价");
            Assert.AreEqual(CostSettings.GetElectricPriceValue(), "50");
        }
    }
}
