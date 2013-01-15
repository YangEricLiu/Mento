﻿using System;
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

            if (IsInitializeDatabase())
                JazzDatabaseOperator.Initialize();

            JazzBrowseManager.OpenJazz();

            JazzFunction.LoginPage.LoginToCustomer();

        }

        public static void Desctuct()
        {
            JazzBrowseManager.CloseJazz();

            if (IsInitializeDatabase())
                //JazzDatabaseOperator.Destruct();

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
