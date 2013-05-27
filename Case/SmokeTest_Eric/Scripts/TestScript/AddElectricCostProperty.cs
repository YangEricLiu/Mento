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
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettings);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }

        [Test]
        [Owner("Eric")]
        [CaseID("TA-Smoke-Cost-001-001")]
        [MultipleTestDataSource(typeof(ElectricFixedCostData[]), typeof(AddElectricCostPropertySuite), "TA-Smoke-Cost-001-001")]
        public void AddCostForElectricFixed(ElectricFixedCostData input)
        {
            HierarchySetting.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.ShortPause();

            CostSettings.ClickCostPropertyTabButton();
            TimeManager.MediumPause();

            CostSettings.ClickCostCreateButton();
            TimeManager.ShortPause();

            CostSettings.ClickElectricCostCreateButton();
            TimeManager.ShortPause();

            CostSettings.FillInFixedCost(input.InputData);
            TimeManager.ShortPause();
            CostSettings.ClickCostSaveButton();
            TimeManager.ShortPause();

            Assert.AreEqual(CostSettings.GetElectricCostEffectiveDateValue(), input.ExpectedData.EffectiveDate);
            Assert.AreEqual(CostSettings.GetElectricPriceMode(), input.ExpectedData.PriceMode);
            Assert.AreEqual(CostSettings.GetElectricPriceValue(), input.ExpectedData.Price);
        }
    }
}
