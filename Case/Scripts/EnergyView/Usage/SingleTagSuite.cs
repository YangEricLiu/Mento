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
        /// 1.	Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	"
        ///     Successfully navigate to Energy Analysis window.
        /// 2.	select a hierarchy node	
        /// 3.	Go to Tag select panel, Select V(1)
        ///     The trend chart of selected V(1) display.
        /// 4.	Click "Save to dashboard"(保存到仪表盘), 
        ///     Click the dashboard addtion button "新增仪表盘"
        ///     Input valid dashboard name like "仪表盘_A1",and click save.
        ///     The widget is saved to the new dashboard successfully
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-037")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleTagSuite), "TC-J1-SmokeTest-037")]
        public void SingTagTrendChart(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);

            DataPanel.CheckTags(option.InputData.TagNames);

            Assert.IsTrue(DataPanel.IsTrendChartDrawn());

            //save to dashboard

        }

        /// <summary>
        /// 1.	Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	"
        ///     Successfully navigate to Energy Analysis window.
        /// 2.	select a hierarchy node	
        /// 3.	Go to Tag select panel, Select V(1), click "Column chart", set date range to last month	
        ///     The Column chart of selected V(1) display.
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-038")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleTagSuite), "TC-J1-SmokeTest-038")]
        public void SingleTagColumnChart(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);

            DataPanel.CheckTags(option.InputData.TagNames);

            DataPanel.Toolbar.View(option.InputData.ViewType); //column

            DataPanel.Toolbar.SelectMoreOption(EnergyViewMoreOption.LastMonth);

            Assert.IsTrue(DataPanel.IsTrendChartDrawn());
        }
        
        /// <summary>
        /// 1. Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	
        ///    Successfully navigate to Energy Analysis window.
        /// 2. select a hierarchy node
        /// 3. Go to Tag select panel, Select V(1), click "data view", set date range to last year
        ///    The data view of selected V(1) display.
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-039")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleTagSuite), "TC-J1-SmokeTest-039")]
        public void SingleTagDataView(EnergyViewOptionData option)
        {
            DataPanel.SelectHierarchy(option.InputData.Hierarchies);

            DataPanel.CheckTags(option.InputData.TagNames);

            DataPanel.Toolbar.View(option.InputData.ViewType);

            DataPanel.Toolbar.SelectMoreOption(EnergyViewMoreOption.LastYear);

            Assert.AreEqual(12, DataPanel.GetRecordCount());
            Assert.AreEqual(1, DataPanel.GetPageCount());
        }

        /// <summary>
        /// 1.	Navigate to Energy Management. Select the Building node in Pre-condition from Hierarchy list and go to Energy usage -> Energy Analysis. (用能->能效分析.)	"
        ///     Successfully navigate to Energy Analysis window.
        /// 2.	select a hierarchy node
        /// 3.	Go to Tag select panel, Select V(1), click "pie chart", set date range from 2012.1.1 to 2012.4.15
        ///     The pie chart of selected V(1) display.
        /// </summary>
        [Test]
        [CaseID("TC-J1-SmokeTest-040	")]
        public void SingleTagDistributionChart() 
        { 

        }
    }
}
