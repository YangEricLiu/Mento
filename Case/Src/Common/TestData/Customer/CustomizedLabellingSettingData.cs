using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class CustomizedLabellingSettingData : TestDataBase<CustomizedLabellingSettingInputData, CustomizedLabellingSettingExpectedData>
    {
    }
    public class CustomizedLabellingSettingInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public string[] CommonNames { get; set; }
        public string ConfigurationUser { get; set; }
        public string[] Order { get; set; }
        public string Commodity { get; set; }
        public string[] Commodities { get; set; }       
        public string  KPIType { get; set; }
        public string[] KPITypes { get; set; }
        public string LabellingLevel { get; set; }
        public string[] LabellingLevels { get; set; }
        public string LabellingLevelValue { get; set; }
        public string[] LabellingLevelValues { get; set; }
        public LabellingValue[][] LabellingValue { get; set; }
    }
    public class CustomizedLabellingSettingExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public string[] CommonNames { get; set; }
        public string ConfigurationUser { get; set; }
        public string[] Order { get; set; }
        public string Commodity { get; set; }
        public string[] Commodities { get; set; }       
        public string KPIType { get; set; }
        public string[] KPITypes { get; set; }
        public string LabellingLevel { get; set; }
        public string[] LabellingLevels { get; set; }
        public string LabellingLevelValue { get; set; }
        public string[] LabellingLevelValues { get; set; }
        public string Firstlabel { get; set; }
        public string[] Firstlabels { get; set; }
        public string Lastlabel { get; set; }
        public string[] Lastlabels { get; set; }
        public string UOM { get; set; }
        public string[] UOMs { get; set; }
        public LabellingValue[][] LabellingValue { get; set; }
    }
    public class LabellingValue
    {
        public string LabellingLeftValue { get; set; }
        public string LabellingRightValue { get; set; }
    }
}
