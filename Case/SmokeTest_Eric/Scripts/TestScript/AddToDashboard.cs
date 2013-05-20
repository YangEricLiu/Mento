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
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }

        private static EnergyAnalysisPanel DataPanel = JazzFunction.EnergyAnalysisPanel;
       
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
            
            var dashboard = option.InputData.DashboardInfo;
            DataPanel.Toolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
        }

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
