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
    public class FormulaForDayNightKPI : TestSuiteBase
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
        [CaseID("TA-FormulaforDayNightKPI-001"), ManualCaseID("TJ-FormulaForKPI-001"), CreateTime("2013-01-07"), Owner("Alice")]
        public void AddFormulaToKPItag()
        {
            //string kpitagName = "AliceKPItag";
            //string expectedFormula = "{ptag.P2}";
            string kpitagName = "AliceKPItag";
            string expectedFormula = "{ptag.P2}";

            KPITagSettings.PrepareToAddFormula(kpitagName);

            KPITagSettings.FillInFormulaField("{ptag.P2}");

            KPITagSettings.ClickSaveFormulaButton();

            //FunctionWrapper.WaitForLoadingDisappeared(2000);
            //ElementLocator.Pause(500);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(KPITagSettings.GetFormulaValue(), expectedFormula);
            Assert.IsTrue(KPITagSettings.DayNightIsChecked());

        }
    }
}

