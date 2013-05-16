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

namespace Mento.Script.TestScript.Usage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TA-Smoke-Energy-001")]
    [CreateTime("2013-05-13")]
    [Owner("Eric")]
    public class SingleTagSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            Mento.Framework.DataAccess.JazzDataInitializer.Initialize();
            JazzBrowseManager.OpenJazz();
            JazzFunction.LoginPage.LoginWithOption("PlatformAdmin", "P@ssw0rd", "Auto_Customer");


            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel DataPanel = JazzFunction.EnergyAnalysisPanel;

        /// <summary>
        /// 1.	Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	"
        ///     Successfully navigate to Energy Analysis window.
        /// 2.	select a hierarchy node	
        /// 3.	Go to Tag select panel, Select V(1)
        ///     The trend chart of selected V(1) display.
        /// 4.	Click "Save to dashboard"(保存到仪表盘), 
        ///     Click the dashboard addtion button "新增仪表盘"
        ///     Input valid dashboard name like "仪表盘_A1",and click save.
        ///     The widget is saved to the new dashboard successfully
        /// </summary>
        [Test]
        [CaseID("TA-Smoke-Energy-001-001")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleTagSuite), "TA-Smoke-Energy-001-001")]
        public void SingTagTrendChart(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);
            DataPanel.CheckTags(option.InputData.TagNames);
            DataPanel.Toolbar.ViewButtonClick();
            TimeManager.LongPause();
            TimeManager.LongPause();
            Assert.IsTrue(DataPanel.IsLegendDrawn());

            //save to dashboard
            var dashboard = option.InputData.DashboardInfo;
            DataPanel.Toolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
        }

        /// <summary>
        /// 1.	Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	"
        ///     Successfully navigate to Energy Analysis window.
        /// 2.	select a hierarchy node	
        /// 3.	Go to Tag select panel, Select V(1), click "Column chart", set date range to last month	
        ///     The Column chart of selected V(1) display.
        /// </summary>
        [Test]
        [CaseID("TA-Smoke-Energy-001-002")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleTagSuite), "TA-Smoke-Energy-001-002")]
        public void SingleTagColumnChart(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);
            DataPanel.CheckTags(option.InputData.TagNames);
            DataPanel.Toolbar.View(option.InputData.ViewType);
            TimeManager.LongPause();            
            Assert.IsTrue(DataPanel.IsLegendDrawn());
        }        

        [Test]
        [CaseID("TA-Smoke-Energy-001-003")]
        public void TestDatePicker()
        {
            DatePicker EnergyUsageStartDate = JazzDatePicker.EnergyUsageStartDateDatePicker;
            DatePicker EnergyUsageEndDate = JazzDatePicker.EnergyUsageEndDateDatePicker;

            
            EnergyUsageEndDate.SelectDateItem(new DateTime(2012, 01, 01));
            TimeManager.MediumPause();
            EnergyUsageStartDate.SelectDateItem(new DateTime(2012, 12, 31));
        }
    }
}
