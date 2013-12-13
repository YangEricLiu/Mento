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
    [ManualCaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101"), CreateTime("2013-08-08"), Owner("Emma")]
    public class MultipleHierarchyNodeComparisionDataViewSuite : TestSuiteBase
    {
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

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

        [Test]
        [CaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(MultipleHierarchyNodeComparisionDataViewSuite), "TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-1")]
        public void MultipleHierarchyNodeComparisionDataView(EnergyViewOptionData input)
        {
            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);

            //Switch to "area dimension" and pick V2_BuildingBC
            MultiHieCompareWindow.SwitchTagTab(TagTabs.AreaDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();

            MultiHieCompareWindow.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            //Check tag and view data view
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            Assert.IsTrue(EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]));

            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            //Pick V2 from default all tags and confirm,then check the data view
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[1]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]));

            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            //Pick V11 from default all tags and confirm,then check the data view
            string[] hierarchyPath2 = { "NancyCustomer1", "园区测试多层级", "楼宇BAD" };
            MultiHieCompareWindow.SelectHierarchyNode(hierarchyPath2);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            MultiHieCompareWindow.CheckTag(input.InputData.TagNames[2]);
            TimeManager.ShortPause();
            MultiHieCompareWindow.ClickConfirmButton();
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]));

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
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]));

            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

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
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[4], DisplayStep.Default);
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]));

            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            //verify all left tags in this hierarchy or other hierarchy, can't check one more
            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
            MultiHieCompareWindow.SwitchTagTab(TagTabs.HierarchyTag);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(MultiHieCompareWindow.IsNoEnabledCheckbox());

            MultiHieCompareWindow.SwitchTagTab(TagTabs.SystemDimensionTab);
            MultiHieCompareWindow.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(MultiHieCompareWindow.IsNoEnabledCheckbox());

            MultiHieCompareWindow.SwitchTagTab(TagTabs.AreaDimensionTab);
            MultiHieCompareWindow.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(MultiHieCompareWindow.IsNoEnabledCheckbox());

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
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]));

            var dashboard = input.InputData.DashboardInfo;
            EnergyViewToolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);

            //On homepage, check the dashboard
            HomePagePanel.NavigateToAllDashboard();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.MediumPause();
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            Assert.IsTrue(HomePagePanel.CompareMinWidgetDataView(EnergyAnalysis.EAPath, input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5], dashboard.WigetName));
        }
    }
}
