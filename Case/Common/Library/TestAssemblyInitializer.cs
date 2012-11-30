using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Constants;
using Mento.TestApi.WebUserInterface;
using Mento.Framework.DataAccess;

namespace Mento.ScriptCommon.Library
{
    public static class TestAssemblyInitializer
    {
        public static void Initialize()
        {
            JazzBrowseManager.OpenJazz();

            JazzFunction.LoginPage.Login();

            if (IsInitializeDatabase())
                JazzDatabaseOperator.Initialize();
        }

        public static void Desctuct()
        {
            JazzBrowseManager.CloseJazz();

            if (IsInitializeDatabase())
                JazzDatabaseOperator.Destruct();
        }

        private static bool IsInitializeDatabase()
        {
            bool isInitializeDatabase = false;
            bool.TryParse(ConfigurationKey.ASSEMBLY_INITIALIZE_DATABASE, out isInitializeDatabase);
            return isInitializeDatabase;
        }
    }
}
