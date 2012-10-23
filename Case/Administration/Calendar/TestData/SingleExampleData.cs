using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Administration.Calendar.TestData
{
    public class SingleExampleData : ISingleTestData<ExampleInputData, ExampleExpectedData>
    {
    }

    public class ExampleInputData : InputTestDataBase
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }

    public class ExampleExpectedData : ExpectedTestDataBase
    {
        public int Result { get; set; }
    }
}
