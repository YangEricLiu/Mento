using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Mento.Business.Plan.Entity;

namespace Mento.Business.Execution.DataAccess
{
    public class ExecutionDA : DataAccessBase
    {
        public long Create(ExecutionEntity entity)
        {
            string sql = @" INSERT INTO [Execution]([PlanID],[Url],[Browser],[Language],[StartTime],[Owner],[CpuCount],[CpuFrequency],[ScreenResolution],[MemorySize]) VALUES(@PlanID,@Url,@Browser,@Language,@StartTime,@Owner,@CpuCount,@CpuFrequency,@ScreenResolution,@MemorySize)
                            SELECT SCOPE_IDENTITY()";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, entity.PlanID);
            Database.AddInParameter(command, "Url", DbType.String, entity.Url);

            if (entity.Browser.HasValue)
                Database.AddInParameter(command, "Browser", DbType.Int32, entity.Browser.Value);
            else
                Database.AddInParameter(command, "Browser", DbType.Int32, DBNull.Value);

            if (entity.Language.HasValue)
                Database.AddInParameter(command, "Language", DbType.Int32, entity.Language.Value);
            else
                Database.AddInParameter(command, "Language", DbType.Int32, DBNull.Value);

                Database.AddInParameter(command, "StartTime", DbType.DateTime, entity.StartTime);

            Database.AddInParameter(command, "Owner", DbType.String, entity.Owner);
            Database.AddInParameter(command, "CpuCount", DbType.Int32, entity.CpuCount);
            Database.AddInParameter(command, "CpuFrequency", DbType.String, entity.CpuFrequency);
            Database.AddInParameter(command, "ScreenResolution", DbType.String, entity.ScreenResolution);
            Database.AddInParameter(command, "MemorySize", DbType.String, entity.MemorySize);

            object result = Database.ExecuteScalar(command);

            return (result != null) ? Convert.ToInt64(result) : 0;
        }

        public void UpdateEndTime(long executionID, DateTime endTime)
        {
            string sql = @"UPDATE [Execution] SET [EndTime] = @EndTime WHERE [ID] = @ID";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "ID", DbType.Int64, executionID);
            Database.AddInParameter(command, "EndTime", DbType.DateTime, endTime);

            Database.ExecuteNonQuery(command);
        }

        public ExecutionEntity[] RetrieveByPlanID(long planID)
        {
            string sql = "SELECT [ID],[PlanID],[Url],[Browser],[Language],[StartTime],[EndTime],[Owner],[CpuCount],[CpuFrequency],[ScreenResolution],[MemorySize] FROM [Execution] WHERE [PlanID]=@PlanID";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, planID);

            return base.ReadEntity<ExecutionEntity>(Database.ExecuteReader(command)).ToArray();
        }
    }
}
