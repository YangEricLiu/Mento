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
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-01-11")]
    [ManualCaseID("TC-J1-SmokeTest-020")]
    public class AddOtherCostPropertySuite : TestSuiteBase
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

        /// <summary>
        /// Precondition: 1. make sure there is hierarchy path "自动化测试"/"AddCalendarProperty"/"AddPeopleProperty"
        /// </summary>  
        ///
        [Test]
        [CaseID("TC-J1-SmokeTest-020-001")]
        [Priority("37")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(OtherCostData[]), typeof(AddOtherCostPropertySuite), "TC-J1-SmokeTest-020-001")]
        public void AddCostforGas(OtherCostData testData)
        { 
            //Select buidling node "AddPeopleProperty"
            HierarchySetting.ExpandNode("自动化测试");
            HierarchySetting.ExpandNode("AddCalendarProperty");
            HierarchySetting.SelectHierarchyNode("AddPeopleProperty");
            TimeManager.ShortPause();

            //Click "成本属性" tab button
            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();

            //Click "+成本属性" button
            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            //Click "+" before "天然气"
            OtherCostSettings.ClickGasCostCreateButton();
            TimeManager.ShortPause();

            //select effective year and input value, save it
            OtherCostSettings.FillInGasCostValue(testData.InputData);
            TimeManager.ShortPause();
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.AreEqual(OtherCostSettings.GetGasCostEffectiveDate(), "2012-06");
            Assert.AreEqual(OtherCostSettings.GetGasCostPrice(), "60");
        }
    }
}
