using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.TestData
{
    public static class IllegalInputDataSource
    {
        public static Type TestDataType { get; set; }

        public static string CommonDataFileName { get; set; }

        public static object[] TestData
        {
            get
            {
                return TestDataRepository.GetTestDataElementArray(TestDataType, CommonDataFileName);
            }
        }
    }
}
