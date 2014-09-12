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
using Schneider.REM.BL.Energy.DataContract;
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

        [Test]
        [MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        public void EnergyAnalysisOpenAPI(OpenAPIData input)
        {
            string appKey = "2spry01f9atshr08nljq21it";
            //string body = input.InputData.RequestBody;
            string body = "{\"CustomerCode\":\"NancyOtherCustomer3\",\"ProcessPrecision\":true,\"ViewOption\":{\"DataOption\":null,\"Step\":1,\"TimeRanges\":[{\"EndTime\":\"/Date(1357012800000)/\",\"StartTime\":\"/Date(1356984000000)/\"}],\"ValueOptions\":[1]},\"TagCodes\":[\"Rankingtag1\",\"Rankingtag2\",\"Rankingtag3\",\"Rankingtag4\",\"Rankingtag5\",\"Rankingtag6\",\"Rankingtag7\",\"Rankingtag8\",\"Rankingtag9\",\"Rankingtag10\"]}";
            string secret = "ThDhX8hX0MccCNEGgUHI89KK7gFg=";
            string url = urlHeader + input.InputData.url;

            var requet = HttpWebRequest.Create(url);

            //request header
            requet.ContentType = "application/json";
            requet.Headers.Add("X-Auth-AppKey", appKey);

            requet.Method = "POST";

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] ciphertext = md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(appKey + body + secret));

            var s = BitConverter.ToString(ciphertext).Replace("-", string.Empty);

            requet.Headers.Add("X-Auth-Fig", s);

            //requet body
            var requestBodyBytes = Encoding.UTF8.GetBytes(body);

            using (var requestBodyStream = requet.GetRequestStream())
            {
                requestBodyStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
            }

            try
            {
                using (var repsonse = requet.GetResponse())
                {
                    using (var reponseStream = repsonse.GetResponseStream())
                    {
                        using (var sr = new StreamReader(reponseStream, Encoding.UTF8))
                        {
                            string outString = ConvertJson.String2Json(sr.ReadToEnd().ToString());
                            string outString2 = ConvertJson.String2Json(body);

                            RequestDataBody ttest = RequestDataDtoConvertor.GetRequestDataDtoGroup(outString2);
                            Console.Out.WriteLine(ttest.DataBody);
                            
                            //Console.Out.WriteLine("\n\n");
                            //Console.Out.WriteLine(outString);
                            //string pathTestCase = @"D:\OpenApiTestCasesSource.xlsx";
                            //string sheetName = "Energy view-饼图接口";
                            //string pathCaseResult = @"D:\OpenApiTestCasesResult.xlsx";

                            //OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);

                            //Cases[0].expectedResponseBody = outString;

                            //ExcelHelper.ImportOpenAPICasesToExcel(Cases, pathCaseResult, sheetName);

                            //JArray testja = JsonHelper.Deserialize2Array(outString);

                            //JArray testja2 = (JArray)testja[0]["TargetEnergyData"];

                            //Console.Out.WriteLine(testja[0].ToString());
                            //Console.Out.WriteLine(testja2[0]["EnergyData"].ToString());

                            //JObject testja3 = (JObject)testja2[0]["EnergyData"];

                            //Console.Out.WriteLine(testja3.ToString());

                            //EnergyViewDataBody[] jds = EnergyViewDataDtoConvertor.GetEnergyViewDataDtoGroups(outString);

                            //foreach (EnergyViewDataBody jd in jds)
                            //{
                            //    //Console.Out.WriteLine(jd.EnergyViewDatas);
                            //    //Console.Out.WriteLine("\n\n");

                            //    //Console.Out.WriteLine(jd.TargetEnergyData);
                            //    //Console.Out.WriteLine("\n\n");

                            //    //Console.Out.WriteLine(jd.EnergyData);
                            //    //Console.Out.WriteLine("\n\n");

                            //    Console.Out.WriteLine(jd.Target);
                            //    Console.Out.WriteLine("\n\n");

                            //    Console.Out.WriteLine(jd.Name);
                            //    Console.Out.WriteLine("\n\n");

                            //    Console.Out.WriteLine(jd.Type);
                            //    Console.Out.WriteLine("\n\n");

                            //    Console.Out.WriteLine(jd.TimeSpan);
                            //    Console.Out.WriteLine("\n\n");
                            //}
                                  
                            //ExportToTextFiles.ExportDestinationTextFiles("ex.txt", outString);

                            //ExportToTextFiles.CompareSDTextFiles("ac.txt", "ex.txt", "2.txt", outString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Test]
        [MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        public void ExcelReadAndWriteTest(OpenAPIData input)
        {
            string pathTestCase = @"C:\OpenApiTestCasesSource.xlsx";
            string sheetName = "Energy view-饼图接口";
            string pathCaseResult = @"C:\OpenApiTestCasesResult.xlsx";

            OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);
            for (int i = 0; i < Cases.Length; i++)
            {
                Console.Out.WriteLine(Cases[i].url);
                Console.Out.WriteLine(Cases[i].requestBody);
                Console.Out.WriteLine(Cases[i].expectedResponseBody);
                Console.Out.WriteLine(Cases[i].actualResponseBody);
                Console.Out.WriteLine("\n\n");
            }

            ExcelHelper.ImportOpenAPICasesToExcel(Cases, pathTestCase, pathCaseResult, sheetName);
        }

        [Test]
        [MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        public void EnergyAnalysisOpenAPI3(OpenAPIData input)
        {
            string pathTestCase = @"D:\OpenApiTestCasesSource.xlsx";
            string sheetName = "Energy view-饼图接口";
            //string pathCaseResult = @"D:\OpenApiTestCasesResult.xlsx";
            OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);
            //bool resultNew = true;

            //string expectedStr = Cases[0].expectedResponseBody;
            //string actualStr = Cases[0].actualResponseBody;

            //Console.Out.WriteLine("\n\n");
            //Console.Out.WriteLine(Cases[0].expectedResponseBody);
            //Console.Out.WriteLine("\n\n");
            //Console.Out.WriteLine(Cases[0].actualResponseBody);
            //Console.Out.WriteLine("\n\n");

            //string exOutString = ConvertJson.String2Json(expectedStr);
            //Console.Out.WriteLine(exOutString);
            //EnergyViewDataBody[] exjds = EnergyViewDataDtoConvertor.GetEnergyViewDataDtoGroups(exOutString);
            //string acOutString = ConvertJson.String2Json(actualStr);
            //Console.Out.WriteLine(acOutString);
            //EnergyViewDataBody[] acjds = EnergyViewDataDtoConvertor.GetEnergyViewDataDtoGroups(acOutString);

            //CompareReport report = new CompareReport();
            ////report = CompareResponseBody.CompareMatchedResponseBody(exjds, acjds);
            //report = CompareResponseBody.CompareEnergyUseResponseBody(exOutString, acOutString, out resultNew);
            //Console.Out.WriteLine(report.errorMessage);
            //Console.Out.WriteLine("\n\n");
            //Console.Out.WriteLine(report.detailedInfo);
            //Console.Out.WriteLine("\n\n");
        }

        [Test]
        [MultipleTestDataSource(typeof(OpenAPIData[]), typeof(EnergyViewAPI), "TC-J1-FVT-EnergyAnalysisOpenAPI-101-1")]
        public void CompareStringsTest(OpenAPIData input)
        {
            string pathTestCase = @"C:\OpenApiTestCasesSource.xlsx";
            string sheetName = "Energy view-饼图接口";

            OpenAPICases[] Cases = ExcelHelper.ImportToOpenAPICases(pathTestCase, sheetName);

            string expectedStr;
            string actualStr;

            CompareReport report = new CompareReport();
            bool isOutResult;

            for (int i = 0; i < Cases.Length; i++)
            {
                expectedStr = Cases[i].expectedResponseBody;
                actualStr = Cases[i].actualResponseBody;

                report = CompareResponseBody.CompareEnergyUseResponseBody(expectedStr, actualStr, out isOutResult);
                Console.Out.WriteLine(report.errorMessage);
                Console.Out.WriteLine("\n\n");
                Console.Out.WriteLine(report.detailedInfo);
                Console.Out.WriteLine("\n\n");
            }
        }
    }
}
