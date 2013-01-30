using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Net;

namespace Mento.Utility
{
    public static class HttpRequestHelper
    {
        public static string SendPost(string url, NameValueCollection parameters, CookieCollection cookies = null, NameValueCollection headers = null)
        {
            string data = GetParameter(parameters);

            return SendPost(url, data, cookies: cookies, headers: headers);
        }

        public static string SendPost(string url, string data, CookieCollection cookies = null, NameValueCollection headers = null)
        {
            WebRequest webRequest = WebRequest.Create(url);
            HttpWebRequest httpRequest = webRequest as HttpWebRequest;

            //allows for validation of SSL certificates 
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback((o, c, x, e) => { return true; });

            byte[] bytesToPost = Encoding.UTF8.GetBytes(data);
            CookieContainer container = new CookieContainer();
            if (cookies != null)
                container.Add(httpRequest.RequestUri, cookies);

            httpRequest.Method = "POST";
            httpRequest.ContentLength = data.Length;
            httpRequest.ContentType = "application/json";
            httpRequest.CookieContainer = container;

            Stream requestStream = httpRequest.GetRequestStream();
            requestStream.Write(bytesToPost, 0, data.Length);
            requestStream.Close();

            Stream responseStream = httpRequest.GetResponse().GetResponseStream();

            string stringResponse = new StreamReader(responseStream, Encoding.UTF8).ReadToEnd();

            return stringResponse;
        }

        public static string GetParameter(NameValueCollection parameters)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < parameters.Count; i++)
            {
                string key = parameters.Keys[i];
                builder.Append(System.Web.HttpUtility.UrlEncode(key)).Append("=").Append(System.Web.HttpUtility.UrlEncode(parameters[key]));

                if (i != parameters.Count - 1)
                    builder.Append("&");
            }

            return builder.ToString();
        }

        public static CookieCollection GetCookies(string cookieString)
        {
            CookieCollection cookies = new CookieCollection();

            foreach (string pair in cookieString.Split(';'))
            {
                cookies.Add(new Cookie(pair.Split('=')[0].Trim(), pair.Split('=')[1].Trim()));
            }

            return cookies;
        }
    }
}
