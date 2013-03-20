using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace Mento.Utility.Http
{
    public static class HttpCommon
    {
        public const string LINEBREAK = "\r\n";

        public const string COLON = ":";

        public const string SPACE = " ";

        public const string HTTP10 = "HTTP/1.0";

        public static string GetHeaders(NameValueCollection headers)
        {
            StringBuilder headerBuilder = new StringBuilder();

            for (int i = 0; i < headers.Count; i++)
                headerBuilder.Append(headers.GetKey(i)).Append(COLON).Append(SPACE).Append(headers.Get(i)).Append(LINEBREAK);

            return headerBuilder.ToString();
        }

        public static NameValueCollection GetHeaders(string headerContent)
        {
            NameValueCollection headers = new NameValueCollection();

            string[] result = Regex.Split(headerContent, @"\r\n", RegexOptions.Multiline);

            for (int i = 1; i < result.Length; i++)
            {
                string headerLine = result[i].Trim();
                if (!String.IsNullOrEmpty(headerLine))
                {
                    string[] headersPair = Regex.Split(headerLine, COLON + SPACE);
                    headers.Add(headersPair[0].Trim(), headersPair[1].Trim());
                }
            }

            return headers;
        }

        public static string Parameter(Dictionary<string, string> parameters)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < parameters.Count; i++)
            {
                string key = parameters.Keys.ToArray()[i];
                builder.Append(HttpUtility.UrlEncode(key)).Append("=").Append(HttpUtility.UrlEncode(parameters[key]));
                //builder.Append(key).Append("=").Append(parameters[key]);

                if (i != parameters.Count - 1)
                    builder.Append("&");
            }

            return builder.ToString();
        }

        public static string UrlEncode(string content)
        {
            return HttpUtility.UrlEncode(content);
        }
    }
}
