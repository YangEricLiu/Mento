using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Mento.Framework.Configuration;
using System.IO;
using System.Net;
using System.Xml.XPath;
using Mento.Utility;
using Mento.Framework.Log;
using Mento.Framework.Exceptions;
using System.Text.RegularExpressions;
using Mento.Framework.Execution;

namespace Mento.Framework.DataAccess
{
    public static class JazzDataInitializer
    {
        private static XDocument XmlDefinition = XDocument.Load(Path.Combine(ExecutionConfig.SetupSqlScript, "initialization.xml"));


        private static CookieCollection _Cookies;
        private static CookieCollection Cookies
        {
            get
            {
                if (_Cookies == null)
                {
                    _Cookies = JazzLoginHelper.GetFedAuthCookie(ExecutionContext.Url);
                }

                return _Cookies;
            }
        }

        private static Dictionary<string, string> _Interfaces;
        private static Dictionary<string, string> Interfaces
        {
            get
            {
                if (_Interfaces == null)
                {
                    _Interfaces = new Dictionary<string, string>();

                    foreach (XElement interfaceElement in XmlDefinition.XPathSelectElements("intialization/request/interfaces/interface"))
                    {
                        string name = interfaceElement.Attribute("name").Value;
                        string url = interfaceElement.Attribute("url").Value;

                        _Interfaces.Add(name, ExecutionContext.Url + url);
                    }
                }

                return _Interfaces;
            }
        }

        public static void Execute()
        {
            Console.WriteLine("Initializing Jazz data...");
            foreach (var dataElement in XmlDefinition.XPathSelectElement("/intialization/testdata").Elements())
            {
                string dataName = dataElement.Name.LocalName;

                foreach (var addElement in dataElement.Elements())
                {
                    if (String.IsNullOrEmpty(addElement.Value))
                        continue;

                    try
                    {
                        var typeAttribute = addElement.Attribute("type");
                        if (typeAttribute != null && typeAttribute.Value.ToLower() == "sql")
                        {
                            JazzDatabaseOperator.ExecuteScript(addElement.Value);
                            ScriptLog.Instance.LogInformation(addElement.Value);
                            Console.WriteLine(addElement.Value);
                        }
                        else
                        {
                            string result = HttpRequestHelper.SendPost(Interfaces[dataName], addElement.Value, cookies: Cookies);
                            ScriptLog.Instance.LogInformation(Interfaces[dataName]);
                            ScriptLog.Instance.LogInformation(addElement.Value);
                            ScriptLog.Instance.LogInformation(result);
                            Console.WriteLine(result);

                            if (Regex.Match(result, @"^{""errorCode"":""\d+""}$").Success)
                            { 
                                throw new ApiException(String.Format("Interface returned error: {0}",result));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ApiException("Error when initializing Jazz data.",ex);
                    }
                }
            }
            Console.WriteLine("Finished initializing test data, launching test..");
        }
    }
}