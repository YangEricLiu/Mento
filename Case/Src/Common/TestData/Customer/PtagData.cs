﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class PtagData : TestDataBase<PtagInputData, PtagExpectedData>
    {
    }
    public class PtagInputData : InputTestDataBase
    {
        public string[] CommonNameArray { get; set; }
        public string OriginalName { get; set; }
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Meter { get; set; }
        public string Channel { get; set; }
        public string Commodity { get; set; }
        public string Uom { get; set; }
        public string CollectCycle { get; set; }
        public string CalculationType { get; set; }
        public string Slope { get; set; }
        public string Offset { get; set; }
        public string Comments { get; set; }
        public string AccumulateText { get; set; }        
        public ManualTimeRange[] ManualTimeRange { get; set; }
        public int[] RowID { get; set; }
        public string[] TestData { get; set; }
        public string[] Uoms { get; set; }
        public string DoubleNagtiveValue { get; set; }

    }

    public class PtagExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Meter { get; set; }
        public string Channel { get; set; }
        public string Commodity { get; set; }
        public string Uom { get; set; }
        public string CollectCycle { get; set; }
        public string CalculationType { get; set; }
        public string Slope { get; set; }
        public string Offset { get; set; }
        public string Comments { get; set; }
        public string Message { get; set; }
        public string[] MessageArray { get; set; }
        public string AccumulateText { get; set; }
        public string DoubleNagtiveValue { get; set; }
    }

    public class ManualTimeRange
    {
        public string StartDate;
        public string StartTime;
        public string EndDate;
        public string EndTime;
    }


}
