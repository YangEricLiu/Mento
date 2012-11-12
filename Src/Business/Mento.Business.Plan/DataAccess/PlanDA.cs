using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Business.Plan.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Mento.Business.Plan.DataAccess
{
    public class PlanDA : DataAccessBase
    {
        public long Create(PlanEntity entity)
        {
            string sql = @" INSERT INTO [Plan]([PlanID],[Name],[Version],[Owner],[UpdateTime]) VALUES(@PlanID,@Name,@Version,@Owner,@UpdateTime)
                            SELECT SCOPE_IDENTITY()";
            
            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.String, entity.PlanID);
            Database.AddInParameter(command, "Name", DbType.String, entity.Name);
            Database.AddInParameter(command, "Version", DbType.String, entity.Version);
            Database.AddInParameter(command, "Owner", DbType.String, entity.Owner);
            Database.AddInParameter(command, "UpdateTime", DbType.DateTime, entity.UpdateTime);

            object result = Database.ExecuteScalar(command);

            return (result != null) ? Convert.ToInt64(result) : 0;
        }
    }
}
