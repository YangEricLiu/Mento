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
        public string Name { get; set; }
        public string Commodity { get; set; }
        public string KPIType { get; set; }
        public string LabellingLevel { get; set; }
        public string[] Names { get; set; }
        public string[] Commoditys { get; set; }
        public string[] KPITypes { get; set; }
        public string[] LabellingLevels { get; set; }
    }
    public class CustomizedLabellingSettingExpectedData : InputTestDataBase
    {
        public string Name { get; set; }
        public string Commodity { get; set; }
        public string KPIType { get; set; }
        public string LabellingLevel { get; set; }
        public string[] Names { get; set; }
        public string[] Commoditys { get; set; }
        public string[] KPITypes { get; set; }
        public string[] LabellingLevels { get; set; }
    }
}
