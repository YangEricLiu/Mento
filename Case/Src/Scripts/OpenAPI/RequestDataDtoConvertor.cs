using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Schneider.REM.BL.Energy.DataContract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    }
}
