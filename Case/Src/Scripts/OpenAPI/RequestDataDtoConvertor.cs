using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Schneider.REM.BL.Energy.DataContract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mento.Utility;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace Mento.Script.OpenAPI
{
    public struct RequestDataBody
    {
        public string DataBody;
        public string CustomerCode;
        public string ViewOption;
        public string TimeRanges;
        public string ValueOptions;
        public string TagCodes;
    }

    public class RequestDataDtoConvertor
    {
        public static RequestDataBody GetRequestDataDtoGroup(string sourceOrginal)
        {
            //string source = ConvertJson.String2Json(sourceOrginal);

            JObject requestData = (JObject)JsonConvert.DeserializeObject(sourceOrginal);

            RequestDataBody tmprdb = new RequestDataBody();

            tmprdb.DataBody = requestData.ToString();
            tmprdb.CustomerCode = requestData["CustomerCode"].ToString();
            tmprdb.ViewOption = requestData["ViewOption"].ToString();
            tmprdb.TagCodes = requestData["TagCodes"].ToString();

            JObject viewOption = (JObject)requestData["ViewOption"];
            tmprdb.TimeRanges = viewOption["TimeRanges"].ToString();
            tmprdb.ValueOptions = viewOption["ValueOptions"].ToString();

            return tmprdb;
        }

        public static OpenAPICases[] RequestToResponse(OpenAPICases[] Cases, string appKey, string secret, bool flagUpdate=false)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] ciphertext;

            string requestBody = "";
            for (int i = 0; i < Cases.Length; i++)
            {
                requestBody = Cases[i].requestBody;
                Console.Out.WriteLine(Cases[i].url);
                Console.Out.WriteLine(Cases[i].requestBody);
                Console.Out.WriteLine("\n\n");

                WebRequest request = HttpWebRequest.Create(Cases[i].url);
                request.ContentType = "application/json";
                request.Headers.Add("X-Auth-AppKey", appKey);
                request.Method = "POST";
                ciphertext = md5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(appKey + requestBody + secret));
                string s = BitConverter.ToString(ciphertext).Replace("-", string.Empty);
                request.Headers.Add("X-Auth-Fig", s);

                var requestBodyBytes = Encoding.UTF8.GetBytes(requestBody);
                using (var requestBodyStream = request.GetRequestStream())
                {
                    requestBodyStream.Write(requestBodyBytes, 0, requestBodyBytes.Length);
                }
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        using (var sr = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            string outString = ConvertJson.String2Json(sr.ReadToEnd().ToString());
                            //response body save to expectedResponseBody when update cases
                            if (true == flagUpdate)
                                Cases[i].expectedResponseBody = outString;
                            else
                                Cases[i].actualResponseBody = outString;
                        }
                    }
                }
                //Console.Out.WriteLine("\n\n");
                //Console.Out.WriteLine("!!!!!!!!!!!!ResponseBody!!!!!!!!!!!!!!!!!!!!");
                //Console.Out.WriteLine(Cases[i].actualResponseBody);
                //Console.Out.WriteLine("!!!!!!!!!!!!ResponseBody!!!!!!!!!!!!!!!!!!!!");
                //Console.Out.WriteLine("\n\n");

            }
            return Cases;
        }
    }
}
