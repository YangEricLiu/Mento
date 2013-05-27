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
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;

namespace Mento.Script.TestScript.DashboardSuite
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-16")]
    [ManualCaseID("TA-Smoke-Dashboard-001")]
    public class DashboardShare : TestSuiteBase
    {
        private static AllDashboard AllDashboard = JazzFunction.AllDashboard;
               
        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("Auto_Customer");

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AllDashboard);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }

        [Test]
        [Owner("Eric")]
        [CaseID("TA-Smoke-Dashboard-001-001")]
        [MultipleTestDataSource(typeof(ShareDashboard[]), typeof(DashboardShare), "TA-Smoke-Dashboard-001-001")]
        public void ShareDashboard(ShareDashboard testData)
        {
            AllDashboard.SelectHierarchy(testData.InputData.HierarchyNodePath);
            
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            AllDashboard.ClickDashboardIcon(1);

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.MyFavorite);

            AllDashboard.ClickDashboardText(1);
            TimeManager.ShortPause();
            
        }
        
    }
}

