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

namespace Mento.Script.EnergyView.EADataVerify
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-EADataVerify-101"), CreateTime("2015-10-13"), Owner("Emma")]
    public class NancyCustomer1Suite : TestSuiteBase
    {
        [TestFixtureSetUp]
        public void FixtureCaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            TimeManager.Pause(10000);

            JazzBrowseManager.SwitchToWidnow("能源");
            TimeManager.Pause(10000);
            TimeManager.MediumPause();
        }

        [SetUp]
        public void CaseSetUp()
        {
            //EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        private static NewJazzEnergyAnalysis EnergyAnalysis = JazzFunction.NewJazzEnergyAnalysis;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;

        [Test]
        [Category("P1_Emma")]
        [CaseID("TC-J1-FVT-EADataVerify-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(NancyCustomer1Suite), "TC-J1-FVT-EADataVerify-101-1")]
        public void DataVerifyP1V1V2V3(EnergyViewOptionData input)
        {
            //Select a existed widget
            JazzButton.GetOneButton(JazzControlLocatorKey.DashboardFolderWidgetNameButton, "调试用图表").Click();
            TimeManager.Pause(10000);

            //Open taglist panel

            EnergyAnalysis.NewJazz_SelectHierarchy(input.InputData.Hierarchies);

            TimeManager.Pause(5000);

            EnergyAnalysis.NewJazz_CheckTag("AutoVAdd10");
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickView();

            EnergyViewToolbar.NewJazz_SelectAssistMenuItem(NewJazzEnergyViewToolbarOption.BaselineConfigration);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_SelectBaselineYearMenuItem("2012");
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineEditButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ClickBaselineAddTimeSettingButton();
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_BaselineSetDateRange(new DateTime(2012, 1, 1), new DateTime(2012, 2, 1), 1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_BaselineClickAutoCal(1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_BaselineClickReCal(1);
            TimeManager.Pause(5000);

            EnergyViewToolbar.NewJazz_ExportBaselineDataTableToExcel("testBaeline.xls", 1);
            TimeManager.Pause(5000);
        }
    }
}
