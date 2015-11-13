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
            //选择图表
            JazzButton.GetOneButton(JazzControlLocatorKey.DashboardFolderWidgetNameButton, "P1V1V2V3_月").Click();
            TimeManager.Pause(10000);

            //Set date range
            EnergyViewToolbar.NewJazz_SetDateRange(new DateTime(2013, 1, 1), new DateTime(2013, 1, 31));
            TimeManager.ShortPause();


            //打开下拉框
            JazzButton.FolderOrWidgetDropDownButton.Click();
            TimeManager.MediumPause();                                           

            JazzButton.ExportFromDropDownButton.Click();
            TimeManager.Pause(15000);
            TimeManager.LongPause();

            EnergyAnalysis.NewJazz_CompareExcelFilesOfEnergyAnalysis("P1V1V2V3_月.xls", "F_P1V1V2V3_月.xls");
            EnergyAnalysis.NewJazz_CompareExcelFilesOfEnergyAnalysis("P1V1V2V3_周.xls", "F_P1V1V2V3_周.xls");
            EnergyAnalysis.NewJazz_CompareExcelFilesOfEnergyAnalysis("能耗分析.xls", "F_能耗分析.xls");
        }
    }
}
