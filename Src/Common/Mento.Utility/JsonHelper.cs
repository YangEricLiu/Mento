using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Utility
{
    public static class JsonHelper
    {
        private static fastJSON.JSONParamters _jsonParams = new fastJSON.JSONParamters() { UseExtensions = true, UsingGlobalTypes = true, UseUTCDateTime = false, };
        private static fastJSON.JSON _json = fastJSON.JSON.Instance;

        public static string Object2String(Object obj)
        {
            return _json.ToJSON(obj, _jsonParams);
        }

        public static T String2Object<T>(string str)
        {
            _json.Param = _jsonParams;
            return _json.ToObject<T>(str);
        }

        public static object String2Object(string str)
        {
            _json.Param = _jsonParams;
            return _json.ToObject(str);
        }

        public static string Beautify(string str)
        {
            return _json.Beautify(str);
        }
    }
}
