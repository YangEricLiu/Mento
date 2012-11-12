using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Business.Execution.Entity;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Mento.Business.Execution.DataAccess
{
    public class ExecutionDA : DataAccessBase
    {
        public long Create(ExecutionEntity entity)
        {
            string sql = @" INSERT INTO [Execution]([PlanID],[Url],[Browser],[Language],[StartTime],[EndTime],[Owner],[CpuCount],[CpuFrequency],[ScreenResolution],[MemorySize]) VALUES(@PlanID,@Url,@Browser,@Language,@StartTime,@EndTime,@Owner,@CpuCount,@CpuFrequency,@ScreenResolution,@MemorySize)
                            SELECT SCOPE_IDENTITY()";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, entity.PlanID);
            Database.AddInParameter(command, "Url", DbType.String, entity.Url);
            Database.AddInParameter(command, "Browser", DbType.Int32, entity.Browser);
            Database.AddInParameter(command, "Language", DbType.Int32, entity.Language);
            Database.AddInParameter(command, "StartTime", DbType.DateTime, entity.StartTime);
            Database.AddInParameter(command, "EndTime", DbType.DateTime, entity.EndTime);
            Database.AddInParameter(command, "Owner", DbType.String, entity.Owner);
            Database.AddInParameter(command, "CpuCount", DbType.Int32, entity.CpuCount);
            Database.AddInParameter(command, "CpuFrequency", DbType.Int32, entity.CpuFrequency);
            Database.AddInParameter(command, "ScreenResolution", DbType.String, entity.ScreenResolution);
            Database.AddInParameter(command, "MemorySize", DbType.Int32, entity.MemorySize);

            object result = Database.ExecuteScalar(command);

            return (result != null) ? Convert.ToInt64(result) : 0;
        }
    }
}
