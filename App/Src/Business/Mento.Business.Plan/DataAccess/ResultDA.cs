using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Business.Plan.Entity;
using System.Data;
using System.Data.Common;

namespace Mento.Business.Plan.DataAccess
{
    public class ResultDA : DataAccessBase
    {
        public long Create(ResultEntity entity)
        {
            string sql = @"INSERT INTO [Result]([CaseID],[ScriptName],[ExecutionID],[Status],[FailReason],[ImageUrl],[FailDetail]) VALUES(@CaseID,@ScriptName,@ExecutionID,@Status,@FailReason,@ImageUrl,@FailDetail)
                           SELECT SCOPE_IDENTITY()";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "CaseID", DbType.String, entity.CaseID);
            Database.AddInParameter(command, "ScriptName", DbType.String, entity.ScriptName);
            Database.AddInParameter(command, "ExecutionID", DbType.Int64, entity.ExecutionID);
            Database.AddInParameter(command, "Status", DbType.Int32, entity.Status);
            Database.AddInParameter(command, "FailReason", DbType.String, entity.FailReason);
            Database.AddInParameter(command, "ImageUrl", DbType.String, entity.ImageUrl);
            Database.AddInParameter(command, "FailDetail", DbType.String, entity.FailDetail);

            object result = Database.ExecuteScalar(command);

            return (result != null) ? Convert.ToInt64(result) : 0;
        }

        public void Delete(long executionID)
        {
            string sql = "DELETE FROM [Result] WHERE [ExecutionID]=@ExecutionID";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "ExecutionID", DbType.Int64, executionID);

            Database.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Result list for a plan of an execution
        /// </summary>
        /// <param name="caseID"></param>
        public DataTable Retrieve(long planID, long executionID)
        {
            string sql = @"SELECT [R].[ID],[R].[CaseID],[R].[ScriptName],[R].[ExecutionID],[R].[Status],[R].[FailReason],[R].[ImageUrl],[R].[FailDetail] FROM [Result] [R]
                           INNER JOIN [Execution] [E] on [R].[ExecutionID] = [E].[ID]
                           WHERE [E].[PlanID]=@PlanID AND [R].[ExecutionID]=@ExecutionID";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, planID);
            Database.AddInParameter(command, "ExecutionID", DbType.Int64, executionID);

            return Database.ExecuteDataSet(command).Tables[0];
        }

        /// <summary>
        /// Result list for a case of an execution
        /// </summary>
        /// <param name="caseID"></param>
        public DataTable Retrieve(string caseID, long executionID)
        {
            string sql = "SELECT [ID],[CaseID],[ScriptName],[ExecutionID],[Status],[FailReason],[ImageUrl],[FailDetail] FROM [Result] WHERE [CaseID]=@CaseID AND ExecutionID=@ExecutionID";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "CaseID", DbType.String, caseID);
            Database.AddInParameter(command, "ExecutionID", DbType.Int64, executionID);

            return Database.ExecuteDataSet(command).Tables[0];
        }

        /// <summary>
        /// Result list for a script in a plan of an execution
        /// </summary>
        /// <param name="caseID"></param>
        public DataTable Retrieve(long planID, string caseID, long executionID)
        {
            string sql = @"SELECT [R].[ID],[R].[CaseID],[R].[ScriptName],[R].[ExecutionID],[R].[Status],[R].[FailReason],[R].[ImageUrl],[R].[FailDetail] FROM [Result] [R]
                           INNER JOIN [Execution] [E] on [R].[ExecutionID] = [E].[ID]
                           WHERE [E].[PlanID]=@PlanID AND [R].[ExecutionID]=@ExecutionID AND [R].[CaseID]=@CaseID";
            
            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, planID);
            Database.AddInParameter(command, "CaseID", DbType.String, caseID);
            Database.AddInParameter(command, "ExecutionID", DbType.Int64, executionID);

            return Database.ExecuteDataSet(command).Tables[0];
        }
    }
}
