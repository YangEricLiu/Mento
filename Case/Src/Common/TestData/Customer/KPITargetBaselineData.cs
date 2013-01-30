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

        public KPITargetBaselineInputData(string Year, int WorkdayRuleRecordNumber, string[] WorkdayRuleEndTime, string[] WorkdayRuleValue, int NonworkdayRuleRecordNumber, string[] NonworkdayRuleEndTime, string[] NonworkdayRuleValue, int SpecialdayRuleRecordNumber, string[] SpecialdayRuleStartDate, string[] SpecialdayRuleStartTime, string[] SpecialdayRuleEndDate, string[] SpecialdayRuleEndTime, string[] SpecialdayRuleValue, string AnnualRevisedValue, string JanuaryRevisedValue, string FebruaryRevisedValue, string MarchRevisedValue, string AprilRevisedValue, string MayRevisedValue, string JuneRevisedValue, string JulyRevisedValue, string AugustRevisedValue, string SeptemberRevisedValue, string OctoberRevisedValue, string NovemberRevisedValue, string DecemberRevisedValue)
        {
            this.Year = Year;
            this.WorkdayRuleRecordNumber = WorkdayRuleRecordNumber;
            this.WorkdayRuleEndTime = WorkdayRuleEndTime;
            this.WorkdayRuleValue = WorkdayRuleValue;
            this.NonworkdayRuleRecordNumber = NonworkdayRuleRecordNumber;
            this.NonworkdayRuleEndTime = NonworkdayRuleEndTime;
            this.NonworkdayRuleValue = NonworkdayRuleValue;
            this.SpecialdayRuleRecordNumber = SpecialdayRuleRecordNumber;
            this.SpecialdayRuleStartDate = SpecialdayRuleStartDate;
            this.SpecialdayRuleStartTime = SpecialdayRuleStartTime;
            this.SpecialdayRuleEndDate = SpecialdayRuleEndDate;
            this.SpecialdayRuleEndTime = SpecialdayRuleEndTime;
            this.SpecialdayRuleValue = SpecialdayRuleValue;
            this.AnnualRevisedValue = AnnualRevisedValue;
            this.JanuaryRevisedValue = JanuaryRevisedValue;
            this.FebruaryRevisedValue = FebruaryRevisedValue;
            this.MarchRevisedValue = MarchRevisedValue;
            this.AprilRevisedValue = AprilRevisedValue;
            this.MayRevisedValue = MayRevisedValue;
            this.JuneRevisedValue = JuneRevisedValue;
            this.JulyRevisedValue = JulyRevisedValue;
            this.AugustRevisedValue = AugustRevisedValue;
            this.SeptemberRevisedValue = SeptemberRevisedValue;
            this.OctoberRevisedValue = OctoberRevisedValue;
            this.NovemberRevisedValue = NovemberRevisedValue;
            this.DecemberRevisedValue = DecemberRevisedValue;
        }
    }

    public class KPITargetBaselineExpectedData : ExpectedTestDataBase
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

        public KPITargetBaselineExpectedData(string AnnualCalculatedValue, string JanuaryCalculatedValue, string FebruaryCalculatedValue, string MarchCalculatedValue, string AprilCalculatedValue, string MayCalculatedValue, string JuneCalculatedValue, string JulyCalculatedValue, string AugustCalculatedValue, string SeptemberCalculatedValue, string OctoberCalculatedValue, string NovemberCalculatedValue, string DecemberCalculatedValue)
        {
            this.AnnualCalculatedValue = AnnualCalculatedValue;
            this.JanuaryCalculatedValue = JanuaryCalculatedValue;
            this.FebruaryCalculatedValue = FebruaryCalculatedValue;
            this.MarchCalculatedValue = MarchCalculatedValue;
            this.AprilCalculatedValue = AprilCalculatedValue;
            this.MayCalculatedValue = MayCalculatedValue;
            this.JuneCalculatedValue = JuneCalculatedValue;
            this.JulyCalculatedValue = JulyCalculatedValue;
            this.AugustCalculatedValue = AugustCalculatedValue;
            this.SeptemberCalculatedValue = SeptemberCalculatedValue;
            this.OctoberCalculatedValue = OctoberCalculatedValue;
            this.NovemberCalculatedValue = NovemberCalculatedValue;
            this.DecemberCalculatedValue = DecemberCalculatedValue;
        }
    }
}
