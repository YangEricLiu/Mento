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

namespace Mento.Script.EnergyView.CorporateRanking
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101"), CreateTime("2013-10-17"), Owner("Greenie")]
    public class SelectHierarchyNodesForRanking : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.HomePage.SelectCustomer("NancyCustomer1");
            CorporateRanking.NavigateToCorporateRanking();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            //JazzFunction.Navigator.NavigateHome();
        }

        private static RankPanel CorporateRanking = JazzFunction.RankPanel;
        private static EnergyViewToolbar EnergyViewToolbar = JazzFunction.EnergyViewToolbar;
        private static HomePage HomePagePanel = JazzFunction.HomePage;

        [Test]
        [CaseID("TC-J1-FVT-SelectHierarchyNodesForRanking-101-1")]
        [MultipleTestDataSource(typeof(CorporateRankingData[]), typeof(SelectHierarchyNodesForRanking), "TC-J1-FVT-SelectHierarchyNodesForRanking-101-1")]
        public void SelectHierarchyNodesForCoperateRanking(CorporateRankingData input)
        {
            //Click Hierarchy Node Selector.
            CorporateRanking.CheckHierarchyNode(input.InputData.Hierarchies);
        }

    }
}
