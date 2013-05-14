using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.SmokeTest
{
    public class AreaDimensionData : TestDataBase<AreaDimensionInputData, AreaDimensionExpectedData>
    {
    }

    public class AreaDimensionInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string[] AreaNodePath { get; set; }
        public string CommonName { get; set; }
        public string Comments { get; set; }
    }

    public class AreaDimensionExpectedData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string[] AreaNodePath { get; set; }
        public string CommonName { get; set; }
        public string Comments { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
