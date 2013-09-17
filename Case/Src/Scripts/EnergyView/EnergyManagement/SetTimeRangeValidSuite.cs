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

namespace Mento.Script.EnergyView.EnergyManagement
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SetTimeRange-101"), CreateTime("2013-08-28"), Owner("Emma")]
    public class SetTimeRangeValidSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            HomePagePanel.SelectCustomer("NancyOtherCustomer3");
            TimeManager.MediumPause();

            EnergyAnalysis.NavigateToEnergyAnalysis();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        private static EnergyAnalysisPanel EnergyAnalysis = JazzFunction.EnergyAnalysisPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;
        private static CostPanel CostPanel = JazzFunction.CostPanel;
        private static CarbonUsagePanel CarbonPanel = JazzFunction.CarbonUsagePanel;

        [Test]
        [CaseID("TC-J1-FVT-SetTimeRange-101-1")]
        public void SetPredefinedTimeRange()
        {
            //most of the steps need to manual check
        }
    }
}
