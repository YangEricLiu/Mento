using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.SmokeTest
{
    public class AssociateTagData : TestDataBase<AssociateTagInputData, AssociateTagExpectedData>
    {
    }
        public class AssociateTagInputData : InputTestDataBase
        {
            public string[] HierarchyNodePath { get; set; }
            public string[] SystemDimensionPath { get; set; }
            public string[] AreaDimensionPath { get; set; }
            public string TagName { get; set; }
            public string[] TagNames { get; set; }
        }

        public class AssociateTagExpectedData : ExpectedTestDataBase
        {
            public string[] HierarchyNodePath { get; set; }
            public string[] SystemDimensionPath { get; set; }
            public string[] AreaDimensionPath { get; set; }
            public string TagName { get; set; }
            public string[] TagNames { get; set; }
            public string Message { get; set; }
            public string ErrorMessage { get; set; }
        }

}
