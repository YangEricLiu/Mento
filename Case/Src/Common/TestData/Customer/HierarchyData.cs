﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class HierarchyData : TestDataBase<HierarchyInputData, HierarchyExpectedData>
    {
    }

    public class HierarchyInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Industry { get; set; }
        public string Zone { get; set; }
        public string Comments { get; set; }
        public string[] TagNames { get; set; }
        public string[] AreaNodePath { get; set; }
        public string[] SystemDimensionItemPath { get; set; }
    }

    public class HierarchyExpectedData : VtagOuputData
    {
        public string[] HierarchyNodePath { get; set; }
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Industry { get; set; }
        public string Zone { get; set; }
        public string Comments { get; set; }
        public string[] Messages { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
