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
using Mento.ScriptCommon.TestData.EnergyView;


namespace Mento.ScriptCommon.Library
{
    public static class TestAssemblyInitializer
    {

        #region Old Jazz

        private static int WAITLONGTIME = 30000;
        public static List<DashboardInformation> CaseDownDashboardInfos = new List<DashboardInformation>();
        public static string mainWindowHandle = JazzBrowseManager.GetMainWindowHandle();

        public static void Initialize()
        {
            InitializeExecutionContext();

            JazzBrowseManager.OpenJazz();

            //JazzFunction.LoginPage.LoginToCustomer();
            //JazzFunction.LoginPage.LoginWithOption("Admin", "P@ssw0rd", "REM管理平台");
            JazzFunction.LoginPage.LoginWithOption("SchneiderElectricChina", "P@ssw0rdChina", "'云能效'系统管理");
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
            TimeManager.Pause(WAITLONGTIME);

            JazzFunction.LoginPage.SwitchLanguageOnLoginPage();

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

        #endregion

        #region New Jazz

        public static void NewJazz_DeleteActualExcelFiles()
        {
            string dir = ExecutionConfig.actualDataViewExcelFileDirectory;

            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件  
                }
            }
        }

        #endregion
    }
}
