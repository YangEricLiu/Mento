﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class ExampleData : TestDataBase<ExampleInputData, ExampleExpectedData>
    {

    }

    public class ExampleInputData : InputTestDataBase
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public ExampleInputData(int number1, int number2)
        {
            this.Number1 = number1;
            this.Number2 = number2;
        }
    }

    public class ExampleExpectedData : ExpectedTestDataBase
    {
        public int Result { get; set; }

        public ExampleExpectedData(int result)
        {
            this.Result = result;
        }
    }
}
