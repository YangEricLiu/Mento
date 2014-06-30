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


namespace Mento.Script.Information.Widgets
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-Widget-Maximize-101"), CreateTime("2013-09-30"), Owner("Emma")]
    public class MaximizeWidgetSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;

        [SetUp]
        public void CaseSetUp()
        {
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        private static EnergyAnalysisPanel DataPanel = JazzFunction.EnergyAnalysisPanel;

        [Test]
        [CaseID("TC-J1-FVT-Widget-Maximize-101-1")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(MaximizeWidgetSuite), "TC-J1-FVT-Widget-Maximize-101-1")]
        public void MaximizeWidgetAndChangeInterval(MaximizeWidgetData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //The dashboard displays its widgets and the relative locations correctly.
            Assert.AreEqual(7, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[1]);
            TimeManager.LongPause();

            //Change the interval with valid input, and click '查看数据'
            
            var timeInterval = input.InputData.TimeIntervalList;
            
            for (int i = 0; i < timeInterval.Length; i++)
            {
                Widget.SelectStartDate(timeInterval[i].StartDate);
                Widget.SelectStartTime(timeInterval[i].StartTime);
                Widget.SelectEndDate(timeInterval[i].EndDate);
                Widget.SelectEndTime(timeInterval[i].EndTime);

                Widget.ClickViewDataButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
            }
            
            //Click 'Next' button several times to jump other widgets.
            for (int i = 2; i < dashboard[0].WigetNames.Length; i++)
            {
                Widget.ClickNextButton();
                TimeManager.MediumPause();

                Assert.AreEqual(dashboard[0].WigetNames[i], Widget.GetMaxWidgetName());
            }

            //'Next' button is unavailable on the last widget.
            Assert.IsFalse(Widget.IsNextButtonEnable());

            //Click 'Previous' button several times to jump other widgets
            for (int i = (dashboard[0].WigetNames.Length - 2); i >= 0; i--)
            {
                Widget.ClickPrevButton();
                TimeManager.MediumPause();

                Assert.AreEqual(dashboard[0].WigetNames[i], Widget.GetMaxWidgetName());
            }

            //Previous' button is unavailable on the first widget.
            Assert.IsFalse(Widget.IsPrevButtonEnable());

            //Close the max dialog
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            //Pick another dashboard which only contains one widget.
            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //The dashboard displays its widgets and the relative locations correctly.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[1].WigetNames[0]);
            TimeManager.LongPause();

            //'Previous’ and ‘Next’ buttons are both unavailable on the widget.
            Assert.IsFalse(Widget.IsNextButtonEnable());
            Assert.IsFalse(Widget.IsPrevButtonEnable());

            //Close the max dialog
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Maximize-101-1-1")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(MaximizeWidgetSuite), "TC-J1-FVT-Widget-Maximize-101-1")]
        public void MaximizeWidgetAndChangeIntervalForFavorite(MaximizeWidgetData input)
        {
            Widget.NavigateToMyFavorite();
            TimeManager.MediumPause();
            
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //The dashboard displays its widgets and the relative locations correctly.
            Assert.AreEqual(7, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[1]);
            TimeManager.LongPause();

            //Change the interval with valid input, and click '查看数据'

            var timeInterval = input.InputData.TimeIntervalList;
            
            for (int i = 0; i < timeInterval.Length; i++)
            {
                Widget.SelectStartDate(timeInterval[i].StartDate);
                Widget.SelectStartTime(timeInterval[i].StartTime);
                Widget.SelectEndDate(timeInterval[i].EndDate);
                Widget.SelectEndTime(timeInterval[i].EndTime);

                Widget.ClickViewDataButton();
                JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
                TimeManager.LongPause();
            }
            
            //Click 'Next' button several times to jump other widgets.
            for (int i = 2; i < dashboard[0].WigetNames.Length; i++)
            {
                Widget.ClickNextButton();
                TimeManager.MediumPause();

                Assert.AreEqual(dashboard[0].WigetNames[i], Widget.GetMaxWidgetName());
            }

            //'Next' button is unavailable on the last widget.
            Assert.IsFalse(Widget.IsNextButtonEnable());

            //Click 'Previous' button several times to jump other widgets
            for (int i = (dashboard[0].WigetNames.Length - 2); i >= 0; i--)
            {
                Widget.ClickPrevButton();
                TimeManager.MediumPause();

                Assert.AreEqual(dashboard[0].WigetNames[i], Widget.GetMaxWidgetName());
            }

            //Previous' button is unavailable on the first widget.
            Assert.IsFalse(Widget.IsPrevButtonEnable());

            //Close the max dialog
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            //Pick another dashboard which only contains one widget.
            HomePagePanel.ClickDashboardButton(dashboard[1].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //The dashboard displays its widgets and the relative locations correctly.
            Assert.AreEqual(1, HomePagePanel.GetWidgetsNumberOfDashboard());

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[1].WigetNames[0]);
            TimeManager.LongPause();

            //'Previous’ and ‘Next’ buttons are both unavailable on the widget.
            Assert.IsFalse(Widget.IsNextButtonEnable());
            Assert.IsFalse(Widget.IsPrevButtonEnable());
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Maximize-101-2")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(MaximizeWidgetSuite), "TC-J1-FVT-Widget-Maximize-101-2")]
        public void MaximizeWidgetPredefinedTime(MaximizeWidgetData input)
        {
            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[0]);
            TimeManager.LongPause();

            //Chart view predefined time range change according to current time when the widget is saved to dashboard.
            var timeInterval = input.InputData.TimeIntervalList;

            for (int i = 0; i < timeInterval.Length; i++)
            {
                Assert.AreEqual(timeInterval[i].StartDate, Widget.GetStartDate());
                Assert.AreEqual(timeInterval[i].EndDate, Widget.GetEndDate());

                Widget.ClickNextButton();
                TimeManager.MediumPause();
            }

            //change its manual time range.
            Widget.SelectStartDate(timeInterval[6].StartDate);
            Widget.SelectEndDate(timeInterval[6].EndDate);

            Widget.ClickViewDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Exit and max view widget4 again
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();

            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[7]);

            //Change to pre-defined time range again.
            Assert.AreEqual(timeInterval[7].StartDate, Widget.GetStartDate());
            Assert.AreEqual(timeInterval[7].EndDate, Widget.GetEndDate());

            //Exit
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Maximize-101-3")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(MaximizeWidgetSuite), "TC-J1-FVT-Widget-Maximize-101-3")]
        public void MaximizeWidgetDisplayStep01(MaximizeWidgetData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.LongPause();

            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[0]);
            TimeManager.LongPause();

            //There are optional step 1 day, 1 week display in widget.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //Default display step=day.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Week));

            //Click optional step=week.
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Widget display step change to week.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Maximize-101-4")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(MaximizeWidgetSuite), "TC-J1-FVT-Widget-Maximize-101-4")]
        public void MaximizeWidgetDisplayStep02(MaximizeWidgetData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.LongPause();

            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[0]);
            TimeManager.LongPause();

            //Optional step=hour can be selected.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            //Change time range to 2012/07/01-2012/07/31. 
            var timeInterval = input.InputData.TimeIntervalList;

            Widget.SelectStartDate(timeInterval[0].StartDate);
            Widget.SelectEndDate(timeInterval[0].EndDate);
            Widget.ClickViewDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //There are optional step 1 day, 1 week display in widget.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Week));

            //Change time rang to 2012/07/29-2012/08/03 again.
            Widget.SelectStartDate(timeInterval[1].StartDate);
            Widget.SelectEndDate(timeInterval[1].EndDate);
            Widget.ClickViewDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Optional step=hour can be selected.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            //Select hour step
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Hour);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Showing message in dialog, No Optional step=hour in dialog.
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));

            //Exit and max view widget again.
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[0]);

            //Widget change to display step=Day
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Hour));

            //Change time range to 2012/07/01 3:30-2012/07/01 15:30. 
            Widget.SelectStartDate(timeInterval[2].StartDate);
            Widget.SelectStartTime(timeInterval[2].StartTime);
            Widget.SelectEndDate(timeInterval[2].EndDate);
            Widget.SelectEndTime(timeInterval[2].EndTime);
            Widget.ClickViewDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //There is pop up warning message and no option step button display.
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            TimeManager.LongPause();

            //exit
            Widget.ClickCloseMaxDialogButton();
            TimeManager.MediumPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-Widget-Maximize-101-5")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(MaximizeWidgetSuite), "TC-J1-FVT-Widget-Maximize-101-5")]
        public void MaximizeWidgetDisplayStep03(MaximizeWidgetData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.LongPause();

            Widget.NavigateToAllDashboard();
            TimeManager.LongPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(60);
            TimeManager.MediumPause();

            //Click the 'Maximize' button
            HomePagePanel.MaximizeWidget(dashboard[0].WigetNames[0]);
            TimeManager.LongPause();

            //There are optional step 1 day, 1 week display in widget.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //select "day"/"week"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Showing message in dialog, No Optional step=hour in dialog.
            //Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Month);
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Showing message in dialog, No Optional step=hour in dialog.
            //Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));

            //Change time range to 2012/01/01-2013/01/01. 
            var timeInterval = input.InputData.TimeIntervalList;

            Widget.SelectStartDate(timeInterval[0].StartDate);
            Widget.SelectEndDate(timeInterval[0].EndDate);
            Widget.ClickViewDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //There are optional step 1 month, 1 year display in widget.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Week));

            //Change time rang to 2012/07/29-2012/08/03.
            Widget.SelectStartDate(timeInterval[1].StartDate);
            Widget.SelectEndDate(timeInterval[1].EndDate);
            Widget.ClickViewDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Pop up dialog and no optional step can be selected.
            Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains(input.ExpectedData.messages[0]));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Day));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Week));
            Assert.IsFalse(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Year));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            TimeManager.LongPause();

            //Change time rang to 2012/06/01-2012/09/01.
            Widget.SelectStartDate(timeInterval[2].StartDate);
            Widget.SelectEndDate(timeInterval[2].EndDate);
            Widget.ClickViewDataButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Widget display step=Month.No message.
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Hour));
            Assert.IsFalse(EnergyAnalysis.IsDisplayStepDisplayed(DisplayStep.Year));

            //select "day"/"week"
            EnergyAnalysis.ClickDisplayStep(DisplayStep.Week);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Showing message in dialog, No Optional step=hour in dialog.
            //Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickStepButtonOnWindow(DisplayStep.Month);
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));

            EnergyAnalysis.ClickDisplayStep(DisplayStep.Day);
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.LongPause();

            //Showing message in dialog, No Optional step=hour in dialog.
            //Assert.IsTrue(JazzWindow.WindowMessageInfos.GetContentValue().Contains("所选数据点不支持\"按小时\",\"按天\",\"按周\"的步长显示，换个步长试试"));
            Assert.IsTrue(EnergyAnalysis.IsStepButtonOnWindow(DisplayStep.Month));
            TimeManager.MediumPause();
            EnergyAnalysis.ClickGiveupButtonOnWindow();
            TimeManager.LongPause();
            Assert.IsTrue(EnergyAnalysis.IsDisplayStepPressed(DisplayStep.Month));
        }
    }
}
