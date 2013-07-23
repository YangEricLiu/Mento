using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class KPITargetBaselineData : TestDataBase<KPITargetBaselineInputData, KPITargetBaselineExpectedData>
    {
    }
    public class KPITargetBaselineInputData : InputTestDataBase
    {
        public string Year { get; set; } 
        public int WorkdayRuleRecordNumber { get; set; }        
        public string[] WorkdayRuleEndTime { get; set; }
        public string[] WorkdayRuleValue { get; set; }
        public int NonworkdayRuleRecordNumber { get; set; }        
        public string[] NonworkdayRuleEndTime { get; set; }
        public string[] NonworkdayRuleValue { get; set; }
        public int SpecialdayRuleRecordNumber { get; set; }
        public string[] SpecialdayRuleStartDate { get; set; }
        public string[] SpecialdayRuleStartTime { get; set; }
        public string[] SpecialdayRuleEndDate { get; set; }
        public string[] SpecialdayRuleEndTime { get; set; }
        public string[] SpecialdayRuleValue { get; set; }
        public string AnnualRevisedValue { get; set; }
        public string JanuaryRevisedValue { get; set; }
        public string FebruaryRevisedValue { get; set; }
        public string MarchRevisedValue { get; set; }
        public string AprilRevisedValue { get; set; }
        public string MayRevisedValue { get; set; }
        public string JuneRevisedValue { get; set; }
        public string JulyRevisedValue { get; set; }
        public string AugustRevisedValue { get; set; }
        public string SeptemberRevisedValue { get; set; }
        public string OctoberRevisedValue { get; set; }
        public string NovemberRevisedValue { get; set; }
        public string DecemberRevisedValue { get; set; }
        public string TagType { get; set; }
        public string TagName { get; set; }
    }

    public class KPITargetBaselineExpectedData : VtagOuputData
    {
        public string AnnualCalculatedValue { get; set; }
        public string JanuaryCalculatedValue { get; set; }
        public string FebruaryCalculatedValue { get; set; }
        public string MarchCalculatedValue { get; set; }
        public string AprilCalculatedValue { get; set; }
        public string MayCalculatedValue { get; set; }
        public string JuneCalculatedValue { get; set; }
        public string JulyCalculatedValue { get; set; }
        public string AugustCalculatedValue { get; set; }
        public string SeptemberCalculatedValue { get; set; }
        public string OctoberCalculatedValue { get; set; }
        public string NovemberCalculatedValue { get; set; }
        public string DecemberCalculatedValue { get; set; }
        public string CalendarInfoTips { get; set; }
    }
}
