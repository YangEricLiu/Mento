﻿using System;
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

namespace Mento.Script.EnergyView.Usage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-SmokeTest-039"), CreateTime("2013-01-06"), Owner("Aries")]
    public class SingleTagSuite : TestSuiteBase
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

        private static EnergyAnalysisPanel DataPanel = JazzFunction.EnergyAnalysisPanel;
        
        /// <summary>
        /// 1. Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	
        ///    Successfully navigate to Energy Analysis window.
        /// 2. select a hierarchy node
        /// 3. Go to Tag select panel, Select V(1), click "data view", set date range to last year
        ///    The data view of selected V(1) display.
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-039")]
        public void SingleTagDataView()
        {
            EnergyViewData testData = TestContext.CurrentContext.GetTestData<EnergyViewData>();

            DataPanel.SelectHierarchy(testData.InputData.Hierarchies);

            DataPanel.CheckTags(testData.InputData.TagNames);

            DataPanel.Toolbar.View(testData.InputData.ViewType);

            DataPanel.Toolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);

            Assert.AreEqual(12, DataPanel.GetRecordCount());
            Assert.AreEqual(1, DataPanel.GetPageCount());
        }
    }
}
