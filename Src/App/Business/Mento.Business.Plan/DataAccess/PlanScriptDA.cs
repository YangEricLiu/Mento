using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Business.Plan.Entity;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Mento.Business.Plan.DataAccess
{
    public class PlanScriptDA : DataAccessBase
    {
        public long Create(PlanScriptEntity entity)
        {
            string sql = @"INSERT INTO [PlanScript]([PlanID],[CaseID]) VALUES(@PlanID,@CaseID)";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, entity.PlanID);
            Database.AddInParameter(command, "CaseID", DbType.String, entity.CaseID);

            object result = Database.ExecuteScalar(command);

            return 1;
        }

        public void Delete(long planID)
        {
            string sql = "DELETE FROM [PlanScript] WHERE [PlanID] = @PlanID";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, planID);

            Database.ExecuteNonQuery(command);
        }
    }
}
