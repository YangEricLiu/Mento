using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class HierarchyData : TestDataBase<HierarchyInputData, ExpectedTestDataBase>
    {
    }

    public class HierarchyInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
        
        public HierarchyInputData(string[] hierarchyNodePath, string name, string code, string type, string comment)
        {
            this.HierarchyNodePath = hierarchyNodePath;
            this.Name = name;
            this.Code = code;
            this.Type = type;
            this.Comment = comment;
        }
    }
}
