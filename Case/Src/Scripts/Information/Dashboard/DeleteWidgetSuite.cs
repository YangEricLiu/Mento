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
    [ManualCaseID("TC-J1-SmokeTest-039"), CreateTime("2013-01-21"), Owner("Alice")]
    public class DeleteWidgetSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        
        /// <summary>
        /// prepare data:on homepage ,there is a widget and it's name is "表3"，and it is the first widget of the dashboard.
        ///              this case can follow the case "ModifyWidgetName"
        /// </summary>
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HomePage);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel DataPanel = JazzFunction.EnergyAnalysisPanel;
        [Test]
        //[CaseID("TC-J1-SmokeTest-037")]
        //[MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleTagSuite), "TC-J1-SmokeTest-037")]
        public void ToDeleteWidget()
        {
            Widget.ClickDashboardHierarchyNameButton();

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Widget.DeleteWidget();
            
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains("确认删除表3"));

            TimeManager.LongPause();
            Widget.CancelDeleteWidget();
            Assert.IsTrue(JazzFunction.Widget.CheckWidgetIsExist());

            Widget.DeleteWidget();
            Widget.ConfirmDeleteWidget();

            TimeManager.LongPause();
            Assert.IsFalse(JazzFunction.Widget.CheckWidgetIsExist());

        }

    }
}
