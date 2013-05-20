using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class HierarchyDataTree : TestDataBase<HierarchyTreeInputData, HierarchyTreeExpectedData>
    {
    }

    public class HierarchyTreeInputData : InputTestDataBase
    {
        public InList[] InList { get; set; }
    }

    public class HierarchyTreeExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class InList
    {
        public string[] HierarchyNodePath { get; set; }
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
    }
}
