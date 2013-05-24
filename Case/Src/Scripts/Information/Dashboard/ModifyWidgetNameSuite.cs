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
    public class ModifyWidgetNameSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        
        /// <summary>
        /// prepare data: homepage must has a widget,this case would modify this widget name to be "表3"，so it can provide condition for case"DeleteWidget"
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

        [Test]
        [CaseID("TC-J1-SmokeTest-037")]
        //[MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleTagSuite), "TC-J1-SmokeTest-037")]
        public void ToModifyWidgetName()
        {
            string expected = "表3";
            
            Widget.ClickDashboardHierarchyNameButton();
            
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Widget.SaveModifyWidgetName(expected);

            Assert.AreEqual(JazzLabel.WidgetName.GetLabelTextValue(), expected);

            Widget.CancelModifyWidgetName();

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(JazzLabel.WidgetName.GetLabelTextValue(), expected);
            
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();
            
        }
        
    }
}

