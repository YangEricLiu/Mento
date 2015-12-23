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

namespace Mento.Script.EnergyView.DataVerify
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-EA-DataVerify-101"), CreateTime("2015-10-13"), Owner("Emma")]
    public class EnergyAnalysisSuite : TestSuiteBase
    {
        public string mainWindowHandle = TestAssemblyInitializer.mainWindowHandle;

        [TestFixtureSetUp]
        public void FixtureCaseSetUp()
        {
            TimeManager.Pause(5000);
            JazzBrowseManager.SwitchToEmptyWidnow();
            TimeManager.Pause(2000);

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyView);
            TimeManager.Pause(5000);
        }

        [SetUp]
        public void CaseSetUp()
        {
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            TimeManager.LongPause();
        }

        private static NewJazzEnergyAnalysis EnergyAnalysis = JazzFunction.NewJazzEnergyAnalysis;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static FolderWidgetPanel FolderWidget = JazzFunction.FolderWidgetPanel;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [Category("P1_Emma")]
        [CaseID("TC-J1-FVT-EA-DataVerify-101-1")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(EnergyAnalysisSuite), "TC-J1-FVT-EA-DataVerify-101-1")]
        public void EA_DataVerify(EnergyAnalysisData input)
        {
            //选择图表
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(30000);

            string compareFileName = input.InputData.WidgetPath[input.InputData.WidgetPath.Length - 1];

            //打开下拉框
            JazzButton.FolderOrWidgetDropDownButton.Click();
            TimeManager.MediumPause();                                           

            //导出数据文件
            JazzButton.ExportFromDropDownButton.Click();
            TimeManager.Pause(10000);

            //当比较标识为真的时候，比较两个Excel文件
            EnergyAnalysis.NewJazz_CompareExcelFiles_EnergyAnalysis(compareFileName + ".xls", ("F-" + compareFileName + ".xls"));
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-EA-Cost-DataVerify-101-1")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(EnergyAnalysisSuite), "TC-J1-FVT-EA-Cost-DataVerify-101-1")]
        public void EA_Cost_DataVerify(EnergyAnalysisData input)
        {
            //选择图表
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(30000);

            string compareFileName = input.InputData.WidgetPath[input.InputData.WidgetPath.Length - 1];

            //打开下拉框
            JazzButton.FolderOrWidgetDropDownButton.Click();
            TimeManager.MediumPause();

            //导出数据文件
            JazzButton.ExportFromDropDownButton.Click();
            TimeManager.Pause(10000);

            //当比较标识为真的时候，比较两个Excel文件
            EnergyAnalysis.NewJazz_CompareExcelFiles_EnergyAnalysis(compareFileName + ".xls", ("F-" + compareFileName + ".xls"));
        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-EA-Carbon-DataVerify-101-1")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(EnergyAnalysisSuite), "TC-J1-FVT-EA-Carbon-DataVerify-101-1")]
        public void EA_Carbon_DataVerify(EnergyAnalysisData input)
        {
            //选择图表
            FolderWidget.NewJazz_SelectFolderOrWidget(input.InputData.WidgetPath);
            TimeManager.Pause(30000);

            string compareFileName = input.InputData.WidgetPath[input.InputData.WidgetPath.Length - 1];

            //打开下拉框
            JazzButton.FolderOrWidgetDropDownButton.Click();
            TimeManager.MediumPause();

            //导出数据文件
            JazzButton.ExportFromDropDownButton.Click();
            TimeManager.Pause(10000);

            //当比较标识为真的时候，比较两个Excel文件
            EnergyAnalysis.NewJazz_CompareExcelFiles_EnergyAnalysis(compareFileName + ".xls", ("F-" + compareFileName + ".xls"));
        }

        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-EA-DataVerify-101-1")]
        [MultipleTestDataSource(typeof(EnergyAnalysisData[]), typeof(EnergyAnalysisSuite), "TC-J1-FVT-EA-DataVerify-101-1")]
        public void DataVerify_All(EnergyAnalysisData input)
        {
            widgetsPath[]  actualWidget = FolderWidget.GetAllWidgetsPath();

            foreach (widgetsPath widget in actualWidget)
            {
                string compareFileName = widget.widgetPath[widget.widgetPath.Length - 1];

                Console.Out.WriteLine(compareFileName);

                //选择图表
                FolderWidget.NewJazz_SelectFolderOrWidget(widget.widgetPath);
                JazzMessageBox.LoadingMask.NewJazz_WaitChartMaskerLoading(10);               

                //打开下拉框
                JazzButton.FolderOrWidgetDropDownButton.Click();
                TimeManager.MediumPause();

                //导出数据文件
                JazzButton.ExportFromDropDownButton.Click();
                TimeManager.Pause(5000);

                //当比较标识为真的时候，比较两个Excel文件
                EnergyAnalysis.NewJazz_CompareExcelFiles_EnergyAnalysis(compareFileName + ".xls", ("F-" + compareFileName + ".xls"));
            }

        }
    }
}
