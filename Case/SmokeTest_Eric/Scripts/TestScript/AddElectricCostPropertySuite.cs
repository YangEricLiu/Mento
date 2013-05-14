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
using Mento.ScriptCommon.TestData.SmokeTest;
using Mento.TestApi.TestData;

namespace Mento.Script.TestScript.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-13")]
    [ManualCaseID("TA-Smoke-Cost-001")]
    public class AddElectricCostPropertySuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyElectricCostSettings CostSettings = JazzFunction.HierarchyElectricCostSettings;

        [SetUp]
        public void CaseSetUp()
        {
            Mento.Framework.DataAccess.JazzDataInitializer.Initialize();
            JazzBrowseManager.OpenJazz();
            JazzFunction.LoginPage.LoginWithOption("PlatformAdmin", "P@ssw0rd", "Auto_Customer");


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
        [CaseID("TA-Smoke-Cost-001-001")]
        [Priority("35")]
        [Type("BVT")]
        [MultipleTestDataSource(typeof(ElectricFixedCostData[]), typeof(AddElectricCostPropertySuite), "TA-Smoke-Cost-001-001")]
        public void AddCostForElectricFixed(ElectricFixedCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
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
            CostSettings.FillInFixedCost(input.InputData);
            TimeManager.ShortPause();
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            //Verify the input value displayed correct
            Assert.AreEqual(CostSettings.GetElectricCostEffectiveDateValue(), input.ExpectedData.EffectiveDate);
            Assert.AreEqual(CostSettings.GetElectricPriceMode(), input.ExpectedData.PriceMode);
            Assert.AreEqual(CostSettings.GetElectricPriceValue(), input.ExpectedData.Price);
        }
    }
}
