﻿using System;
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
    [ManualCaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101"), CreateTime("2013-07-31"), Owner("Emma")]
    public class SingleHierarchyNodeTrendChartSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            EnergyAnalysis.NavigateToEnergyAnalysis();
            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.UnitKPI);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
            //HomePagePanel.ExitJazz();

            //JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "NancyCustomer1");
            //TimeManager.MediumPause();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        //2.0测试的时候忽略，这版主要是验证数据的正确性
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeTrendChartSuite), "TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        public void NoDataCompare_ViewLineChartOfTagThenClear(EnergyViewOptionData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();
            
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            EnergyAnalysis.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            Assert.AreEqual(1, EnergyAnalysis.GetTrendChartLines());

            //Uncheck v1, and select another tag under area dimension
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.SwitchTagTab(TagTabs.AreaDimensionTab);
            EnergyAnalysis.SelectAreaDimension(input.InputData.AreaDimensionPath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            Assert.AreEqual(1, EnergyAnalysis.GetTrendChartLines());

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
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            Assert.AreEqual(1, EnergyAnalysis.GetTrendChartLines());

            //Uncheck v3 with clear all data
            EnergyViewToolbar.SelectMoreOption(EnergyViewMoreOption.DeleteAll);
            TimeManager.ShortPause();
            Assert.IsTrue(JazzMessageBox.MessageBox.GetMessage().Contains(input.ExpectedData.ClearAllMessage));
            JazzMessageBox.MessageBox.Clear();
            TimeManager.ShortPause();
            Assert.IsTrue(EnergyAnalysis.IsAllGridTagsUnchecked());
        }

        //2.0测试的时候忽略，这版主要是验证数据的正确性
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101-2")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeTrendChartSuite), "TC-J1-FVT-SingleHierarchyNode-TrendChart-101-2")]
        public void NoDataCompare_LineChartSaveToDashBoard(EnergyViewOptionData input)
        {
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            EnergyAnalysis.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();

            //Check tag V_Null_BuildingBC and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsScrollbarExist());
            Assert.IsFalse(EnergyAnalysis.IsTrendChartDrawn());

            //Uncheck tag V_Null_BuildingBC, and select another tag v14
            EnergyAnalysis.UncheckTag(input.InputData.TagNames[0]);
            EnergyAnalysis.CheckTag(input.InputData.TagNames[1]);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsScrollbarExist());
            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
            Assert.AreEqual(1, EnergyAnalysis.GetTrendChartLines());

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
            TimeManager.Pause(8000);
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();
            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));
            */
            #endregion
        }

        //2.0测试的时候忽略，这版主要是验证数据的正确性
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101-3")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeTrendChartSuite), "TC-J1-FVT-SingleHierarchyNode-TrendChart-101-3")]
        public void NoDataCompare_TrendChartWithOtherCalcualtionType(EnergyViewOptionData input)
        {
            //On hierarchy node,NancyCustomer1/园区测试多层级/BuildingMulCalculationType
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Set date range
            EnergyViewToolbar.SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 7));
            TimeManager.ShortPause();

            EnergyAnalysis.SwitchTagTab(TagTabs.HierarchyTag);
            TimeManager.MediumPause();

            //Check tag V_Null_BuildingBC and view data view
            EnergyAnalysis.CheckTags(input.InputData.TagNames);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());

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
            TimeManager.Pause(8000);
            HomePagePanel.ClickDashboardButton(dashboard.DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.GetDashboardHeaderName().Contains(dashboard.DashboardName));
            Assert.IsTrue(HomePagePanel.IsWidgetExistedOnDashboard(dashboard.WigetName));       
            */
            #endregion
        }

        //2.0测试的时候忽略,会导致chrome崩溃
        [Test]
        [Ignore("ignore")]
        [CaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101-4")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeTrendChartSuite), "TC-J1-FVT-SingleHierarchyNode-TrendChart-101-4")]
        public void TrendChart30TagsLimit(EnergyViewOptionData input)
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
            for (int i = 1; i < 31; i++)
            {
                EnergyAnalysis.CheckTag("Vpie" + i.ToString());
            }

            //view dataview.
            EnergyViewToolbar.View(EnergyViewType.Line);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            //Check · The trend chart is can draw with totally 30 tags.
            EnergyAnalysis.ExportExpectedDataTableToExcel(input.ExpectedData.expectedFileName[0], DisplayStep.Default);
            TimeManager.MediumPause();
            EnergyAnalysis.CompareDataViewOfEnergyAnalysis(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0]);
        }
    }
}
