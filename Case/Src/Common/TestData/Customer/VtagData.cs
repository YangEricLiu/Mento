﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class VtagData : TestDataBase<VtagInputData,VtagOuputData>
    {
    }

    public class VtagInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Commodity { get; set; }
        public string UOM { get; set; }
        public string Step { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }
    }
    public class VtagOuputData : ExpectedTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Commodity { get; set; }
        public string UOM { get; set; }
        public string Step { get; set; }
        public string CalculationType { get; set; }
        public string Comment { get; set; }
    }
}