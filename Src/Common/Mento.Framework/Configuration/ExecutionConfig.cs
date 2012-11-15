using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using Mento.Framework.Constants;
using System.IO;

namespace Mento.Framework.Configuration
{
    public static class ExecutionConfig
    {
        private const string BROWSER = "browser";
        private const string LANGUAGE = "language";
        private const string URL = "url";
        private const string PUBLISHDIRECTORY = "publishDirectory";
        private const string SCRIPTDIRECTORY = "scriptDirectory";
        private const string EXECUTIONDIRECTORY = "executionDirectory";

        private static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static string Browser
        {
            get
            {
                return GetExecutionConfig(BROWSER);
            }
        }

        public static string Language
        {
            get
            {
                return GetExecutionConfig(LANGUAGE);
            }
        }

        public static string Url
        {
            get
            {
                return GetExecutionConfig(URL);
            }
        }

        public static string PublishDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, GetExecutionConfig(PUBLISHDIRECTORY));
            }
        }

        public static string ScriptDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, GetExecutionConfig(SCRIPTDIRECTORY));
            }
        }

        public static string ExecutionDirectory
        {
            get
            {
                return Path.Combine(BaseDirectory, GetExecutionConfig(EXECUTIONDIRECTORY));
            }
        }


        private static string GetExecutionConfig(string configKey)
        {
            var dictNameValueCollection = ConfigurationManager.GetSection(ConfigurationKey.EXECUTION_CONFIGURATION) as NameValueCollection;

            return dictNameValueCollection[configKey];
        }
    }
}
