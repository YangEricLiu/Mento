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
    [ManualCaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-PieChart-101"), CreateTime("2014-05-30"), Owner("Emma")]
    public class MultipleHierarchyNodeComparisionPieChartSuite : TestSuiteBase
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
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        //private static 

        [Test]
        [CaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-PieChart-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(MultipleHierarchyNodeComparisionPieChartSuite), "TC-J1-FVT-MultipleHierarchyNodeComparision-PieChart-101-1")]
        public void MultipleHierarchyNodeComparisionPieChart(EnergyViewOptionData input)
        {
            List<MultipleHierarchyAndtags> tmpMultipleHierarchyAndtags = new List<MultipleHierarchyAndtags>();

            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            //Select the BuildingBC node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis.
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);

            //Select V(2) under Area dimension node to draw Distribution chart.
            MultiHieCompareWindow.SwitchTagTab(TagTabs.AreaDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[0].TagsName[0]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //Time range = 2013-1-1 to 2013-1-7 07:00 to 16:00
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            EnergyViewToolbar.SetTimeRange(ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            //Check tag and view pie chart
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDictionaryForMultipleHierarchyToExcel(ManualTimeRange[0], input.ExpectedData.expectedFileName[0]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            
            //Open "+数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            //Keep V(2) checked,  click "添加对比层级节点 " and select V(13) to draw Distribution chart.
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[0].HierarchyPath);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());

            //·Message show 新增数据点与已绘制数据点介质不同，无法共同绘制饼状图！
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.NotDrawPieMessage));

            //After click "好".
            JazzMessageBox.MessageBox.OK();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //· Back to V(2) distribution chart.
            Assert.IsTrue(EnergyAnalysis.IsDistributionChartDrawn());
            EnergyAnalysis.CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
            
            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            //Pick V11 from default all tags and confirm,then check the data view
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.MultipleHierarchyAndtags[1].HierarchyPath);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[0]);
            MultiHieCompareWindow.CheckTag(input.InputData.MultipleHierarchyAndtags[1].TagsName[1]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //Check tag and view pie chart
            EnergyViewToolbar.View(EnergyViewType.Distribute);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            TimeManager.LongPause();

            EnergyAnalysis.ExportExpectedDictionaryForMultipleHierarchyToExcel(ManualTimeRange[0], input.ExpectedData.expectedFileName[1]);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDictionaryDataForMultipleHierarchyOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            /*
            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            //Pick other 6 tags from default all tags and confirm,then check the data view
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTags(input.InputData.MultiHieTagNames);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsScrollbarExist());
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            Assert.AreEqual(9, EnergyAnalysis.GetTrendChartLines());

            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.LongPause();

            //Pick one more tag without data from default all tags and confirm,then check the data view
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[3]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsScrollbarExist());
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            Assert.AreEqual(9, EnergyAnalysis.GetTrendChartLines());

            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            //verify all left tags in this hierarchy or other hierarchy, can check more, until 30 tags
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(MultiHieCompareWindow.IsNoEnabledCheckbox());

            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(MultiHieCompareWindow.IsNoEnabledCheckbox());

            MultiHieCompareWindow.SwitchTagTab(TagTabs.AreaDimensionTab);
            MultiHieCompareWindow.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsFalse(MultiHieCompareWindow.IsNoEnabledCheckbox());

            //uncheck "V_Null_BuildingBC" and veirfy that all chechbox are enabled
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.UncheckTag(input.InputData.TagNames[3]);
            Assert.IsTrue(MultiHieCompareWindow.IsAllEnabledCheckbox());

            //Check another tag "V19_BuildingBC" and save to dashboard
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[4]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsScrollbarExist());
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            */
        }
    }
}
