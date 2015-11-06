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
        public void SettingCalculationRuleForAverageMode_AverageConfig(EnergyAnalysisData input)
        {
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

            EnergyViewToolbar.NewJazz_ExportBaselineDataTableToExcel("TC-J1-FVT-BaselineConfiguration-Add-106-3.xls", 1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CompareAutoConfigBaseline("TC-J1-FVT-BaselineConfiguration-Add-106-3.xls", "F-TC-J1-FVT-BaselineConfiguration-Add-106-3.xls", 1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineSaveButton();
            TimeManager.Pause(30000);

            EnergyViewToolbar.NewJazz_BaselineClickCalReviseTab();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_CompareReviseValue(input.InputData.ReviseValue);
            TimeManager.Pause(5000);
        }
    }
}
