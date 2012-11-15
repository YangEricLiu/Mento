using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Business.Plan.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Mento.Business.Script.Entity;
using Mento.Framework.Enumeration;

namespace Mento.Business.Plan.DataAccess
{
    public class PlanDA : DataAccessBase
    {
        public long Create(PlanEntity entity)
        {
            string sql = @" INSERT INTO [Plan]([PlanID],[Name],[ProductVersion],[Owner],[UpdateTime],[Status]) VALUES(@PlanID,@Name,@ProductVersion,@Owner,@UpdateTime,@Status)
                            SELECT SCOPE_IDENTITY()";
            
            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.String, entity.PlanID);
            Database.AddInParameter(command, "Name", DbType.String, entity.Name);
            Database.AddInParameter(command, "ProductVersion", DbType.String, entity.ProductVersion);
            Database.AddInParameter(command, "Owner", DbType.String, entity.Owner);
            Database.AddInParameter(command, "UpdateTime", DbType.DateTime, entity.UpdateTime);
            Database.AddInParameter(command, "Status", DbType.Int32, entity.Status);

            object result = Database.ExecuteScalar(command);

            return (result != null) ? Convert.ToInt64(result) : 0;
        }

        public void Update(PlanEntity entity)
        {
            string sql = "UPDATE [Plan] SET [PlanID] = @PlanID, [Name] = @Name,[ProductVersion] = @ProductVersion,[Owner] = @Owner,[UpdateTime] =@UpdateTime,[Status] = @Status WHERE [ID]=@ID";
            
            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "ID", DbType.Int64, entity.ID);
            Database.AddInParameter(command, "PlanID", DbType.String, entity.PlanID);
            Database.AddInParameter(command, "Name", DbType.String, entity.Name);
            Database.AddInParameter(command, "ProductVersion", DbType.String, entity.ProductVersion);
            Database.AddInParameter(command, "Owner", DbType.String, entity.Owner);
            Database.AddInParameter(command, "UpdateTime", DbType.DateTime, entity.UpdateTime);
            Database.AddInParameter(command, "Status", DbType.Int32, entity.Status);

            Database.ExecuteNonQuery(command);
        }

        public PlanEntity Retrieve(string planID)
        {
            string sql = @"SELECT [ID],[PlanID],[Name],[ProductVersion],[Owner],[UpdateTime],[Status] FROM [Plan] WHERE [PlanID] = @PlanID AND [Status]=@Status";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.String, planID);
            Database.AddInParameter(command, "Status", DbType.Int32, (int)EntityStatus.Active);

            List<PlanEntity> list = base.ReadEntity<PlanEntity>(Database.ExecuteReader(command));

            return list.Count > 0 ? list[0] : null;
        }
    }
}