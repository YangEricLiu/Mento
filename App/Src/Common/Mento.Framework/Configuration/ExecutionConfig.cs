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
        private const string EXECUTIONARCHIVEDIRECTORY = "executionArchiveDirectory";
        private const string SCRIPTDIRECTORY = "scriptDirectory";
        private const string EXECUTIONDIRECTORY = "executionDirectory";
        private const string LOCALNETWORKDRIVE = "localNetworkDrive";
        private const string PUBLISHSERVERUSERNAME = "publishServerUserName";
        private const string PUBLISHSERVERPASSWORD = "publishServerPassword";
        private const string ISREFRESHSCRIPTSONEXECUTION = "isRefreshScriptsOnExecution";
        private const string ENVIRONMENTSETUPSQLSCRIPT = "environmentSetupSqlScript";
        private const string ENVIRONMENTTEARDOWNSQLSCRIPT = "environmentTearDownSqlScript";
        private const string ISCREATEEXPECTEDDATAVIEWEXCELFILE = "isCreateExpectedDataViewExcelFile";
        private const string EXPECTEDDATAVIEWEXCELFILEDIRECTORY = "expectedDataViewExcelFileDirectory";
        private const string FAILEDDATAVIEWEXCELFILEDIRECTORY = "failedDataViewExcelFileDirectory";
        private const string ISCOMPAREEXPECTEDDATAVIEWEXCELFILE = "isCompareExpectedDataViewExcelFile";
        private const string ISCREATEREPONSEBODYTEXTFILE = "isCreateResponseBodyTextFile";
        private const string ISCOMPARERESPONSETEXTFILE = "isCompareResponseTextFile";
        private const string DESTINATIONEXPECTEDRESPONSEBODYDIRECTORY = "destinationExpectedResponseBodyDirectory";
        private const string FAILEDRESPONSEBODYDIRECTORY = "failedResponseBodyDirectory";
        private const string SOURCERESPONSEBODYDIRECTORY = "sourceResponseBodyDirectory";
        private const string OPENAPITESTCASEDIRECTORY = "OpenAPITestCaseDirectory";

        private static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static bool isCreateResponseBodyTextFile
        {
            get
            {
                bool result = false;
                bool.TryParse(GetExecutionConfig(ISCREATEREPONSEBODYTEXTFILE), out result);
                return result;
            }
        }

        public static bool isCompareResponseTextFile
        {
            get
            {
                bool result = false;
                bool.TryParse(GetExecutionConfig(ISCOMPARERESPONSETEXTFILE), out result);
                return result;
            }
        }

        public static string destinationExpectedResponseBodyDirectory
        {
            get
            {
                return GetExecutionConfig(DESTINATIONEXPECTEDRESPONSEBODYDIRECTORY);
            }
        }

        public static string failedResponseBodyDirectory
        {
            get
            {
                return GetExecutionConfig(FAILEDRESPONSEBODYDIRECTORY);
            }
        }

        public static string sourceResponseBodyDirectory
        {
            get
            {
                return GetExecutionConfig(SOURCERESPONSEBODYDIRECTORY);
            }
        }

        public static string OpenAPITestCaseDirectory
        {
            get
            {
                return GetExecutionConfig(OPENAPITESTCASEDIRECTORY);
            }
        }


        public static bool isCreateExpectedDataViewExcelFile
        {
            get
            {
                bool result = true;
                //bool.TryParse(GetExecutionConfig(ISCREATEEXPECTEDDATAVIEWEXCELFILE), out result);
                return result;
            }
        }

        public static bool isCompareExpectedDataViewExcelFile
        {
            get
            {
                bool result = false;
                //bool.TryParse(GetExecutionConfig(ISCOMPAREEXPECTEDDATAVIEWEXCELFILE), out result);
                return result;
            }
        }

        public static string expectedDataViewExcelFileDirectory
        {
            get
            {
                return GetExecutionConfig(EXPECTEDDATAVIEWEXCELFILEDIRECTORY);
            }
        }

        public static string failedDataViewExcelFileDirectory
        {
            get
            {
                return GetExecutionConfig(FAILEDDATAVIEWEXCELFILEDIRECTORY);
            }
        }

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
                return GetAbsoluteOrRelativePath(GetExecutionConfig(PUBLISHDIRECTORY), BaseDirectory);
            }
        }

        public static string ExecutionArchiveDirectory
        {
            get
            {
                return GetAbsoluteOrRelativePath(GetExecutionConfig(EXECUTIONARCHIVEDIRECTORY), BaseDirectory);
            }
        }

        public static string ScriptDirectory
        {
            get
            {
                return GetAbsoluteOrRelativePath(GetExecutionConfig(SCRIPTDIRECTORY),BaseDirectory);
            }
        }

        public static string ExecutionDirectory
        {
            get
            {
                return GetAbsoluteOrRelativePath(GetExecutionConfig(EXECUTIONDIRECTORY), BaseDirectory);
            }
        }

        public static string LocalNetworkDrive
        {
            get
            {
                return GetExecutionConfig(LOCALNETWORKDRIVE);
            }
        }

        public static string PublishServerUserName
        {
            get
            {
                return GetExecutionConfig(PUBLISHSERVERUSERNAME);
            }
        }

        public static string PublishServerPassword
        {
            get
            {
                return GetExecutionConfig(PUBLISHSERVERPASSWORD);
            }
        }

        public static string SetupSqlScript
        {
            get
            {
                return GetAbsoluteOrRelativePath(GetExecutionConfig(ENVIRONMENTSETUPSQLSCRIPT), BaseDirectory);
            }
        }

        public static string TearDownSqlScript
        {
            get
            {
                return GetAbsoluteOrRelativePath(GetExecutionConfig(ENVIRONMENTTEARDOWNSQLSCRIPT), BaseDirectory);
            }
        }

        public static bool IsRefreshScriptsOnExecution
        {
            get
            {
                bool result = false;
                bool.TryParse(GetExecutionConfig(ISREFRESHSCRIPTSONEXECUTION), out result);
                return result;
            }
        }

        private static string GetExecutionConfig(string configKey)
        {
            var dictNameValueCollection = ConfigurationManager.GetSection(ConfigurationKey.EXECUTION_CONFIGURATION) as NameValueCollection;

            return dictNameValueCollection[configKey];
        }

        private static string GetAbsoluteOrRelativePath(string configPath,string basePath)
        {
            if (Path.IsPathRooted(configPath) || Uri.IsWellFormedUriString(configPath, UriKind.Absolute))
                return configPath;

            return Path.Combine(basePath, configPath);
        }
    }
}
