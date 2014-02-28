using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;


namespace Mento.ScriptCommon.TestData.Administration
{
    public class IndustryLabelingData : TestDataBase<LabelingInputData, LabelingExpectedData>
    {
    }

    public class LabelingInputData : InputTestDataBase
     {
         public string   Industry { get; set; }
         public string[] Industrys { get; set; }
         public string   ClimaticRegion { get; set; }
         public string[] ClimaticRegions { get; set; }
         public string   EnergyEfficiencyLabellingLevel { get; set; }
         public string[] EnergyEfficiencyLabellingLevels { get; set; }
         public string   StartYear { get; set; }
         public string[] StartYears { get; set; }
         public string   EndYear { get; set; }
         public string[] EndYears { get; set; }

     }

    public class LabelingExpectedData : ExpectedTestDataBase
     {
         public string   Industry { get; set; }
         public string[] Industrys { get; set; }
         public string   ClimaticRegion { get; set; }
         public string[] ClimaticRegions { get; set; }
         public string   EnergyEfficiencyLabellingLevel { get; set; }
         public string[] EnergyEfficiencyLabellingLevels { get; set; }
         public string   StartYear { get; set; }
         public string[] StartYears { get; set; }
         public string   EndYear { get; set; }
         public string[] EndYears { get; set; }

     }
}
