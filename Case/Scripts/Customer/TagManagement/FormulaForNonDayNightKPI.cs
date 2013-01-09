using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    public class FormulaForNonDayNightKPI : TestSuiteBase
    {
        private static KPITagSettings KPITagSettings = JazzFunction.KPITagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            KPITagSettings.NavigatorToKPITagSetting();
            //ElementLocator.Pause(2000);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {

            BrowserHandler.Refresh();
        }

        [Test]
        [CaseID("TA-FormulaforNonDayNightKPI-001"), ManualCaseID("TJ-FormulaForKPI-001"), CreateTime("2013-01-09"), Owner("Alice")]
        public void AddFormulaToKPItag()
        {
            //string kpitagName = "KPI1";
            //string expectedFormula = "{ptag.P1}";
            string kpitagName = "KPI1";
            string expectedFormula = "{ptag.P1}";

            KPITagSettings.PrepareToAddFormula(kpitagName);
            
            KPITagSettings.FillInFormulaField("{ptag.P1}");

            KPITagSettings.ClickSaveFormulaButton();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(KPITagSettings.GetFormulaValue(), expectedFormula);
            Assert.IsFalse(KPITagSettings.DayNightIsChecked());

        }
    }
}
