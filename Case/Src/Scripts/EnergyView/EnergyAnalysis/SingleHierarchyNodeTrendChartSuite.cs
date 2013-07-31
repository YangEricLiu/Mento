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

namespace Mento.Script.EnergyView.Usage
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    [ManualCaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101"), CreateTime("2013-07-31"), Owner("Emma")]
    public class SingleHierarchyNodeTrendChartSuite : TestSuiteBase
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
        [CaseID("TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        [MultipleTestDataSource(typeof(EnergyViewOptionData[]), typeof(SingleHierarchyNodeTrendChartSuite), "TC-J1-FVT-SingleHierarchyNode-TrendChart-101-1")]
        public void ViewLineChartOfTagThenClear(EnergyViewOptionData option)
        {
            EnergyAnalysis.SelectHierarchy(option.InputData.Hierarchies);

            EnergyAnalysis.CheckTag(option.InputData.TagNames[0]);

            EnergyViewToolbar.ClickViewButton();

            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.LongPause();

            Assert.IsTrue(EnergyAnalysis.IsTrendChartDrawn());
        }

    }
}
