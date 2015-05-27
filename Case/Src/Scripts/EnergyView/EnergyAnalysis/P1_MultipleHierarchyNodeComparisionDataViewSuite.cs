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
    [Category("P2_Emma")]
    [ManualCaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101"), CreateTime("2013-08-08"), Owner("Emma")]
    public class P1_MultipleHierarchyNodeComparisionDataViewSuite : TestSuiteBase
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

            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        [Test]
        [Category("P1_Emma")]
        [CaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(P1_MultipleHierarchyNodeComparisionDataViewSuite), "TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-1")]
        public void MultipleHierarchyNodeComparisionDataView01(EnergyViewOptionData input)
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
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

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
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

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
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

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
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);

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
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[4], input.InputData.failedFileName[4]);

            //Open "多层级数据点" again
            EnergyAnalysis.ClickMultipleHierarchyAddTagsButton();
            TimeManager.MediumPause();

            //verify all left tags in this hierarchy or other hierarchy, Still can check more tags for 1.6 version 30 tags checked
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
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[5], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5]);

            #region Save dashboard ignore on 2.0
            /*下面的代码检测的仪表盘保存，以后的逻辑不同，2.0主要是看数据，仪表盘由手动方式验证
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
            //Assert.IsTrue(HomePagePanel.CompareMinWidgetDataView(EnergyAnalysis.EAPath, input.ExpectedData.expectedFileName[5], input.InputData.failedFileName[5], dashboard.WigetName));
            
             */ 
            #endregion
        }

        [Test]
        [Category("P2_Emma")]
        [CaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-2")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(P1_MultipleHierarchyNodeComparisionDataViewSuite), "TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-2")]
        public void MultipleHierarchyNodeComparisionDataView02(EnergyViewOptionData input)
        {
            //Go to NancyCustomer1->园区测试多层级-〉BuildingCalculationType
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 2, 1));
            EnergyViewToolbar.SetTimeRange("00:00", "14:00");

            TimeManager.ShortPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTags(input.InputData.TagNames);
            TimeManager.ShortPause();
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Month);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[3], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[3], input.InputData.failedFileName[3]);
        }

        //自动化用的是28版本的chrome，当有4个点获取7天的分钟数据，会由于网页脚本占用内存过多而停止，先忽略这个脚本
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-3")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(P1_MultipleHierarchyNodeComparisionDataViewSuite), "TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-3")]
        public void RawValueDisplay(EnergyViewOptionData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            //Go to Multiple hierarchy noe. Select Hierarchy list to 组织A->园区A->楼宇A.
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Change manually defined time range to 2012/07/29-2012/08/04. 
            EnergyViewToolbar.SetDateRange(input.InputData.ManualTimeRange[0].StartDate, input.InputData.ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Select BuildingA_P1_Electricity to display Data view. Click Optional step=Raw step.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Min);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Select  BuildingA_P2_Water to display Data view.
            //Select  BuildingA_P3_Coal to display Data view.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            TimeManager.ShortPause();
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            TimeManager.ShortPause();
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Raw chart display successfully.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Min));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            #region Not use code, for save to dashboard which will test on manual for 2.0
            /*
            //Select other hierarchy node of 组织A->园区A->楼宇D.
            EnergyAnalysis.SelectHierarchy(input.InputData.MultiSelectedHiearchyPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select tag BuildingA_KT_P1_Electricy.    
            EnergyAnalysis.CheckTag(input.InputData.TagNames[3]);
            TimeManager.ShortPause();
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Min);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Click "Save to dashboard"（保存到仪表盘）to save the Data view to Hierarchy node dashboard.
            var dashboard = input.InputData.DashboardInfo;
            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard.WigetName, dashboard.HierarchyName, dashboard.IsCreateDashboard, dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();

            //On homepage, check the dashboard
            EnergyAnalysis.NavigateToAllDashBoards();
            HomePagePanel.SelectHierarchyNode(dashboard.HierarchyName);
            TimeManager.Pause(5000);
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            //check The Data view Save to dashboard successfully.
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            */
            #endregion
        }
    }
}
