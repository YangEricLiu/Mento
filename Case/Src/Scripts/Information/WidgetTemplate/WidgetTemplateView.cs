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


namespace Mento.Script.Information.WidgetTemplate
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-WidgetTemplate-View-101"), CreateTime("2014-10-9"), Owner("Cathy")]
    public class WidgetTemplateViewSuite : TestSuiteBase
    {
        private static Widget Widget = JazzFunction.Widget;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;

        [SetUp]
        public void CaseSetUp()
        {
            Widget.NavigateToAllDashboard();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-FVT-WidgetTemplate-View-101"), CreateTime("2014-11-20"), Owner("Cathy")]
        [MultipleTestDataSource(typeof(MaximizeWidgetData[]), typeof(WidgetTemplateViewSuite), "TC-J1-FVT-WidgetTemplate-View-101")]
        public void ViewWidgetTemplate(MaximizeWidgetData input)
        {
            Widget.ClickWidgetTemplateQuickCreateButton();
            //All template display there
            for (int i = 0; i < 8; i++)
            {
                Assert.IsTrue(HomePagePanel.IsWidgetExistedOnQuickCreateWidget(input.ExpectedData.WidgetNames[i]));
            }
            //Click close button
            Widget.ClickWidgetTemplateQuickCreateButtonCloseButton();
            //Verify 快速创建 button display
            Assert.IsTrue(Widget.IsWidgetTemplateQuickCreateButtonExisted());
        }
    }
}
