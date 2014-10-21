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
    [ManualCaseID(""), CreateTime("2014-10-21"), Owner("Linda")]
    public class MonitorDataIssues : TestSuiteBase
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

        [Test]
        [CaseID("TC-J1-FVT-MonitorDataIssues")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(MonitorDataIssues), "TC-J1-FVT-MonitorDataIssues")]
        public void MonitorDayDataIssues(EnergyViewOptionData input)
        {
            ////"Hierarchies":["HM 中国", "Area10", "CN0123"],
			////"TagNames":["CN123"],

        //    DateTime startTime = new DateTime();
        //    startTime = DateTime.Now;
        //    DateTime endTime = new DateTime();
        //    System.TimeSpan timeSpan = new TimeSpan();
        //    int timeSpanMin = 0;
        //    bool flag = true;
            
        //    while(flag)
        //    {
        //        //Got to HMChina 
        //        EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
        //        JazzMessageBox.LoadingMask.WaitSubMaskLoading();
        //        TimeManager.MediumPause();

        //        //Check tag and view data view
        //        EnergyAnalysis.CheckTag(input.InputData.TagNames[0]);
        //        JazzFunction.EnergyViewToolbar.View(EnergyViewType.List);
        //        EnergyViewToolbar.ClickViewButton();
        //        JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        //        TimeManager.MediumPause();
                
        //        //Get all data when step is day
        //        EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
        //        JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        //        TimeManager.LongPause();
        //        DataTable dataTable = new DataTable();

        //        //Check if have data issue, e.g. one day data is 0.
        //        int n = EnergyAnalysis.GetRecordCount();
        //        string value;
        //        for (int i = 1; i < n; i++)
        //        {
        //            value = EnergyAnalysis.GetCellData(i+1, 2);
        //            if (("0" == value)||(" " == value))
        //            {
        //                string fileName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        //                EnergyAnalysis.ExportExpectedDataTableToExcel(fileName + "_dayStep.xls", DisplayStep.Default);

        //                EnergyAnalysis.ClickDisplayStep(DisplayStep.Raw);
        //                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
        //                TimeManager.LongPause();

        //                EnergyAnalysis.ExportExpectedDataTableToExcel(fileName + "_rawStep.xls", DisplayStep.Default);
        //            }
        //        }

        //        //Waite 3 mins
        //        System.Threading.Thread.Sleep(180000);

        //        //Case restart
        //        JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
        //        TimeManager.LongPause();
        //        EnergyAnalysis.NavigateToEnergyAnalysis();
        //        TimeManager.MediumPause();

        //        //Check if time interval is 7 days
        //        endTime = DateTime.Now;
        //        timeSpan = endTime - startTime;
        //        timeSpanMin = timeSpan.Minutes;
        //        if(timeSpanMin > 10080)
        //            flag = false;
        //    }
            
        }

    }
}
