using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Business.Result.Entity;
using System.Data;
using System.Data.Common;

namespace Mento.Business.Result.DataAccess
{
    public class ResultDA : DataAccessBase
    {
        public long Create(ResultEntity entity)
        {
            string sql = @"INSERT INTO [Result]([CaseID],[ExecutionID],[Status],[FailReason],[ImageUrl],[FailDetail]) VALUES(@CaseID,@ExecutionID,@Status,@FailReason,@ImageUrl,@FailDetail)
                           SELECT SCOPE_IDENTITY()";

            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "CaseID", DbType.String, entity.CaseID);
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
            string sql = "SELECT [ID],[CaseID],[ExecutionID],[Status],[FailReason],[ImageUrl],[FailDetail] FROM [Result] WHERE [PlanID]=@PlanID AND ExecutionID=@ExecutionID";

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
            string sql = "SELECT [ID],[CaseID],[ExecutionID],[Status],[FailReason],[ImageUrl],[FailDetail] FROM [Result] WHERE [CaseID]=@CaseID AND ExecutionID=@ExecutionID";

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
            string sql = "SELECT [ID],[CaseID],[ExecutionID],[Status],[FailReason],[ImageUrl],[FailDetail] FROM [Result] WHERE [PlanID]=@PlanID AND [CaseID]=@CaseID AND ExecutionID=@ExecutionID";
            
            DbCommand command = Database.GetSqlStringCommand(sql);

            Database.AddInParameter(command, "PlanID", DbType.Int64, planID);
            Database.AddInParameter(command, "CaseID", DbType.String, caseID);
            Database.AddInParameter(command, "ExecutionID", DbType.Int64, executionID);

            return Database.ExecuteDataSet(command).Tables[0];
        }
    }
}
