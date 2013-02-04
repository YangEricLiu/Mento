using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace Mento.TestApi.TestData.Attribute
{
    public class IllegalInputValidationAttribute : TestCaseSourceAttribute
    {
        public IllegalInputValidationAttribute(Type testDataType)
            : base(GetSourceType(testDataType), "TestData")
        { 
        }
            

        /// <summary>
        /// Pass parameters to the data source type and get the source type
        /// </summary>
        /// <param name="testDataType">The specified test data type</param>
        /// <param name="testSuiteType">Type of test suite of the target test scipt</param>
        /// <param name="testCaseID">Test case id of the target test script</param>
        /// <returns>The test data source type</returns>
        private static Type GetSourceType(Type testDataType)
        {
            string commonDataFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\IllegalInputData.json");

            IllegalInputDataSource.TestDataType = testDataType;
            IllegalInputDataSource.CommonDataFileName = commonDataFile;

            return typeof(IllegalInputDataSource);
        }
    }
}
