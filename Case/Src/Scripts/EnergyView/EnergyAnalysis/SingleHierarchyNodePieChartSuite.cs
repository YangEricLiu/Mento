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

namespace Mento.Script.EnergyView.EnergyAnalysis
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SingleHierarchyNode-PieChart-101"), CreateTime("2014-05-23"), Owner("Emma")]
    public class SingleHierarchyNodePieChartSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-PieChart-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodePieChartSuite), "TC-J1-FVT-SingleHierarchyNode-PieChart-101-1")]
        public void ViewPieChartOfTagThenClear(EnergyViewOptionData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 11, 1), new DateTime(2013, 11, 7));
            TimeManager.ShortPause();

            EnergyAnalysis.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTags(input.InputData.TagNames);
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());
            Assert.AreEqual(input.InputData.TagNames.Length, EnergyAnalysis.GetPiesNumber());
            Assert.AreEqual(input.InputData.TagNames, EnergyAnalysis.GetPieDataLabelTexts());
        }

    }
}
