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
    [ManualCaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101"), CreateTime("2013-08-06"), Owner("Emma")]
    public class SingleHierarchyNodeDataViewSuite : TestSuiteBase
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
            //JazzFunction.Navigator.NavigateHome();
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();

            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeDataViewSuite), "TC-J1-FVT-SingleHierarchyNode-DataView-101-1")]
        public void ViewDataViewOfTagThenClear(EnergyViewOptionData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            
            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();
            
            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);

            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Uncheck v1, and select another tag under area dimension
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.SwitchTagTab(TagTabs.AreaDimensionTab);
            EnergyAnalysis.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);

            //Uncheck v2, and select another tag under system dimension
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[1]);
            EnergyAnalysis.SwitchTagTab(TagTabs.SystemDimensionTab);
            EnergyAnalysis.SelectSystemDimension(input.InputData.SystemDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[2], DisplayStep.Default);
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[2], input.InputData.failedFileName[2]);

            //Uncheck v3 with clear all data
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.ShortPause();
            Assert.IsTrue(EnergyAnalysis.IsAllGridTagsUnchecked());
        }

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101-2")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeDataViewSuite), "TC-J1-FVT-SingleHierarchyNode-DataView-101-2")]
        public void DataViewSaveToDashBoard(EnergyViewOptionData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            //Check tag V_Null_BuildingBC and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            //Assert.IsTrue(EnergyAnalysis.IsNoDataInEnergyGrid());

            //Uncheck tag V_Null_BuildingBC, and select another tag v14
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            Assert.IsTrue(EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]));

            #region Not use code, for save to dashboard which will test on manual for 2.0
            /*
            //Save to dashboard
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
           
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            */
            #endregion
        }

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101-3")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeDataViewSuite), "TC-J1-FVT-SingleHierarchyNode-DataView-101-3")]
        public void DataViewWithOtherCalcualtionType(EnergyViewOptionData input)
        {
            //On hierarchy node,NancyCustomer1/园区测试多层级/BuildingMulCalculationType
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            //Check tag V_Null_BuildingBC and view data view
            EnergyAnalysis.CheckTags(input.InputData.TagNames);
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]));

            #region Not use code, for save to dashboard which will test on manual for 2.0

            /*
            //Save to dashboard
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

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            */

            #endregion
        }

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101-5359")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeDataViewSuite), "TC-J1-FVT-SingleHierarchyNode-DataView-101-5359")]
        public void EnergyAnalysisRawDataDisplay_5359(EnergyViewOptionData input)
        {
            //Go to CathyRawData -〉Select 原始数据楼A.
            HomePagePanel.SelectCustomer("CathyRawData");
            TimeManager.LongPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            TimeManager.MediumPause();

            //Select time range 2014/01/01 to 2014/01/21.
            var ManualTimeRange = input.InputData.ManualTimeRange;
            EnergyViewToolbar.SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //3. Select optional step=Raw step.
            //4. Click 查看数据.
            JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Min);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Raw data should be display well.
            Assert.IsTrue(EnergyAnalysis.IsDataViewDrawn());
        }

        [Test]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101-4")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeDataViewSuite), "TC-J1-FVT-SingleHierarchyNode-DataView-101-4")]
        public void RawValueDisplay(EnergyViewOptionData input)
        {
            HomePagePanel.SelectCustomer("NancyCostCustomer2");
            TimeManager.LongPause();
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(input.InputData.ManualTimeRange[0].StartDate,input.InputData.ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            //Select BuildingA_P1_Electricity to display Data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Click Optional step=Raw step.
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Min);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            TimeManager.LongPause();

            //Check Raw chart display successfully.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Min));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));

            //Select  BuildingA_P2_Water to display Data view.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Raw chart display successfully.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Min));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));

            //Select  BuildingA_P3_Coal to display Data view.
            EnergyAnalysis.CheckTag(input.InputData.TagNames[2]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check Raw chart display successfully.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Min));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));

            //Check value 
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            #region Not use code, for save to dashboard which will test on manual for 2.0
            /*
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

        //忽略的原因是有predefine的时间段，值不确定
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-DataView-101-5")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeDataViewSuite), "TC-J1-FVT-SingleHierarchyNode-DataView-101-5")]
        public void SingleHie30Tagslimit(EnergyViewOptionData input)
        {
            //Go to NancyCustomer1->园区测试多层级-> BuildingPieVerify. 
            HomePagePanel.SelectCustomer("NancyCustomer1");
            TimeManager.LongPause();
            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();

            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Select time range=上个月
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);
            TimeManager.ShortPause();

            //Select Totally 30 tags Vpie1 to Vpie30 .
            for (int i = 1; i < 31; i++ )
            {
                EnergyAnalysis.CheckTag("Vpie"+i.ToString());
            }

            //view dataview.
            EnergyViewToolbar.View(EnergyViewType.List);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check · The data view is can draw with totally 30 tags.
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);

            //Change to trend chart view.
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check · The trend chart show 30 lines correctly.
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[1], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[1], input.InputData.failedFileName[1]);
        }
    }
}
