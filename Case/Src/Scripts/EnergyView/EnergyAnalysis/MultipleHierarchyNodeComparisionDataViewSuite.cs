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

namespace Mento.Script.EnergyView.EnergyAnalysis
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101"), CreateTime("2013-08-08"), Owner("Emma")]
    public class MultipleHierarchyNodeComparisionDataViewSuite : TestSuiteBase
    {
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
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
        private static MutipleHierarchyCompareWindow MultiHieCompareWindow = JazzFunction.MutipleHierarchyCompareWindow;
        //private static 

        [Test]
        [CaseID("TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(MultipleHierarchyNodeComparisionDataViewSuite), "TC-J1-FVT-MultipleHierarchyNodeComparision-DataView-101-1")]
        public void MultipleHierarchyNodeComparisionDataView(EnergyViewOptionData input)
        {
            //Switch to "多层级数据点"
            EnergyViewToolbar.SelectTagModeConvertTarget(TagModeConvertTarget.MultipleHierarchyTag);
            TimeManager.LongPause();

            MultiHieCompareWindow.SelectHierarchyNode(input.InputData.Hierarchies);
        }
    }
}
