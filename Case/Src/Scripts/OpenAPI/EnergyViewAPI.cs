using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mento.Framework.Script;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using Mento.Framework.Configuration;
using Mento.TestApi.TestData;
using Mento.ScriptCommon.TestData.OpenAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mento.Utility;

namespace Mento.Script.OpenAPI
{
    [TestFixture]
    public class EnergyViewAPI : TestSuiteBase
    {
        string urlHeader = ExecutionConfig.Url;

        [SetUp]
        public void CaseSetUp()
        {
            
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }

        private static string appKey = "2spry01f9atshr08nljq21it";
        private static string secret = "ThDhX8hX0MccCNEGgUHI89KK7gFg=";
        private static string pathTestCase = @"E:\OpenAPITest\OpenApi Test Cases_1.9.2.90.xlsx";
        private static string pathCaseResult = @"E:\OpenAPITest\OpenApi Test Cases_1.9.2.90_Result.xlsx";

        //[Test]
        //[MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        //public void EnergyAnalysisOpenAPI(OpenAPIData input)
        //{
        //    string appKey = "2spry01f9atshr08nljq21it";
        //    //string body = input.InputData.RequestBody;
        //    string body = "{\"CustomerCode\":\"NancyOtherCustomer3\",\"ProcessPrecision\":true,\"ViewOption\":{\"DataOption\":null,\"Step\":1,\"TimeRanges\":[{\"EndTime\":\"/Date(1357012800000)/\",\"StartTime\":\"/Date(1356984000000)/\"}],\"ValueOptions\":[1]},\"TagCodes\":[\"Rankingtag1\",\"Rankingtag2\",\"Rankingtag3\",\"Rankingtag4\",\"Rankingtag5\",\"Rankingtag6\",\"Rankingtag7\",\"Rankingtag8\",\"Rankingtag9\",\"Rankingtag10\"]}";
        //    string secret = "ThDhX8hX0MccCNEGgUHI89KK7gFg=";
        //    string url = urlHeader + input.InputData.url;

        //    var requet = HttpWebRequest.Create(url);

        //    //request header
        //    requet.ContentType = "application/json";
        //    requet.Headers.Add("X-Auth-AppKey", appKey);

        //    requet.Method = "POST";

        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] ciphertext = md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(appKey + body + secret));

        //    var s = BitConverter.ToString(ciphertext).Replace("-", string.Empty);

        //    requet.Headers.Add("X-Auth-Fig", s);

        //    //requet body
        //    var requestBodyBytes = Encoding.UTF8.GetBytes(body);

        //    using (var requestBodyStream = requet.GetRequestStream())
        //    {
        //        requestBodyStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
        //    }

        //    try
        //    {
        //        using (var repsonse = requet.GetResponse())
        //        {
        //            using (var reponseStream = repsonse.GetResponseStream())
        //            {
        //                using (var sr = new StreamReader(reponseStream, Encoding.UTF8))
        //                {
        //                    string outString = ConvertJson.String2Json(sr.ReadToEnd().ToString());
        //                    string outString2 = ConvertJson.String2Json(body);

        //                    RequestDataBody ttest = RequestDataDtoConvertor.GetRequestDataDtoGroup(outString2);
        //                    Console.Out.WriteLine(ttest.DataBody);
                            
        //                    //Console.Out.WriteLine("\n\n");
        //                    //Console.Out.WriteLine(outString);
        //                    //string pathTestCase = @"D:\OpenApiTestCasesSource.xlsx";
        //                    //string sheetName = "Energy view-饼图接口";
        //                    //string pathCaseResult = @"D:\OpenApiTestCasesResult.xlsx";

        //                    //OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);

        //                    //Cases[0].expectedResponseBody = outString;

        //                    //ExcelHelper.ImportOpenAPICasesToExcel(Cases, pathCaseResult, sheetName);

        //                    //JArray testja = JsonHelper.Deserialize2Array(outString);

        //                    //JArray testja2 = (JArray)testja[0]["TargetEnergyData"];

        //                    //Console.Out.WriteLine(testja[0].ToString());
        //                    //Console.Out.WriteLine(testja2[0]["EnergyData"].ToString());

        //                    //JObject testja3 = (JObject)testja2[0]["EnergyData"];

        //                    //Console.Out.WriteLine(testja3.ToString());

        //                    //EnergyViewDataBody[] jds = EnergyViewDataDtoConvertor.GetEnergyViewDataDtoGroups(outString);

        //                    //foreach (EnergyViewDataBody jd in jds)
        //                    //{
        //                    //    //Console.Out.WriteLine(jd.EnergyViewDatas);
        //                    //    //Console.Out.WriteLine("\n\n");

        //                    //    //Console.Out.WriteLine(jd.TargetEnergyData);
        //                    //    //Console.Out.WriteLine("\n\n");

        //                    //    //Console.Out.WriteLine(jd.EnergyData);
        //                    //    //Console.Out.WriteLine("\n\n");

        //                    //    Console.Out.WriteLine(jd.Target);
        //                    //    Console.Out.WriteLine("\n\n");

        //                    //    Console.Out.WriteLine(jd.Name);
        //                    //    Console.Out.WriteLine("\n\n");

        //                    //    Console.Out.WriteLine(jd.Type);
        //                    //    Console.Out.WriteLine("\n\n");

        //                    //    Console.Out.WriteLine(jd.TimeSpan);
        //                    //    Console.Out.WriteLine("\n\n");
        //                    //}
                                  
        //                    //ExportToTextFiles.ExportDestinationTextFiles("ex.txt", outString);

        //                    //ExportToTextFiles.CompareSDTextFiles("ac.txt", "ex.txt", "2.txt", outString);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        
        //[Test]
        //[MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        //public void ExcelReadAndWriteTest(OpenAPIData input)
        //{
        //    string pathTestCase = @"E:\OpenApiTestCasesSource.xlsx";
        //    string sheetName = "Energy view-饼图接口";
        //    string pathCaseResult = @"E:\OpenApiTestCasesResult.xlsx";

        //    OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);
        //    for (int i = 0; i < Cases.Length; i++)
        //    {
        //        Console.Out.WriteLine(Cases[i].url);
        //        Console.Out.WriteLine(Cases[i].requestBody);
        //        Console.Out.WriteLine(Cases[i].expectedResponseBody);
        //        Console.Out.WriteLine(Cases[i].actualResponseBody);
        //        Console.Out.WriteLine("\n\n");
        //    }

        //    ExcelHelper.ImportOpenAPICasesToExcel(Cases, pathTestCase, pathCaseResult, sheetName);
        //}

        //[Test]
        //[MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        //public void CompareStringsTest(OpenAPIData input)
        //{
        //    string pathTestCase = @"E:\OpenApiTestCasesSource.xlsx";
        //    string sheetName = "Energy view-饼图接口";

        //    OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);

        //    string expectedStr;
        //    string actualStr;

        //    CompareReport report = new CompareReport();
        //    bool isOutResult;

        //    for (int i = 0; i < Cases.Length; i++)
        //    {
        //        expectedStr = Cases[i].expectedResponseBody;
        //        actualStr = Cases[i].actualResponseBody;

        //        report = CompareResponseBody.CompareEnergyUseResponseBody(expectedStr, actualStr, out isOutResult);
        //        Console.Out.WriteLine(report.errorMessage);
        //        Console.Out.WriteLine("\n\n");
        //        Console.Out.WriteLine(report.detailedInfo);
        //        Console.Out.WriteLine("\n\n");
        //    }
        //}

        //[Test]
        //[MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        //public void RequestToResponse(OpenAPIData input)
        //{

        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] ciphertext;
        //    string pathTestCase = @"E:\OpenApiTestCasesSource.xlsx";
        //    string sheetName = "Energy view-单层级多层级接口";

        //    OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);
        //    string requestBody = "";
        //    for (int i = 0; i < Cases.Length; i++)
        //    {
        //        requestBody = Cases[i].requestBody;
        //        Console.Out.WriteLine(Cases[i].url);
        //        Console.Out.WriteLine(Cases[i].requestBody);
        //        Console.Out.WriteLine("\n\n");

        //        WebRequest request = HttpWebRequest.Create(Cases[i].url);
        //        request.ContentType = "application/json";
        //        request.Headers.Add("X-Auth-AppKey", appKey);
        //        request.Method = "POST";
        //        ciphertext = md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(appKey + requestBody + secret));
        //        string s = BitConverter.ToString(ciphertext).Replace("-", string.Empty);
        //        request.Headers.Add("X-Auth-Fig", s);

        //        var requestBodyBytes = Encoding.UTF8.GetBytes(requestBody);
        //        using (var requestBodyStream = request.GetRequestStream())
        //        {
        //            requestBodyStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
        //        }
        //        using (var repsonse = request.GetResponse())
        //        {
        //            using (var reponseStream = repsonse.GetResponseStream())
        //            {
        //                using (var sr = new StreamReader(reponseStream, Encoding.UTF8))
        //                {
        //                    string outString = ConvertJson.String2Json(sr.ReadToEnd().ToString());
        //                    Cases[i].actualResponseBody = outString;
        //                }
        //            }
        //        }
        //        Console.Out.WriteLine("\n\n");
        //        Console.Out.WriteLine("!!!!!!!!!!!!ResponseBody!!!!!!!!!!!!!!!!!!!!");
        //        Console.Out.WriteLine(Cases[i].actualResponseBody);
        //        Console.Out.WriteLine("!!!!!!!!!!!!ResponseBody!!!!!!!!!!!!!!!!!!!!");
        //        Console.Out.WriteLine("\n\n");

        //    }

        //}

        //[Test]
        //[MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        //public void ReportTemplate(OpenAPIData input)
        //{
        //    //Define the path for test case source excel file and result file
        //    string pathTestCase = @"E:\OpenApiTestCasesSource.xlsx";
        //    string sheetName = "Energy view-饼图接口";
        //    string pathCaseResult = @"E:\OpenApiTestCasesResult.xlsx";

        //    //Read the test cases data from excel to TestCases[]
        //    OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);
        //    string expectedStr;
        //    string actualStr;
        //    CompareReport report = new CompareReport();
        //    bool isOutResult;

        //    //Compare the strings
        //    for (int i = 0; i < Cases.Length; i++)
        //    {
        //        Console.Out.WriteLine(Cases[i].url);
        //        Console.Out.WriteLine(Cases[i].requestBody);
        //        Console.Out.WriteLine(Cases[i].expectedResponseBody);
        //        Console.Out.WriteLine(Cases[i].actualResponseBody);
        //        Console.Out.WriteLine("\n\n");

        //        expectedStr = Cases[i].expectedResponseBody;
        //        actualStr = Cases[i].actualResponseBody;

        //        report = CompareResponseBody.CompareEnergyUseResponseBody(expectedStr, actualStr, out isOutResult);
        //        if (true == isOutResult)
        //            Cases[i].result = "Pass:" + report.errorMessage;
        //        else
        //            Cases[i].result = "Fail:" + report.errorMessage;
        //        Cases[i].resultReport = report.detailedInfo;
        //        Console.Out.WriteLine(report.errorMessage);
        //        Console.Out.WriteLine("\n\n");
        //        Console.Out.WriteLine(report.detailedInfo);
        //        Console.Out.WriteLine("\n\n");
        //    }

        //    //Write the result to excel file
        //    ExcelHelper.ImportOpenAPICasesToExcel(Cases, pathTestCase, pathCaseResult, sheetName);
        //}

        [Test]
        [MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        public void JazzCases(OpenAPIData input)
        {
            bool IsUpdateFlag = true;
            //Read test cases from excel to TestCases[]          
            OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, input.InputData.SheetName);

            //Get response body from request body in Cases[]
            Cases = RequestDataDtoConvertor.RequestToResponse(Cases, appKey, secret, IsUpdateFlag);

            //Compare expected response body and actual response body in Cases[]
            if (!IsUpdateFlag)//Do not need compare response bodys when update cases in excel file
                Cases = CompareResponseBody.CompareCases(Cases);

            //Write the result in Cases[] to excel file
            ExcelHelper.ImportOpenAPICasesToExcel(Cases, pathTestCase, pathCaseResult, input.InputData.SheetName);
        }

        [Test]
        [MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-BluesBuildingMobileServiceAPI-101-1")]
        public void BluesCasesBuilding(OpenAPIData input)
        {
            //string appKey = "2spry01f9atshr08nljq21it";
            //string secret = "ThDhX8hX0MccCNEGgUHI89KK7gFg=";
            //string pathTestCase = @"D:\BluesBuildingMobileServiceAPI Test Cases.xlsx";
            //string pathCaseResult = @"D:\BluesBuildingMobileServiceAPI Test Cases_R.xlsx";


            bool IsUpdateFlag = true;
            //Read test cases from excel to TestCases[]          
            OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, input.InputData.SheetName);

            //Get response body from request body in Cases[]
            Cases = RequestDataDtoConvertor.RequestToResponse(Cases, appKey, secret, IsUpdateFlag);

            //Compare expected response body and actual response body in Cases[]
            if (!IsUpdateFlag)//Do not need compare response bodys when update cases in excel file
                Cases = CompareResponseBody.CompareCases(Cases);

            //Write the result in Cases[] to excel file
            ExcelHelper.ImportOpenAPICasesToExcel(Cases, pathTestCase, pathCaseResult, input.InputData.SheetName);
        }
        [Test]
        [MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-BluesEnergyMobileServiceAPI-101-1")]
        public void BluesCasesEnergy(OpenAPIData input)
        {
            //string appKey = "2spry01f9atshr08nljq21it";
            //string secret = "ThDhX8hX0MccCNEGgUHI89KK7gFg=";
            //string pathTestCase = @"D:\BluesBuildingMobileServiceAPI Test Cases.xlsx";
            //string pathCaseResult = @"D:\BluesBuildingMobileServiceAPI Test Cases_R.xlsx";


            bool IsUpdateFlag = false;
            //Read test cases from excel to TestCases[]          
            OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, input.InputData.SheetName);

            //Get response body from request body in Cases[]
            Cases = RequestDataDtoConvertor.RequestToResponse(Cases, appKey, secret, IsUpdateFlag);

            //Compare expected response body and actual response body in Cases[]
            if (!IsUpdateFlag)//Do not need compare response bodys when update cases in excel file
                Cases = CompareResponseBody.CompareCases(Cases);

            //Write the result in Cases[] to excel file
            ExcelHelper.ImportOpenAPICasesToExcel(Cases, pathTestCase, pathCaseResult, input.InputData.SheetName);
        }
    }
}
