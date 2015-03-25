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
using System.Text.RegularExpressions;

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
        public string DataOption;
        public string step;
        public string ProcessPrecision;
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

                string jsonFormatRequestBody = ConvertJson.String2Json(requestBody);
                string jsonAndLocalTimeFormatRequestBody = EnergyViewDataDtoConvertor.GetEnergyViewDataWithLocalTime(jsonFormatRequestBody);
                Cases[i].formatRequestBody = jsonAndLocalTimeFormatRequestBody;

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
                            string jsonFormatResponseBody = ConvertJson.String2Json(sr.ReadToEnd().ToString());                            
                            string jsonAndLocalTimeFormatResponseBody = EnergyViewDataDtoConvertor.GetEnergyViewDataWithLocalTime(jsonFormatResponseBody);
                            
                            //response body save to expectedResponseBody when update cases
                            if (true == flagUpdate)
                            {
                                Cases[i].expectedResponseBody = jsonFormatResponseBody;
                                Cases[i].formatExpectedResponseBody= jsonAndLocalTimeFormatResponseBody;
                            }
                            else
                            {
                                Cases[i].actualResponseBody = jsonFormatResponseBody;
                                Cases[i].formatActualResponseBody = jsonAndLocalTimeFormatResponseBody;

                            }            
                        }
                    }
                }
            }
            return Cases;
        }
    }
}
