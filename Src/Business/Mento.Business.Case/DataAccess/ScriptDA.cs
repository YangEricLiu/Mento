using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using System.Configuration;
using Mento.Business.Script.Entity;
using System.Data.Common;
using System.Data;

namespace Mento.Business.Script.DataAccess
{
    public class ScriptDA : DataAccessBase
    {
        public long Create(ScriptEntity entity)
        {
            string sql = @"INSERT INTO [Script] 
                            ([CASEID],[MANUALCASEID],[NAME],[SUITENAME],[TYPE],[PRIORITY],[FEATURE],[MODULE],[OWNER],[CREATETIME],[SYNCTIME]) VALUES 
                            (@CASEID,@MANUALCASEID,@NAME,@SUITENAME,@TYPE,@PRIORITY,@FEATURE,@MODULE,@OWNER,@CREATETIME,@SYNCTIME);
                           SELECT SCOPE_IDENTITY()";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "CASEID", DbType.String, entity.CaseID);
            Database.AddInParameter(command, "MANUALCASEID", DbType.String, entity.ManualCaseID);
            Database.AddInParameter(command, "NAME", DbType.String, entity.Name);
            Database.AddInParameter(command, "SUITENAME", DbType.String, entity.SuiteName);
            Database.AddInParameter(command, "TYPE", DbType.Int32, entity.Type);
            Database.AddInParameter(command, "PRIORITY", DbType.Int32, entity.Priority);
            Database.AddInParameter(command, "FEATURE", DbType.String, entity.Feature);
            Database.AddInParameter(command, "MODULE", DbType.String, entity.Module);
            Database.AddInParameter(command, "OWNER", DbType.String, entity.Owner);

            if (entity.CreateTime.HasValue)
                Database.AddInParameter(command, "CREATETIME", DbType.DateTime, entity.CreateTime.Value);
            else
                Database.AddInParameter(command, "CREATETIME", DbType.DateTime, DBNull.Value);

            if (entity.SyncTime.HasValue)
                Database.AddInParameter(command, "SYNCTIME", DbType.DateTime, entity.SyncTime.Value);
            else
                Database.AddInParameter(command, "SYNCTIME", DbType.DateTime, DBNull.Value);


            return Convert.ToInt64(Database.ExecuteScalar(command));
        }

        public void DeleteAll()
        {
            string sql = "DELETE FROM [Script]";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.ExecuteNonQuery(command);
        }

        public ScriptEntity[] RetrieveAll()
        {
            string sql = "SELECT [ID],[CASEID],[MANUALCASEID],[NAME],[SUITENAME],[TYPE],[PRIORITY],[FEATURE],[MODULE],[OWNER],[CREATETIME],[SYNCTIME] FROM [Script]";

            DbCommand command = Database.GetSqlStringCommand(sql);

            List<ScriptEntity> list = base.ReadEntity<ScriptEntity>(Database.ExecuteReader(command));

            return list.ToArray();
        }

        public DataTable RetrieveToDataTable()
        {
            string sql = "SELECT [ID],[CASEID],[MANUALCASEID],[NAME],[SUITENAME],[TYPE],[PRIORITY],[FEATURE],[MODULE],[OWNER],[CREATETIME],[SYNCTIME] FROM [Script]";

            DbCommand command = Database.GetSqlStringCommand(sql);

            return Database.ExecuteDataSet(command).Tables[0];
        
        }
    }
}
