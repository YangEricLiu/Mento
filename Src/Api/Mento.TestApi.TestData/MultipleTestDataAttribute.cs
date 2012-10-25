using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class MultipleTestDataAttribute : TestCaseAttribute
    {
        //Type inputDatatype,Type expectedDataType, int inputDataIndex, int expectedDataIndex
        public MultipleTestDataAttribute(Type testDataType, int inputDataIndex, int expectedDataIndex)
        {
            this.arguments = this.Test(testDataType, inputDataIndex, expectedDataIndex);
        }

        private object[] Test(Type testDataType, int inputDataIndex, int expectedDataIndex)
        {
            PropertyInfo InputTestDataProperty = testDataType.GetProperty("InputData",BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo ExpectedTestDataProperty = testDataType.GetProperty("ExpectedData",BindingFlags.Public | BindingFlags.Instance);
            
            //Type InputTestDataType = InputTestDataProperty.PropertyType.GetElementType();
            //Type ExpectedTestDataType = ExpectedTestDataProperty.PropertyType.GetElementType();

            //var inputTestData = Activator.CreateInstance(InputTestDataType, 1, 2);
            //var expectedTestData = Activator.CreateInstance(ExpectedTestDataType, 3);

            MethodInfo getTestDataMethod = typeof(TestDataRepository).GetMethod("GetTestData", BindingFlags.Public | BindingFlags.Static);

            MethodInfo genericGetTestDataMethod = getTestDataMethod.MakeGenericMethod(testDataType);

            //Console.WriteLine("context:" + TestContext.CurrentContext);

            //PropertyInfo CurrentContextProperty = typeof(TestContext).GetProperty("CurrentContext", BindingFlags.Public | BindingFlags.Static);

            //object testData = genericGetTestDataMethod.Invoke(CurrentContextProperty.GetValue(null, null), null);

            
            ;
            string testCaseID = this.TestName;
            LogHelper.LogDebug("test name:" + testCaseID + "; method:" + MethodInfo.GetCurrentMethod());

            object testData = genericGetTestDataMethod.Invoke(null, new object[] { /*testCaseID*/"TA-Example-009", /*testScriptFullName*/"Automation.Administration.Calendar.ExampleSuite.TestCase9" });

            //var inputTestData = InputTestDataProperty.GetValue(testData, new object[] { inputDataIndex });
            //var expectedTestData = ExpectedTestDataProperty.GetValue(testData, new object[] { expectedDataIndex });
            var inputTestData = (Array)InputTestDataProperty.GetValue(testData, null);
            var expectedTestData = (Array)ExpectedTestDataProperty.GetValue(testData, null);



            return new object[] { inputTestData.GetValue(inputDataIndex), expectedTestData.GetValue(expectedDataIndex) };
        }
    }
}