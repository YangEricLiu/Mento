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

namespace Mento.Script.Information.Share
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-Dashboard-Share-105"), CreateTime("2013-10-21"), Owner("Emma")]
    public class ViewShareDashboardWidgetGridSuite : TestSuiteBase
    {
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static Widget Widget = JazzFunction.Widget;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static ShareWindow ShareWindow = new ShareWindow();
        private static ShareInfoWindow ShareInfoWindow = new ShareInfoWindow();
        private static int WAITSHAREINFOTAB = 5000;
        
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HomePagePanel.NavigateToEnergyView();
        }

        [Test]
        [CaseID("TC-J1-FVT-Dashboard-Share-105-1")]
        [MultipleTestDataSource(typeof(ShareDashboardData[]), typeof(ViewShareDashboardWidgetGridSuite), "TC-J1-FVT-Dashboard-Share-105-1")]
        public void ViewShareDashboardWidgetGrid01(ShareDashboardData input)
        {
            var dashboard = input.InputData.DashboardInfo;
            
            HomePagePanel.SelectHierarchyNode(dashboard[0].HierarchyName);
            TimeManager.MediumPause();

            HomePagePanel.ClickDashboardButton(dashboard[0].DashboardName);
            JazzMessageBox.LoadingMask.WaitDashboardHeaderLoading(30);
            TimeManager.LongPause();

            //Open share window
            HomePagePanel.ClickShareWidgetButton(dashboard[0].WidgetName);
            TimeManager.Pause(HomePagePanel.WAITSHAREWINDOWTIME);

            //Check there is title in the window.
            Assert.AreEqual("分享小组件", ShareWindow.GetTitle());

            //Check UserA, UserD, UserE. Check receivers realname checkbox.
            //Exclude userA in user list.
            ShareWindow.IsShareUserExistedOnWindow(dashboard[0].ReceiveUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[0]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[1]);
            ShareWindow.CheckShareUser(dashboard[0].ShareUsers[2]);

            //The realname display in share to textfield.
            Assert.AreEqual(3, ShareWindow.GetShareUserNumber());
            Assert.IsTrue(ShareWindow.IsShareUserInContainer(dashboard[0].ShareUsers[0]));
            Assert.IsTrue(ShareWindow.IsShareUserInContainer(dashboard[0].ShareUsers[1]));
            Assert.IsTrue(ShareWindow.IsShareUserInContainer(dashboard[0].ShareUsers[2]));

            //Uncheck receivers realname checkbox.
            ShareWindow.UncheckShareUser(dashboard[0].ShareUsers[0]);
            TimeManager.ShortPause();

            //The realname disappear in sent to textfield.
            Assert.IsFalse(ShareWindow.IsShareUserInContainer(dashboard[0].ShareUsers[0]));
            Assert.AreEqual(2, ShareWindow.GetShareUserNumber());

            //Click "X" button from the send to textfield.
            ShareWindow.ClickRemoveShareUserButton(dashboard[0].ShareUsers[1]);
            TimeManager.ShortPause();

            //The realname disappear in sent to textfield.
            Assert.IsFalse(ShareWindow.IsShareUserInContainer(dashboard[0].ShareUsers[1]));
            Assert.AreEqual(1, ShareWindow.GetShareUserNumber());

            //Click CheckAll checkbox.
            ShareWindow.CheckAllShareUsers();
            TimeManager.MediumPause();

            //All receivers are checked and display in send to textfield.
            Assert.IsTrue(ShareWindow.IsAllShareUsersChecked());

            ShareWindow.ClickGiveupButton();
            TimeManager.ShortPause();
        }

    }
}

