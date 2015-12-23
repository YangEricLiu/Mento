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
    [ManualCaseID("TC-J1-FVT-EADataVerify-101"), CreateTime("2015-10-13"), Owner("Emma")]
    public class BaselineConfigrationSuite : TestSuiteBase
    {
        public string mainWindowHandle = TestAssemblyInitializer.mainWindowHandle;

        [TestFixtureSetUp]
        public void FixtureCaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            TimeManager.Pause(20000);

            JazzBrowseManager.SwitchToWidnow("能源");
            TimeManager.Pause(10000);         
        }

        [TestFixtureTearDown]
        public void FixtureCaseTearDown()
        {
            
        }

        [SetUp]
        public void CaseSetUp()
        {
            
        }

        [TearDown]
        public void CaseTearDown()
        {

        }

        private static NewJazzEnergyAnalysis EnergyAnalysis = JazzFunction.NewJazzEnergyAnalysis;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static FolderWidgetPanel FolderWidget = JazzFunction.FolderWidgetPanel;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [Category("P4_NewJazz_Emma")] 
        [CaseID("TC-J1-FVT-BaselineConfiguration-Add-106-1")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(BaselineConfigrationSuite), "TC-J1-FVT-BaselineConfiguration-Add-106-1")]
        public void EditDisableWithoutCalendar(EnergyAnalysisData input)
        {
            //HomePagePanel.SelectCustomer(input.InputData.Customer);
            //TimeManager.Pause(10000);

            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            //TimeManager.Pause(20000);

            //JazzBrowseManager.SwitchToWidnow("能源");
            //TimeManager.Pause(10000); 

            //Select a existed widget
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(10000);

            //Open taglist panel
            EnergyAnalysis.NewJazz_SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.Pause(5000);

            EnergyAnalysis.NewJazz_CheckTag(input.InputData.TagNames[0]);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickView();

            EnergyViewToolbar.NewJazz_SelectAssistMenuItem(NewJazzEnergyViewToolbarOption.BaselineConfigration);
            TimeManager.Pause(5000);

            Assert.IsTrue(EnergyViewToolbar.NewJazz_IsConfigEditButtonDisabled());
        }

        [Test]
        [Category("P4_NewJazz_Emma")]
        [CaseID("TC-J1-FVT-BaselineConfiguration-Add-106-2")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(BaselineConfigrationSuite), "TC-J1-FVT-BaselineConfiguration-Add-106-2")]
        public void TimeOverlapVerification(EnergyAnalysisData input)
        {
            //HomePagePanel.SelectCustomer(input.InputData.Customer);
            //TimeManager.Pause(10000);

            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            //TimeManager.Pause(20000);

            //JazzBrowseManager.SwitchToWidnow("能源");
            //TimeManager.Pause(10000); 

            //Select a existed widget
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(10000);

            //Open taglist panel
            EnergyAnalysis.NewJazz_SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.Pause(5000);

            EnergyAnalysis.NewJazz_CheckTag(input.InputData.TagNames[0]);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickView();

            EnergyViewToolbar.NewJazz_SelectAssistMenuItem(NewJazzEnergyViewToolbarOption.BaselineConfigration);
            TimeManager.Pause(5000);

            //第一次添加时间段，实际不添加任何，保存后没有错误，空的时间段信息也会显示出来
            EnergyViewToolbar.NewJazz_ClickBaselineEditButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineAddTimeSettingButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineSaveButton();
            TimeManager.Pause(30000);

            Assert.IsFalse(EnergyViewToolbar.NewJazz_IsConfigEditButtonDisabled());

            //第二次添加时间段，实际不添加任何，保存后有错误，时间段冲突
            EnergyViewToolbar.NewJazz_ClickBaselineEditButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineAddTimeSettingButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineSaveButton();
            TimeManager.Pause(5000);

            //验证第一条时间下面会显示时间段冲突错误
            Assert.AreEqual("时间段冲突， 请重新选择时段", EnergyViewToolbar.NewJazz_GetTimeOverlapMessage());
        }

        [Test]
        [Category("P1_Emma")]
        [CaseID("TC-J1-FVT-BaselineConfiguration-Add-106-3")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(BaselineConfigrationSuite), "TC-J1-FVT-BaselineConfiguration-Add-106-3")]
        public void AverageBaselineCalculation(EnergyAnalysisData input)
        {
            //HomePagePanel.SelectCustomer(input.InputData.Customer);
            //TimeManager.Pause(10000);

            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            //TimeManager.Pause(20000);

            //JazzBrowseManager.SwitchToWidnow("能源");
            //TimeManager.Pause(10000); 

            //Select a existed widget
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(10000);

            //Open taglist panel
            EnergyAnalysis.NewJazz_SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.Pause(5000);

            //tag1=BuildingA_P1_Electricity
            EnergyAnalysis.NewJazz_CheckTag(input.InputData.TagNames[0]);
            TimeManager.Pause(5000);

            var ManualTimeRange = input.InputData.ManualTimeRange;
            //2015-4-1 to 2015-4-1
            EnergyViewToolbar.NewJazz_SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate);
            TimeManager.ShortPause();

            EnergyViewToolbar.NewJazz_ClickView();

            EnergyViewToolbar.NewJazz_SelectAssistMenuItem(NewJazzEnergyViewToolbarOption.BaselineConfigration);
            TimeManager.Pause(5000);

            //time range=2015/04/01 to 2015/04/01
            EnergyViewToolbar.NewJazz_ClickBaselineEditButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineAddTimeSettingButton();
            TimeManager.Pause(5000);

            var BaselineTimeRange = input.InputData.BaselineTimeRange;
            //2015-4-1 to 2015-4-1
            EnergyViewToolbar.NewJazz_BaselineSetDateRange(BaselineTimeRange[0].StartDate, BaselineTimeRange[0].EndDate, 1);
            TimeManager.ShortPause();

            //Check "计算当前所选数据平均值为基准值" button.
            EnergyViewToolbar.NewJazz_BaselineClickAutoCal(1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_BaselineClickReCal(1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ExportBaselineDataTableToExcel(input.ExpectedData.expectedFileName[0], 1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CompareAutoConfigBaseline(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0], 1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineSaveButton();
            TimeManager.Pause(50000);

            EnergyViewToolbar.NewJazz_BaselineClickCalReviseTab();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CompareReviseValue(input.InputData.ReviseValue[0], input.InputData.FailedBaselineReviseValueTxt[0]);
            TimeManager.Pause(5000);

            //把有值的改成没值的，把没值的改成有值的
            EnergyViewToolbar.NewJazz_RevisionClickBaselineEditButton();
            TimeManager.Pause(5000);

            //改一月,4月和年的值
            EnergyViewToolbar.NewJazz_SetMonthValue(0, "10000");
            TimeManager.MediumPause();

            EnergyViewToolbar.NewJazz_SetMonthValue(1, "1440");
            TimeManager.MediumPause();

            EnergyViewToolbar.NewJazz_SetMonthValue(4, "");
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_RevisionClickBaselineSaveButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CompareReviseValue(input.InputData.ReviseValue[1], input.InputData.FailedBaselineReviseValueTxt[1]);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CloseBaselineConfigTab();
            TimeManager.Pause(5000);
        }

        [Test]
        [Category("P1_Emma")]
        [CaseID("TC-J1-FVT-BaselineConfiguration-Add-106-4")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(BaselineConfigrationSuite), "TC-J1-FVT-BaselineConfiguration-Add-106-4")]
        public void AverageModeRevision(EnergyAnalysisData input)
        {
            ////Select “NancyCostCustomer2”
            //HomePagePanel.SelectCustomer(input.InputData.Customer);
            //TimeManager.Pause(10000);

            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            //TimeManager.Pause(20000);

            //JazzBrowseManager.SwitchToWidnow("能源");
            //TimeManager.Pause(10000); 

            //Select a existed widget
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(10000);

            //Open taglist panel
            EnergyAnalysis.NewJazz_SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.Pause(5000);

            //tag1=BuildingA_P1_Electricity
            EnergyAnalysis.NewJazz_CheckTag(input.InputData.TagNames[0]);
            TimeManager.Pause(5000);

            var ManualTimeRange = input.InputData.ManualTimeRange;
            //2015-4-1 to 2015-4-1
            EnergyViewToolbar.NewJazz_SetDateRange(ManualTimeRange[0].StartDate, ManualTimeRange[0].EndDate, ManualTimeRange[0].StartTime, ManualTimeRange[0].EndTime);
            TimeManager.ShortPause();

            EnergyViewToolbar.NewJazz_ClickView();

            EnergyViewToolbar.NewJazz_SelectAssistMenuItem(NewJazzEnergyViewToolbarOption.BaselineConfigration);
            TimeManager.Pause(5000);

            //time range=2015/04/01 to 2015/04/01
            EnergyViewToolbar.NewJazz_ClickBaselineEditButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineAddTimeSettingButton();
            TimeManager.Pause(5000);
         
            //Check "计算当前所选数据平均值为基准值" button.
            EnergyViewToolbar.NewJazz_BaselineClickAutoCal(1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_BaselineClickReCal(1);
            TimeManager.Pause(5000);

            //因为选的那个点没有值，所以手动设置一个值,然后保存
            EnergyViewToolbar.newJazz_SetBaselineAutoCalValue(3, 2, "100", 1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ExportBaselineDataTableToExcel(input.ExpectedData.expectedFileName[0], 1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CompareAutoConfigBaseline(input.ExpectedData.expectedFileName[0], input.InputData.failedFileName[0], 1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineSaveButton();
            TimeManager.Pause(30000);

            EnergyViewToolbar.NewJazz_BaselineClickCalReviseTab();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CompareReviseValue(input.InputData.ReviseValue[0], input.InputData.FailedBaselineReviseValueTxt[0]);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CloseBaselineConfigTab();
            TimeManager.Pause(5000);
        }

        [Test]
        [Category("P1_Emma")]
        [CaseID("TC-J1-FVT-BaselineConfiguration-Add-106-5")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(BaselineConfigrationSuite), "TC-J1-FVT-BaselineConfiguration-Add-106-5")]
        public void ManualBaselineCalculation(EnergyAnalysisData input)
        {
            ////Select “NancyCostCustomer2”
            //HomePagePanel.SelectCustomer(input.InputData.Customer);
            //TimeManager.Pause(10000);

            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            //TimeManager.Pause(20000);

            //JazzBrowseManager.SwitchToWidnow("能源");
            //TimeManager.Pause(10000);

            //Select a existed widget
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(10000);

            //Open taglist panel
            EnergyAnalysis.NewJazz_SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.Pause(5000);

            //tag1=BuildingA_P1_Electricity
            EnergyAnalysis.NewJazz_CheckTag(input.InputData.TagNames[0]);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_SetDateRange("2015-04-30", "2015-05-31");
            TimeManager.ShortPause();

            EnergyViewToolbar.NewJazz_ClickView();

            EnergyViewToolbar.NewJazz_SelectAssistMenuItem(NewJazzEnergyViewToolbarOption.BaselineConfigration);
            TimeManager.Pause(5000);

            //time range=2015/04/01 to 2015/04/01
            EnergyViewToolbar.NewJazz_ClickBaselineEditButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineAddTimeSettingButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_BaselineSetDateRange("2015-04-30", "2015-05-31", 1);
            TimeManager.ShortPause();

            //默认选择手工设置基准值
            //工作日和非工作日
            EnergyViewToolbar.NewJazz_BaselineSelectWorkDayMenuItem(1, 1, "2", "03:00");
            EnergyViewToolbar.NewJazz_BaselineSelectWorkDayMenuItem(1, 2, "20");
            TimeManager.LongPause();

            EnergyViewToolbar.NewJazz_BaselineSelectNonWorkDayMenuItem(1, 1, "2", "03:00");
            EnergyViewToolbar.NewJazz_BaselineSelectNonWorkDayMenuItem(1, 2, "20");
            TimeManager.LongPause();

            //补充日期
            EnergyViewToolbar.NewJazz_ClickAddBaselineExtraDate(1);
            TimeManager.LongPause();

            EnergyViewToolbar.NewJazz_BaselineSetExtraDateValue(1, 1, "2015-04-20", "2015-05-20", "10:00", "15:00", "200");
            TimeManager.LongPause();

            //验证基准值计算值
            EnergyViewToolbar.NewJazz_ClickBaselineSaveButton();
            TimeManager.Pause(30000);

            EnergyViewToolbar.NewJazz_BaselineClickCalReviseTab();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CompareReviseValue(input.InputData.ReviseValue[0], input.InputData.FailedBaselineReviseValueTxt[0]);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CloseBaselineConfigTab();
            TimeManager.Pause(5000);
        }

        [Test]
        [Category("P1_Emma")]
        [CaseID("TC-J1-FVT-BaselineConfiguration-Add-106-6")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(BaselineConfigrationSuite), "TC-J1-FVT-BaselineConfiguration-Add-106-6")]
        public void DeleteBaselineConfigration(EnergyAnalysisData input)
        {
            ////Select “NancyCostCustomer2”
            //HomePagePanel.SelectCustomer(input.InputData.Customer);
            //TimeManager.Pause(10000);

            //JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            //TimeManager.Pause(20000);

            //JazzBrowseManager.SwitchToWidnow("能源");
            //TimeManager.Pause(10000);

            //Select a existed widget
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(10000);

            //Open taglist panel
            EnergyAnalysis.NewJazz_SelectHierarchy(input.InputData.Hierarchies);
            TimeManager.Pause(5000);

            //tag1=BuildingA_P1_Electricity
            EnergyAnalysis.NewJazz_CheckTag(input.InputData.TagNames[0]);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickView();

            EnergyViewToolbar.NewJazz_SelectAssistMenuItem(NewJazzEnergyViewToolbarOption.BaselineConfigration);
            TimeManager.Pause(5000);

            //time range=2015/04/01 to 2015/04/01
            EnergyViewToolbar.NewJazz_ClickBaselineEditButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickDeleteTimeSpanButton(1);
            TimeManager.LongPause();

            EnergyViewToolbar.NewJazz_ClickBaselineSaveButton();
            TimeManager.Pause(15000);
        }
    }
}
