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

namespace Mento.Script.Information.Dashboard
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-Dashboard-Rename-101"), CreateTime("2013-10-10"), Owner("Emma")]
    public class RenameDashboardSuite : TestSuiteBase
    {
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("NancyCustomer1");
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Rename-101-1")]
        [MultipleTestDataSource(typeof(RenameDashboardData[]), typeof(RenameDashboardSuite), "TC-J1-FVT-Dashboard-Rename-101-1")]
        public void RenameOneDashboard(RenameDashboardData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.MediumPause();
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Click 'Rename' button on top of the dashboard.
            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            //The dashboard rename window pops up.
            Assert.AreEqual(dashboard[0].DashboardName, HomePagePanel.GetCurrentDashboardNameOnWindow());
            HomePagePanel.FillInNewDashboardName(input.InputData.DashboardNames[0]);
            TimeManager.ShortPause();

            //Input the valid  and click cancel or 'x' icon.
            HomePagePanel.ClickRenameDashboardCancel();
            TimeManager.ShortPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));
            Assert.AreEqual(dashboard[0].DashboardName, HomePagePanel.GetDashboardHeaderName());

            //Input the valid name like , and click save.
            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();
            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();
            HomePagePanel.FillInNewDashboardName(input.InputData.DashboardNames[0]);
            TimeManager.ShortPause();
            HomePagePanel.ClickRenameDashboardSave();
            TimeManager.ShortPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(input.InputData.DashboardNames[0]));
            Assert.AreEqual(input.InputData.DashboardNames[0], HomePagePanel.GetDashboardHeaderName());

            HomePagePanel.ClickDashboardButton(input.InputData.DashboardNames[0]);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading();
            TimeManager.LongPause();

            //Mouse over a dashboard which hasn't been marked as favorite, 
            //Click the 'star' icon which is unlighted now.
            HomePagePanel.ClickFavoriteDashboardButton(input.InputData.DashboardNames[0]);

            //Switch to 'My favorite' from the left corner of Homepage, select the same dashboard as above
            HomePagePanel.NavigateToMyFavorite();
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(input.InputData.DashboardNames[0]);
            Assert.IsFalse(HomePagePanel.IsRenameDashboardButtonExisted(input.InputData.DashboardNames[0]));
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();
            Assert.AreEqual(input.InputData.DashboardNames[0], HomePagePanel.GetDashboardHeaderName());

            //Check if the renamed dashboard reflect on the window "Save widget to dashboard"
            EnergyAnalysis.NavigateToEnergyAnalysis();
            EnergyAnalysis.SelectHierarchy(input.InputData.Hierarchies);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //Check tag and view data view
            EnergyAnalysis.CheckTag(input.InputData.TagName);
            EnergyViewToolbar.ClickViewButton();
            JazzMessageBox.LoadingMask.WaitChartMaskerLoading();
            TimeManager.MediumPause();

            EnergyAnalysis.Toolbar.SaveToDashboard(dashboard[0].WigetNames[0], dashboard[0].HierarchyName, dashboard[0].IsCreateDashboard, input.InputData.DashboardNames[0]);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Rename-101-2")]
        [MultipleTestDataSource(typeof(RenameDashboardData[]), typeof(RenameDashboardSuite), "TC-J1-FVT-Dashboard-Rename-101-2")]
        public void RenameValidDashboards(RenameDashboardData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.MediumPause();
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Without any modification, just save the original name directly.
            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            //Input nothing and save
            HomePagePanel.ClickRenameDashboardSave();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].DashboardName));
            Assert.AreEqual(dashboard[0].DashboardName, HomePagePanel.GetDashboardHeaderName());

            //Rename several dashboards with valid name.
            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            HomePagePanel.FillInNewDashboardName(dashboard[0].newDashboardName);
            TimeManager.ShortPause();

            //Input the valid  and click save
            HomePagePanel.ClickRenameDashboardSave();
            TimeManager.MediumPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(input.ExpectedData.newDashboardNames[0]));
            Assert.AreEqual(input.ExpectedData.newDashboardNames[0], HomePagePanel.GetDashboardHeaderName());

            HomePagePanel.SelectHierarchyNode(dashboard[1].HierarchyName);
            TimeManager.LongPause();

            for (int i = 1; i < dashboard.Length; i++)
            {
                HomePagePanel.ClickDashboardButton(dashboard[i].DashboardName);
                JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
                TimeManager.LongPause();

                //Rename several dashboards with valid name.
                HomePagePanel.ClickRenameDashboardButton(dashboard[i].DashboardName);
                TimeManager.MediumPause();

                HomePagePanel.FillInNewDashboardName(dashboard[i].newDashboardName);
                TimeManager.ShortPause();

                //Input the valid  and click save
                HomePagePanel.ClickRenameDashboardSave();
                TimeManager.MediumPause();

                Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(input.ExpectedData.newDashboardNames[i]));
                Assert.AreEqual(input.ExpectedData.newDashboardNames[i], HomePagePanel.GetDashboardHeaderName());
            }
        }


        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Rename-101-3")]
        [MultipleTestDataSource(typeof(RenameDashboardData[]), typeof(RenameDashboardSuite), "TC-J1-FVT-Dashboard-Rename-101-3")]
        public void RenameInvalidDashboards(RenameDashboardData input)
        {
            HomePagePanel.SelectCustomer(input.InputData.CustomerName);
            TimeManager.MediumPause();
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();

            //Click on a Hierarchy node that contains dashboard.
            var dashboard = input.InputData.DashboardInfo;

            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.LongPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Dashboard name already exist under the same Node
            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            HomePagePanel.FillInNewDashboardName(input.InputData.DashboardNames[0]);
            TimeManager.ShortPause();

            //Input the valid  and click save
            HomePagePanel.ClickRenameDashboardSave();
            TimeManager.LongPause();

            Assert.IsTrue(HomePagePanel.GetPopNotesValue().Contains(input.ExpectedData.newDashboardNames[0]));
            TimeManager.MediumPause();

            //Blank; or only contains space.Dashboard name contain special chars  like "!@#$%^&*()~...",'-'.

            HomePagePanel.ClickRenameDashboardButton(dashboard[0].DashboardName);
            TimeManager.MediumPause();

            for (int i = 1; i < input.InputData.DashboardNames.Length; i++)
            {
                HomePagePanel.FillInNewDashboardName(input.InputData.DashboardNames[i]);
                TimeManager.ShortPause();

                //Input the valid  and click save
                HomePagePanel.ClickRenameDashboardSave();
                TimeManager.ShortPause();

                Assert.IsTrue(HomePagePanel.IsDashboardNameFieldInvalid());
                //Assert.IsTrue(HomePagePanel.GetDashboardNameFieldInvalidMsg().Contains(input.ExpectedData.newDashboardNames[i]));
                Assert.AreEqual(input.ExpectedData.newDashboardNames[i], HomePagePanel.GetDashboardNameFieldInvalidMsg());
            }

            //Revise above invalid dashboard name to be valid, and click Save.
            HomePagePanel.FillInNewDashboardName(dashboard[0].newDashboardName);
            TimeManager.ShortPause();

            //Input the valid  and click save
            HomePagePanel.ClickRenameDashboardSave();
            TimeManager.ShortPause();

            Assert.IsTrue(HomePagePanel.IsDashboardButtonExisted(dashboard[0].newDashboardName));
            Assert.AreEqual(dashboard[0].newDashboardName, HomePagePanel.GetDashboardHeaderName());
        }
    }
}

