using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using Mento.Utility.Http;
using System.Text.RegularExpressions;

namespace Mento.Framework.DataAccess
{
    public static class JazzLoginHelper
    {
        private static NameValueCollection CommonHeaders
        {
            get
            {
                NameValueCollection headers = new NameValueCollection();

                headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
                headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                headers.Add("Accept-Language", "en-US,en;q=0.8");
                headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.17 (KHTML, like Gecko) Chrome/24.0.1312.57 Safari/537.17");

                return headers;
            }
        }

        private static Dictionary<string, string> User = new Dictionary<string, string>() 
        {
            { "txtUserName" , "PlatformAdmin" },
            { "txtPassword" , "P@ssw0rd" },
        };

        public static CookieCollection GetFedAuthCookie(string homeUrl)
        {
            Console.WriteLine("Begin auto login to Jazz..");

            var uri = new Uri(homeUrl);
            string BaseUrl = String.Format("{0}://{1}", uri.Scheme, uri.Host);
            string loginPageUrl;

            HttpResponse loginPageResponse = GotoHomePage(BaseUrl, homeUrl, out loginPageUrl);

            return PostLoginPage(BaseUrl,loginPageUrl,homeUrl,loginPageResponse.Content);
        }

        private static HttpResponse GotoHomePage(string baseUrl, string homeUrl, out string loginPageUrl)
        {
            //Console.WriteLine("-----goto home page-----");
            string url1 = homeUrl;
            HttpResponse response1 = new HttpRequest(url1, CommonHeaders).Get();

            //Console.WriteLine("-----redirected-----");
            string url2 = response1.RedirectUrl;
            HttpResponse response2 = new HttpRequest(url2, CommonHeaders).Get();

            //Console.WriteLine("-----redirected-----");
            string url3 = response2.RedirectUrl;
            HttpResponse response3 = new HttpRequest(url3, CommonHeaders).Get();

            //Console.WriteLine("-----redirected-----");
            string url4 = baseUrl + response3.RedirectUrl;
            HttpResponse response4 = new HttpRequest(url4, CommonHeaders).Get();

            loginPageUrl = url4;
            return response4;
        }

        private static CookieCollection PostLoginPage(string baseUrl, string loginPageUrl,string homeUrl,string loginPageContent)
        {
            //Console.WriteLine("-----post login page-----");
            string url5 = loginPageUrl;
            HttpResponse response5 = new HttpRequest(url5, CommonHeaders).Post(HttpCommon.Parameter(GetLoginFormValues(loginPageContent)));

            //Console.WriteLine("-----login page redirect to default-----");
            string url6 = baseUrl + response5.RedirectUrl;
            var headers6 = GetStsRequestHeaders(response5);
            HttpResponse response6 = new HttpRequest(url6, headers6).Get();

            //Console.WriteLine("-----execute default form-----");
            string url7;
            var formValues7 = GetDefaultFormValues(response6.Content, out url7);
            HttpResponse response7 = new HttpRequest(url7, headers6).Post(HttpCommon.Parameter(formValues7));

            //Console.WriteLine("-----redirected with FedAuth cookie to home-----");
            string url8 = homeUrl;
            CookieCollection fedAuthCookies;
            var headers8 = SetFedAuthCookies(response7, out fedAuthCookies);
            HttpResponse response8 = new HttpRequest(url8, headers8).Get();

            return fedAuthCookies;
        }

        private static NameValueCollection GetStsRequestHeaders(HttpResponse response)
        {
            NameValueCollection headers = new NameValueCollection();

            for (int i = 0; i < CommonHeaders.Count; i++)
                headers.Add(CommonHeaders.GetKey(i), CommonHeaders.Get(i));

            string cookieString = response.Headers["Set-Cookie"];
            if (String.IsNullOrEmpty(cookieString))
                return headers;


            List<string> cookies = cookieString.Split(',').ToList();

            for (int i = 0; i < cookies.Count; i++)
            {
                if (cookies[i].IndexOf("expires=", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    cookies[i] += cookies[i + 1];
                    cookies.Remove(cookies[i + 1]);
                }
            }

            string headerCookies = String.Empty;
            foreach (var piece in cookies)
            {
                if (piece.Contains("username=") || (piece.Contains(".ASPXAUTH=") && piece.ToLower().IndexOf("path=/stshost") > 0))
                {
                    Cookie cookie = new Cookie();

                    foreach (var item in piece.Trim().Split(';'))
                    {
                        if (item.Trim() == "HttpOnly")
                            cookie.HttpOnly = true;
                        if (item.Contains("="))
                        {
                            string key = item.Split('=')[0].Trim();
                            string value = item.Split('=')[1].Trim();

                            if (key.ToLower() == "path")
                                cookie.Path = value;
                            if (key.ToLower() != "expires" && key.ToLower() != "path")
                            {
                                cookie.Name = key;
                                cookie.Value = value;
                            }
                        }
                    }

                    headerCookies += String.Format("{0}={1}; ", cookie.Name, HttpCommon.UrlEncode(cookie.Value));
                }
            }

            headers.Add("Cookie", headerCookies);

            return headers;
        }

        private static Dictionary<string, string> GetLoginFormValues(string content)
        {
            Dictionary<string, string> formValues = new Dictionary<string, string>();

            string pattern = "input type=\"hidden\" name=\"(?<name>.*)\" id=\".+\" value=\"(?<value>.*)\" ";

            Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            foreach (Match match in regex.Matches(content))
                formValues.Add(match.Groups["name"].Value, match.Groups["value"].Value);

            return formValues.Concat(User).ToDictionary(item => item.Key, item => item.Value);
        }

        private static Dictionary<string, string> GetDefaultFormValues(string content, out string action)
        {
            Dictionary<string, string> formValues = new Dictionary<string, string>();

            string formInputPattern = "input type=\"hidden\" name=\"(?<name>.*?)\" value=\"(?<value>.*?)\" ";
            string formActionPattern = "<form.*?action=\"(?<action>.*?)\"";

            Regex formInputRegex = new Regex(formInputPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);
            Regex formActionRegex = new Regex(formActionPattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            action = formActionRegex.Match(content).Groups["action"].Value;

            foreach (Match match in formInputRegex.Matches(content))
                formValues.Add(match.Groups["name"].Value, System.Web.HttpUtility.HtmlDecode(match.Groups["value"].Value));

            return formValues;
        }

        private static NameValueCollection SetFedAuthCookies(HttpResponse response,out CookieCollection cookieCollection)
        {
            NameValueCollection headers = new NameValueCollection();
            cookieCollection = new CookieCollection();

            for (int i = 0; i < CommonHeaders.Count; i++)
                headers.Add(CommonHeaders.GetKey(i), CommonHeaders.Get(i));

            string cookieString = response.Headers["Set-Cookie"];
            if (String.IsNullOrEmpty(cookieString))
                return headers;


            List<string> cookies = cookieString.Split(',').ToList();

            for (int i = 0; i < cookies.Count; i++)
            {
                if (cookies[i].IndexOf("expires=", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    cookies[i] += cookies[i + 1];
                    cookies.Remove(cookies[i + 1]);
                }
            }

            string headerCookies = String.Empty;
            Func<string[], int, int, string> joinArray = (array, ps, pe) =>
            {
                StringBuilder sb = new StringBuilder();
                for (int i = ps; i <= pe; i++)
                {
                    sb.Append(array[i]);
                }
                return sb.ToString();
            };
            foreach (var piece in cookies)
            {
                Cookie cookie = new Cookie();

                foreach (var item in piece.Trim().Split(';'))
                {
                    if (item.Trim() == "HttpOnly")
                        cookie.HttpOnly = true;
                    if (item.Contains("="))
                    {
                        string[] kvPair = item.Split('=');
                        string key = kvPair[0].Trim();
                        string value = kvPair.Length > 2 ? joinArray(kvPair, 1, kvPair.Length - 1) : kvPair[1].Trim();

                        //if (key.ToLower() == "path")
                        //    cookie.Path = value;
                        if (key.ToLower() != "expires" && key.ToLower() != "path")
                        {
                            cookie.Name = key;
                            cookie.Value = value;
                        }
                    }
                }

                headerCookies += String.Format("{0}={1}; ", cookie.Name, cookie.Value);
                cookieCollection.Add(cookie);
            }

            headers.Add("Cookie", headerCookies);

            return headers;
        }
    }
}
