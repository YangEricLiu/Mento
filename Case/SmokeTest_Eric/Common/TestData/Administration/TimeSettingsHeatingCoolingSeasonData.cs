using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class HeatingCoolingSeasonCalendarData : TestDataBase<HeatingCoolingSeasonCalendarInputData, HeatingCoolingSeasonCalendarExpectedData>
    {
    }
    public class HeatingCoolingSeasonCalendarInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public int WarmRecordNumber { get; set; }
        public int ColdRecordNumber { get; set; }
        public string[] WarmStartMonth { get; set; }
        public string[] WarmStartDate { get; set; }
        public string[] WarmEndMonth { get; set; }
        public string[] WarmEndDate { get; set; }
        public string[] ColdStartMonth { get; set; }
        public string[] ColdStartDate { get; set; }
        public string[] ColdEndMonth { get; set; }
        public string[] ColdEndDate { get; set; }

        public HeatingCoolingSeasonCalendarInputData(string name, int warmRecordNumber, int coldRecordNumber, string[] warmStartMonth, string[] warmStartDate, string[] warmEndMonth, string[] warmEndDate, string[] coldStartMonth, string[] coldStartDate, string[] coldEndMonth, string[] coldEndDate)
        {
            this.Name = name;
            this.WarmRecordNumber = warmRecordNumber;
            this.ColdRecordNumber = coldRecordNumber;
            this.WarmStartMonth = warmStartMonth;
            this.WarmStartDate = warmStartDate;
            this.WarmEndMonth = warmEndMonth;
            this.WarmEndDate = warmEndDate;
            this.ColdStartMonth = coldStartMonth;
            this.ColdStartDate = coldStartDate;
            this.ColdEndMonth = coldEndMonth;
            this.ColdEndDate = coldEndDate;
        }
    }

    public class HeatingCoolingSeasonCalendarExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public int WarmRecordNumber { get; set; }
        public int ColdRecordNumber { get; set; }
        public string[] WarmStartMonth { get; set; }
        public string[] WarmStartDate { get; set; }
        public string[] WarmEndMonth { get; set; }
        public string[] WarmEndDate { get; set; }
        public string[] ColdStartMonth { get; set; }
        public string[] ColdStartDate { get; set; }
        public string[] ColdEndMonth { get; set; }
        public string[] ColdEndDate { get; set; }

        public HeatingCoolingSeasonCalendarExpectedData(string name, int warmRecordNumber, int coldRecordNumber, string[] warmStartMonth, string[] warmStartDate, string[] warmEndMonth, string[] warmEndDate, string[] coldStartMonth, string[] coldStartDate, string[] coldEndMonth, string[] coldEndDate)
        {
            this.Name = name;
            this.WarmRecordNumber = warmRecordNumber;
            this.ColdRecordNumber = coldRecordNumber;
            this.WarmStartMonth = warmStartMonth;
            this.WarmStartDate = warmStartDate;
            this.WarmEndMonth = warmEndMonth;
            this.WarmEndDate = warmEndDate;
            this.ColdStartMonth = coldStartMonth;
            this.ColdStartDate = coldStartDate;
            this.ColdEndMonth = coldEndMonth;
            this.ColdEndDate = coldEndDate;
        }
    }
}
