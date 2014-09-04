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

                            TargetEnergyDataDto[] testja = EnergyViewDataDtoConvertor.EnergyViewDataGroups(outString);

                            foreach (TargetEnergyDataDto j in testja)
                            {
                                Console.Out.WriteLine(j.Target.Name); 
                            }
                                                                      
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
    }
}
