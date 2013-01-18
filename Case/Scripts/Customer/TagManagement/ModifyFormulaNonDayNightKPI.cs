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
    [TestFixture]
    [Owner("Alice")]
    [CreateTime("2013-01-09")]
    [ManualCaseID("TC-J1-SmokeTest-007")]
    public class ModifyFormulaNonDayNightKPI : TestSuiteBase
    {
        private static KPITagSettings KPITagSettings = JazzFunction.KPITagSettings;

        [SetUp]
        public void CaseSetUp()
        {
            KPITagSettings.NavigatorToKPITagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            JazzFunction.Navigator.NavigateHome();
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-007-001")]
        [Priority("P1")]
        [Type("Smoke")]
        public void AddFormulaToKPItag()
        {
            //string kpitagName = "KPI1";
            //string expectedFormula = "{ptag.P1}";
            string kpitagName = "KPI1";
            string expectedFormula = "{ptag.P1}+{ptag.P2}";

            KPITagSettings.PrepareToAddFormula(kpitagName);

            KPITagSettings.FillInFormulaField("{ptag.P1}");
            KPITagSettings.AppendFormulaField("+");
            KPITagSettings.DragTagToFormula("P2");

            KPITagSettings.ClickSaveFormulaButton();

            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            Assert.AreEqual(KPITagSettings.GetFormulaValue(), expectedFormula);
            Assert.IsFalse(KPITagSettings.DayNightIsChecked());

        }
    }
}

