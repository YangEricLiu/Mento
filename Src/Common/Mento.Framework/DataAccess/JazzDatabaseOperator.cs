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
    public static class JazzDatabaseOperator
    {
        private const string SQL_PATTERN = "*.sql";
        //private static Database JazzDatabase = DatabaseContainer.JazzDatabase;

        public static void Initialize()
        {
            BatchExecuteScripts(ExecutionConfig.TearDownSqlScript);
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
                //StreamReader scriptReader = new StreamReader(scripts[i].FullName);

                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationKey.JAZZ_DATABASE_KEY].ConnectionString);
                Microsoft.SqlServer.Management.Smo.Server server = new Server(new ServerConnection(connection));
                int result = server.ConnectionContext.ExecuteNonQuery(File.ReadAllText(scripts[i].FullName));

                //if (result != 1)
                //    throw new Exception("can not execute init sql.");

                
                //DbCommand command;// = JazzDatabase.GetSqlStringCommand(File.ReadAllText());
                //StringBuilder builder = new StringBuilder();
                //string line = String.Empty;

                //while (!scriptReader.EndOfStream)
                //{
                //    line = scriptReader.ReadLine();
                //    if (line.Trim().ToUpper() != @"GO")
                //        builder.AppendLine(line);
                //    else
                //    {
                //        command = JazzDatabase.GetSqlStringCommand(builder.ToString());
                //        JazzDatabase.ExecuteNonQuery(command);

                //        builder.Remove(0, builder.Length);
                //    }
                //}
            }
        }
    } 
}
