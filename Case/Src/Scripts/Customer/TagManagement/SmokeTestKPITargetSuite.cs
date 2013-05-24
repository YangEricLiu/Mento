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
    public class SmokeTestKPITargetSuite:TestSuiteBase
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
        [CaseID("TC-J1-SmokeTest-022")]
		[Priority("23")]
        [MultipleTestDataSource(typeof(KPITargetBaselineData[]), typeof(SmokeTestKPITargetSuite), "TC-J1-SmokeTest-022")]
        public void KPITargetConfigurationCalculationRevision(KPITargetBaselineData testData)
        {
            KPITargetBaselineSettings.FocusOnKPITag("KPITagForTargetBaseline");
            TimeManager.LongPause();
            KPITargetBaselineSettings.SwitchToTargetPropertyTab();
            TimeManager.LongPause();
            KPITargetBaselineSettings.SelectYear(testData.InputData.Year);
            TimeManager.ShortPause();

            #region Edit calculate values
            KPITargetBaselineSettings.ClickViewCalculationRuleButton();
            TimeManager.ShortPause();
            //KPITargetBaselineSettings.ClickModifyCalculationRuleButton();
            //TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickCreateCalculationRuleButton();
            TimeManager.ShortPause();

            //Input the Worday rule record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.WorkdayRuleRecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                KPITargetBaselineSettings.SelectWorkdayRuleEndTime(testData.InputData.WorkdayRuleEndTime[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.FillInWorkdayRuleValue(testData.InputData.WorkdayRuleValue[inputDataArrayPosition], elementPosition);
            }

            //Input the Nonworday rule record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.NonworkdayRuleRecordNumber; elementPosition++)
            {
                int inputDataArrayPosition = elementPosition - 1;
                KPITargetBaselineSettings.SelectNonworkdayRuleEndTime(testData.InputData.NonworkdayRuleEndTime[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.FillInNonworkdayRuleValue(testData.InputData.NonworkdayRuleValue[inputDataArrayPosition], elementPosition);
            }

            //Input the SpecialDates rule record(s) based on the input data file
            for (int elementPosition = 1; elementPosition <= testData.InputData.SpecialdayRuleRecordNumber; elementPosition++)
            {
                KPITargetBaselineSettings.ClickAddSpecialDatesButton();
                TimeManager.ShortPause();

                int inputDataArrayPosition = elementPosition - 1;
                KPITargetBaselineSettings.SelectSpecialdayRuleStartDate(testData.InputData.SpecialdayRuleStartDate[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.SelectSpecialdayRuleStartTime(testData.InputData.SpecialdayRuleStartTime[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.SelectSpecialdayRuleEndDate(testData.InputData.SpecialdayRuleEndDate[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.SelectSpecialdayRuleEndTime(testData.InputData.SpecialdayRuleEndTime[inputDataArrayPosition], elementPosition);
                KPITargetBaselineSettings.FillInSpecialdayRuleValue(testData.InputData.SpecialdayRuleValue[inputDataArrayPosition], elementPosition);
            }

            KPITargetBaselineSettings.ClickSaveButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickBackFromCalculationRuleButton();
            TimeManager.ShortPause();
            #endregion

            #region Calculate values
            KPITargetBaselineSettings.ClickCalculateBaselineButton();
            TimeManager.LongPause();

            Assert.AreEqual(testData.ExpectedData.AnnualCalculatedValue, KPITargetBaselineSettings.GetAnnualValue());
            TimeManager.LongPause();
            #endregion

            #region Revise calculation values
            KPITargetBaselineSettings.ClickReviseButton();
            TimeManager.ShortPause();
            KPITargetBaselineSettings.FillInAnnualRevisedValue(testData.InputData.AnnualRevisedValue);
            KPITargetBaselineSettings.FillInJanuaryRevisedValue(testData.InputData.JanuaryRevisedValue);
            KPITargetBaselineSettings.FillInFebruaryRevisedValue(testData.InputData.FebruaryRevisedValue);
            KPITargetBaselineSettings.FillInMarchRevisedValue(testData.InputData.MarchRevisedValue);
            KPITargetBaselineSettings.FillInAprilRevisedValue(testData.InputData.AprilRevisedValue);
            KPITargetBaselineSettings.FillInMayRevisedValue(testData.InputData.MayRevisedValue);
            KPITargetBaselineSettings.FillInJuneRevisedValue(testData.InputData.JuneRevisedValue);
            KPITargetBaselineSettings.FillInJulyRevisedValue(testData.InputData.JulyRevisedValue);
            KPITargetBaselineSettings.FillInAugustRevisedValue(testData.InputData.AugustRevisedValue);
            KPITargetBaselineSettings.FillInSeptemberRevisedValue(testData.InputData.SeptemberRevisedValue);
            KPITargetBaselineSettings.FillInOctoberRevisedValue(testData.InputData.OctoberRevisedValue);
            KPITargetBaselineSettings.FillInNovemberRevisedValue(testData.InputData.NovemberRevisedValue);
            KPITargetBaselineSettings.FillInDecemberRevisedValue(testData.InputData.DecemberRevisedValue);
            TimeManager.ShortPause();
            KPITargetBaselineSettings.ClickSaveButton();
            TimeManager.ShortPause();
            Assert.AreEqual(testData.InputData.AnnualRevisedValue, KPITargetBaselineSettings.GetAnnualValue());
            Assert.AreEqual(testData.InputData.JanuaryRevisedValue, KPITargetBaselineSettings.GetJanuaryValue());
            TimeManager.ShortPause();
            #endregion
        }       
    }
}
