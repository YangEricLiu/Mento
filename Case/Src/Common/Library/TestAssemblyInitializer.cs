using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Constants;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.DataAccess;
using System.IO;
using Mento.Framework.Configuration;
using Mento.Framework.Execution;
using System.Configuration;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library
{
    public static class TestAssemblyInitializer
    {
        public static void Initialize()
        {
            InitializeExecutionContext();

            JazzBrowseManager.OpenJazz();

            //JazzFunction.LoginPage.LoginToCustomer();
            //JazzFunction.LoginPage.LoginWithOption("Admin", "P@ssw0rd", "REM管理平台");
            JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rd", "'云能效'系统管理");
        }

        public static void InitializePlatformWithOption(string userName, string passWord, string customer)
        {
            InitializeExecutionContext();

            JazzBrowseManager.OpenJazz();

            JazzFunction.LoginPage.LoginWithOption(userName, passWord, customer);

        }

        public static void InitializeWithOption(string userName, string passWord, string customer)
        {
            InitializeExecutionContext();

            JazzBrowseManager.OpenJazz();

            JazzFunction.LoginPage.LoginWithOption(userName, passWord, customer);

            // Ali pop window 
        }

        public static void Desctuct()
        {
            JazzBrowseManager.CloseJazz();

            //ExecutionContext.Destruct();
        }

        public static void InitializeExecutionContext()
        {
            string ContextConfigFileName = Path.Combine(ExecutionConfig.ExecutionDirectory, Project.EXECUTIONTEMPCONFIGNAME);

            if (!File.Exists(ContextConfigFileName))
                ExecutionContext.Initialize(ExecutionConfig.Url, ExecutionConfig.Browser, ExecutionConfig.Language);
        }

        public static bool IsInitializeDatabase()
        {
            bool isInitializeDatabase = false;
            bool.TryParse(ConfigurationManager.AppSettings[ConfigurationKey.ASSEMBLY_INITIALIZE_DATABASE], out isInitializeDatabase);
            return isInitializeDatabase;
        }
    }
}
