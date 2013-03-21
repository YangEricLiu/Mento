using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework.Configuration;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Mento.Framework.Constants;
using Mento.Framework.Exceptions;

namespace Mento.Framework.DataAccess
{
    internal static class JazzDatabaseOperator
    {
        private const string SQL_PATTERN = "*.sql";

        public static void Initialize()
        {
            BatchExecuteScripts(ExecutionConfig.SetupSqlScript);
        }

        public static void Destruct()
        {

            BatchExecuteScripts(ExecutionConfig.TearDownSqlScript);
        }

        private static void BatchExecuteScripts(string directory)
        {
            DirectoryInfo scriptDirectory = new DirectoryInfo(directory);

            if (!scriptDirectory.Exists || scriptDirectory.GetFiles(SQL_PATTERN).Length <= 0)
                return;

            var scripts = scriptDirectory.GetFiles(SQL_PATTERN).OrderBy(f=>f.Name).ToArray();

            for (int i = 0; i < scripts.Length; i++)
            {
                    ExecuteScript(File.ReadAllText(scripts[i].FullName));
            }
        }

        private static void ExecuteScriptFile(string fileName)
        {
            try
            {
                string scriptContent = File.ReadAllText(fileName);
                ExecuteScript(scriptContent);
            }
            catch (Exception ex)
            {
                throw new ApiException(String.Format("DB script execute error in: {0}", fileName), ex);
            }
        }

        public static void ExecuteScript(string scriptContent)
        {
            try
            {
                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationKey.JAZZ_DATABASE_KEY].ConnectionString);
                Microsoft.SqlServer.Management.Smo.Server server = new Server(new ServerConnection(connection));
                int result = server.ConnectionContext.ExecuteNonQuery(scriptContent);
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, ex);
            }
        }
    } 
}
