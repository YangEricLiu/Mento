using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class SystemDimensionData : TestDataBase<SystemDimensionInputData, SystemDimensionExpectedData>
    {
    }

    public class SystemDimensionInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string[] SystemDimensionItemPath { get; set; }
    }

    public class SystemDimensionExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string[] SystemDimensionPath { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
