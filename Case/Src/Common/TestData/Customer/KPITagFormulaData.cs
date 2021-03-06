﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class KPITagFormulaData : TestDataBase<KPIFormulaInputData, KPIFormulaExpectedData>
    {
    }
    public class KPIFormulaInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string Formula { get; set; }

        public KPIFormulaInputData(string name,string formula)
        {
            this.Name = name;
            this.Formula = formula;
            
        }
    }

    public class KPIFormulaExpectedData : VtagOuputData
    {
       public string Name { get; set; }
        public string Formula { get; set; }

        public KPIFormulaExpectedData(string name,string formula)
        {
            this.Name = name;
            this.Formula = formula;
            
        }
    }
}
