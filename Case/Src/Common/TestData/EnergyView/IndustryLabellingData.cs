using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.EnergyView
{
    public class IndustryLabellingData : TestDataBase<IndustryLabellingInput, IndustryLabellingOutput>
    {
    }

    public class IndustryLabellingInput : InputTestDataBase
    { 
        public string[][] Hierarchies { get; set; }

        public string[][] AreaDimensionPath { get; set; }

        public string[][] SystemDimensionPath { get; set; }

        public string[] tagNames { get; set; }

        public DashboardInformation[] DashboardInfo { get; set; }

        public string[][] Industries { get; set; }

        public string UnitTypeValue { get; set; }

        public string[] UnitTypeValues { get; set; }

        public string[] LabellingType { get; set; }

        public string[] Labellings{ get; set; }

        public YearAndMonth[] YearAndMonth { get; set; }

        public string[] failedFileName { get; set; }

        public MultipleHierarchyAndtags[] MultipleHierarchyAndtags { get; set; }
    }

    public class IndustryLabellingOutput : ExpectedTestDataBase
    {
        public string UnitTypeValue { get; set; }
        public string IndustryValue { get; set; }
        public string[] popupNotes { get; set; }
        public string ClearAllMessage { get; set; }
        public string[][] LabellingTooltips { get; set; }
        public string[] expectedFileName { get; set; }
        public string[] texts { get; set; }
        public string[] messages { get; set; }
    }

    public class YearAndMonth
    {
        public string year { get; set; }
        public string month { get; set; }
    }
}
