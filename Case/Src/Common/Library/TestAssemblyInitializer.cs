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

namespace Mento.ScriptCommon.Library
{
    public static class TestAssemblyInitializer
    {
        public static void Initialize()
        {
            InitializeExecutionContext();

            /*
            if (IsInitializeDatabase())
            {
                JazzDataInitializer.Initialize();
            }
            */
            JazzBrowseManager.OpenJazz();

            JazzFunction.LoginPage.LoginToCustomer();
            //JazzFunction.LoginPage.LoginWithOption("Admin", "P@ssw0rd", "REM管理平台");
        }

        public static void InitializeWithOption(string userName, string passWord, string customer)
        {
            InitializeExecutionContext();

            if (IsInitializeDatabase())
            {
                //JazzDataInitializer.Initialize();
            }

            JazzBrowseManager.OpenJazz();

            JazzFunction.LoginPage.LoginWithOption(userName, passWord, customer);
        }

        public static void Desctuct()
        {
            JazzBrowseManager.CloseJazz();

            if (IsInitializeDatabase())
            {
                //JazzDataInitializer.Destruct();
            }

            ExecutionContext.Destruct();
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
