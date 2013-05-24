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
    public class SmokeTestKPIBaselineSuite:TestSuiteBase
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

        /// <summary>
        /// Precondition: 1. make sure there is a KPI tag with name 'KPITagForTargetBaseline'
        ///               2. make sure the KPI tag has been associated to a hiearchy(or system or area) node
        ///               3. make sure the hiearchy node (or its upper nodes) has been configured a workday calendar '工休日日历1' for year '2010'.
        ///               4. make sure the KPI tag hasn't been configured any calculation rule for 2010 yet.
        /// </summary>        
        [Test]
        [CaseID("TC-J1-SmokeTest-023")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(SmokeTestKPIBaselineSuite), "TC-J1-SmokeTest-023")]
        public void KPIBaselineConfigurationCalculationRevision(KPITargetBaselineData testData)
        {
            KPITargetBaselineSettings.FocusOnKPITag("KPITagForTargetBaseline");
            TimeManager.ShortPause();
            KPITargetBaselineSettings.SwitchToBaselinePropertyTab();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.SelectYear("2010");
            TimeManager.ShortPause();

            #region Edit calculate values
            KPITargetBaselineSettings.ClickViewCalculationRuleButton();
            TimeManager.ShortPause();
            //KPITargetBaselineSettings.ClickModifyCalculationRuleButton();
            //TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();

            KPITargetBaselineSettings.SelectWorkdayRuleEndTime("22:00", 1);
            KPITargetBaselineSettings.SelectWorkdayRuleEndTime("23:30", 2);
            KPITargetBaselineSettings.FillInWorkdayRuleValue("1.1", 1);
            KPITargetBaselineSettings.FillInWorkdayRuleValue("2.2", 2);
            KPITargetBaselineSettings.FillInWorkdayRuleValue("0", 3);

            KPITargetBaselineSettings.SelectNonworkdayRuleEndTime("11:30", 1);
            KPITargetBaselineSettings.SelectNonworkdayRuleEndTime("22:00", 2);
            KPITargetBaselineSettings.FillInNonworkdayRuleValue("0.5", 1);
            KPITargetBaselineSettings.FillInNonworkdayRuleValue("1.2", 2);
            KPITargetBaselineSettings.FillInNonworkdayRuleValue("0", 3);

            KPITargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.SelectSpecialdayRuleStartDate("2010-1-14", 1);
            KPITargetBaselineSettings.SelectSpecialdayRuleStartTime("00:30", 1);
            KPITargetBaselineSettings.SelectSpecialdayRuleEndDate("2010-1-22", 1);
            KPITargetBaselineSettings.SelectSpecialdayRuleEndTime("12:30", 1);
            KPITargetBaselineSettings.FillInSpecialdayRuleValue("10.5", 1);
            KPITargetBaselineSettings.ClickAddSpecialDatesButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.SelectSpecialdayRuleStartDate("2010-4-5", 2);
            KPITargetBaselineSettings.SelectSpecialdayRuleStartTime("08:30", 2);
            KPITargetBaselineSettings.SelectSpecialdayRuleEndDate("2010-5-6", 2);
            KPITargetBaselineSettings.SelectSpecialdayRuleEndTime("22:30", 2);
            KPITargetBaselineSettings.FillInSpecialdayRuleValue("12.5", 2);
            TimeManager.ShortPause();

            KPITargetBaselineSettings.ClickSaveButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickBackFromCalculationRuleButton();
            TimeManager.ShortPause();
            #endregion

            #region Calculate values
            KPITargetBaselineSettings.ClickCalculateTargetButton();
            TimeManager.LongPause();

            Assert.AreEqual("6264", KPITargetBaselineSettings.GetAnnualValue());
            TimeManager.LongPause();
            #endregion

            #region Revise calculation values
            KPITargetBaselineSettings.ClickReviseButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.FillInAnnualRevisedValue("30000");
            KPITargetBaselineSettings.FillInJanuaryRevisedValue("100.1");
            KPITargetBaselineSettings.FillInFebruaryRevisedValue("100.1");
            KPITargetBaselineSettings.FillInMarchRevisedValue("100.1");
            KPITargetBaselineSettings.FillInAprilRevisedValue("100.1");
            KPITargetBaselineSettings.FillInMayRevisedValue("100.1");
            KPITargetBaselineSettings.FillInJuneRevisedValue("100.1");
            KPITargetBaselineSettings.FillInJulyRevisedValue("100.1");
            KPITargetBaselineSettings.FillInAugustRevisedValue("99");
            KPITargetBaselineSettings.FillInSeptemberRevisedValue("999");
            KPITargetBaselineSettings.FillInOctoberRevisedValue("1000");
            KPITargetBaselineSettings.FillInNovemberRevisedValue("111");
            KPITargetBaselineSettings.FillInDecemberRevisedValue("1212");
            TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickSaveButton();
            TimeManager.ShortPause();
            #endregion
        }       
    }
}
