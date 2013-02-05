using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.TestData
{
    public class CommonTestData
    {
        public CommonInputData InputData { get; set; }
        public CommonExpectedData ExpectedData { get; set; }
    }

    public class CommonInputData
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Comment { get; set; }
    }

    public class CommonExpectedData
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Comment { get; set; }
    }
}
