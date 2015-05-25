using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.Library.Functions;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.Script;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.EnergyView;
using Mento.TestApi.TestData;
using System.Data;
using Mento.Utility;

namespace Mento.Script.System.Example
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-PredefinedTimeDataVerification-DataView-101"), CreateTime("2014-04-16"), Owner("Emma")]
    public class PopTestSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            
        }

        [TearDown]
        public void CaseTearDown()
        {
            TestAssemblyInitializer.Desctuct();  
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static CarbonUsagePanel CarbonUsage = JazzFunction.CarbonUsagePanel;
        private static CostPanel CostUsage = JazzFunction.CostPanel;
        private static RatioPanel RadioPanel = JazzFunction.RatioPanel;
        private static UnitKPIPanel UnitKPIPanel = JazzFunction.UnitKPIPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        private static IndustryLabellingPanel IndustryLabellingPanel = JazzFunction.IndustryLabellingPanel;
        private static RankPanel CorporateRanking = JazzFunction.RankPanel;

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-1")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(PopTestSuite), "TC-J1-Example-002")]
        public void PopTreeOperation01(SmokeTestEnergyViewData input)
        {
            //open pop and login
            JazzBrowseManager.OpenJazz();
            TimeManager.Pause(5000);

            JazzTextField.PopLoginUserNameTextField.Fill("SchneiderElectricChina");
            JazzTextField.PopLoginPasswordTextField.Fill("P@ssw0rdChina");

            JazzButton.PopLoginSubmitButton.Click();
            JazzButton.PopMenuButtonCustomer.WaitControlDisplayed(60);
            TimeManager.Pause(5000);

            //Select customer and confirm
            JazzButton.PopMenuButtonCustomer.SelectItem("NancyCustomer12");
            TimeManager.LongPause();

            JazzButton.PopbButtonConfirm.Click();
            TimeManager.Pause(10000);

            string[] nodePath = { "NancyCustomer12", "园区测试多层级", "楼宇BC" };
            JazzTreeView.PopHierarchyTree.Pop_SelectNode(nodePath);
        }

        [Test]
        [CaseID("TC-J1-FVT-SmokeTestEnergyView-101-1")]
        [MultipleTestDataSource(typeof(SmokeTestEnergyViewData[]), typeof(PopTestSuite), "TC-J1-Example-002")]
        public void PopTreeOperation02(SmokeTestEnergyViewData input)
        {
            //open pop and login
            JazzBrowseManager.OpenJazz();
            TimeManager.Pause(5000);

            JazzTextField.PopLoginUserNameTextField.Fill("SchneiderElectricChina");
            JazzTextField.PopLoginPasswordTextField.Fill("P@ssw0rdChina");

            JazzButton.PopLoginSubmitButton.Click();
            JazzButton.PopMenuButtonCustomer.WaitControlDisplayed(60);
            TimeManager.Pause(5000);

            JazzButton.PopbButtonConfirm.Click();
            TimeManager.Pause(10000);

            JazzButton.PopButtonUserManagement.Click();
            TimeManager.LongPause();

            JazzButton.PopButtonAddUser.Click();
            TimeManager.LongPause();

            JazzComboBox.PopComboBoxPosition.Pop_SelectItem("部门经理");
            TimeManager.LongPause();
        }

    }
}
