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
            string sql = @"INSERT INTO [Script]([CaseID],[ManualCaseID],[Name],[SuiteName],[Type],[Priority],[Feature],[Module],[Owner],[CreateTime],[SyncTime],[FullName],[Assembly])
                           VALUES (@CaseID,@ManualCaseID,@Name,@SuiteName,@Type,@Priority,@Feature,@Module,@Owner,@CreateTime,@SyncTime,@FullName,@Assembly);
                           SELECT SCOPE_IDENTITY()";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "CaseID", DbType.String, entity.CaseID);
            Database.AddInParameter(command, "ManualCaseID", DbType.String, entity.ManualCaseID);
            Database.AddInParameter(command, "Name", DbType.String, entity.Name);
            Database.AddInParameter(command, "SuiteName", DbType.String, entity.SuiteName);
            Database.AddInParameter(command, "Type", DbType.Int32, entity.Type);
            Database.AddInParameter(command, "Priority", DbType.Int32, entity.Priority);
            Database.AddInParameter(command, "Feature", DbType.String, entity.Feature);
            Database.AddInParameter(command, "Module", DbType.String, entity.Module);
            Database.AddInParameter(command, "Owner", DbType.String, entity.Owner);

            if (entity.CreateTime.HasValue)
                Database.AddInParameter(command, "CREATETIME", DbType.DateTime, entity.CreateTime.Value);
            else
                Database.AddInParameter(command, "CREATETIME", DbType.DateTime, DBNull.Value);

            if (entity.SyncTime.HasValue)
                Database.AddInParameter(command, "SYNCTIME", DbType.DateTime, entity.SyncTime.Value);
            else
                Database.AddInParameter(command, "SYNCTIME", DbType.DateTime, DBNull.Value);

            Database.AddInParameter(command, "FullName", DbType.String, entity.FullName);
            Database.AddInParameter(command, "Assembly", DbType.String, entity.Assembly);


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
            string sql = "SELECT [ID],[CaseID],[ManualCaseID],[Name],[SuiteName],[Type],[Priority],[Feature],[Module],[Owner],[CreateTime],[SyncTime],[FullName],[Assembly] FROM [Script]";

            DbCommand command = Database.GetSqlStringCommand(sql);

            List<ScriptEntity> list = base.ReadEntity<ScriptEntity>(Database.ExecuteReader(command));

            return list.ToArray();
        }

        public ScriptEntity[] RetrieveByPlanID(long PlanID)
        {
            string sql = @"SELECT [S].[ID],[S].[CaseID],[S].[ManualCaseID],[S].[Name],[S].[SuiteName],[S].[Type],[S].[Priority],[S].[Feature],[S].[Module],[S].[Owner],[S].[CreateTime],[S].[SyncTime],[S].[FullName],[S].[Assembly]
                           FROM [Script] [S]
                           INNER JOIN [PlanScript] [PS] ON [S].[CaseID] = [PS].[CaseID]
                           WHERE [PS].[PlanID] = @PlanID";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, PlanID);

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
