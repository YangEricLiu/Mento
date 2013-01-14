using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Customer;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.TagManagement
{
    [TestFixture]
    [Owner("Amy")]
    [CreateTime("2013-01-11")]
    [ManualCaseID("TC-J1-SmokeTest")]
    public class KPITargetSuite:TestSuiteBase
    {
        private static KPITargetBaselineSettings KPITargetBaselineSettings = JazzFunction.KPITargetBaselineSettings;
        [SetUp]
        public void CaseSetUp()
        {
            KPITargetBaselineSettings.NavigatorToKPITagSetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-022")]
        [MultipleTestDataSource(typeof(KPITargetData[]), typeof(KPITargetSuite), "TC-J1-SmokeTest-022")]
        public void AddKPITarget(KPITargetData testData)
        {
            KPITargetBaselineSettings.FocusOnKPITag("KPITagForTargetBaseline");
            TimeManager.ShortPause();

            KPITargetBaselineSettings.SwitchToTargetPropertyTab();
            TimeManager.ShortPause();

            KPITargetBaselineSettings.SelectYear("2010");
            TimeManager.LongPause();
            TimeManager.LongPause();

            TimeManager.LongPause();
            TimeManager.LongPause();

            KPITargetBaselineSettings.ViewCalculationRule();
            TimeManager.ShortPause();

            //KPITargetBaselineSettings.BackFromCalculationRule();
            TimeManager.LongPause();
            TimeManager.LongPause();
            //KPITargetBaselineSettings.ViewCalculationRule();
            TimeManager.ShortPause();

            KPITargetBaselineSettings.CreateCalculationRule();
            TimeManager.ShortPause();

            KPITargetBaselineSettings.SelectWorkdayRuleEndTime("22:00", 1);
            TimeManager.LongPause();
            KPITargetBaselineSettings.SelectWorkdayRuleEndTime("23:00", 2);
            TimeManager.LongPause();
            KPITargetBaselineSettings.FillInWorkdayRuleValue("20", 1);
            TimeManager.ShortPause();
            KPITargetBaselineSettings.FillInWorkdayRuleValue("28", 2);
            TimeManager.ShortPause();
            KPITargetBaselineSettings.SelectNonworkdayRuleEndTime("18:00",1);
            TimeManager.ShortPause();
            KPITargetBaselineSettings.SelectNonworkdayRuleEndTime("23:00",2);
            TimeManager.ShortPause();
            KPITargetBaselineSettings.FillInNonworkdayRuleValue("23",1);
            TimeManager.ShortPause();
            KPITargetBaselineSettings.FillInNonworkdayRuleValue("25",2);
            TimeManager.ShortPause();

            KPITargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.FillInSpecialdayRuleValue("10.5",1);
            TimeManager.ShortPause();
            KPITargetBaselineSettings.FillInSpecialdayRuleValue("12.5",2);
            TimeManager.ShortPause();                             
            
        }       
    }
}
