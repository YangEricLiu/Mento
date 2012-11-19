using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;

namespace Mento.Business.Plan.Entity
{
    /// <summary>
    /// Execution result entity
    /// </summary>
    public class ResultEntity : EntityBase
    {
        /// <summary>
        /// Execution ID that identifies which execution this result is for
        /// </summary>
        public long ExecutionID { get; set; }

        /// <summary>
        /// Case ID that identifies which case this result is for
        /// </summary>
        public string CaseID { get; set; }

        /// <summary>
        /// Status of this script's result
        /// </summary>
        public ScriptExecutionStatus Status { get; set; }

        /// <summary>
        /// If this script's result is failed, this field will show the error message
        /// </summary>
        public string FailReason { get; set; }

        /// <summary>
        /// If this script's result is failed, this field will show the screen shot of the failure point
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// If this script's result is failed, this field will show the detailed error information
        /// </summary>
        public string FailDetail { get; set; }
    }
    
    /// <summary>
    /// Represents status of a script's result
    /// </summary>
    public enum ScriptExecutionStatus
    {
        /// <summary>
        /// The scipt got some error in execution
        /// </summary>
        Failed = 0,

        /// <summary>
        /// The scipt is successfully executed
        /// </summary>
        Passed = 1,

        /// <summary>
        /// The scipt is not run for some reason
        /// </summary>
        NotRun = 2,
    }
}
