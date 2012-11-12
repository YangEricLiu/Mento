using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;

namespace Mento.Business.Execution.Entity
{
    /// <summary>
    /// Execution entity
    /// </summary>
    public class ExecutionEntity : EntityBase
    {
        /// <summary>
        /// ID of the running plan that this execution is running for
        /// </summary>
        public long PlanID { get; set; }

        /// <summary>
        /// Url of the testing product that this execution is running
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Browser that this execution is running on
        /// </summary>
        public Browser Browser { get; set; }

        /// <summary>
        /// Language that this execution is using
        /// </summary>
        public Language Language { get; set; }

        /// <summary>
        /// Start time of this execution
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End time of this execution
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Owner of this execution
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// CPU count of the machine that runs this execution
        /// </summary>
        public int CpuCount { get; set; }

        /// <summary>
        /// CPU frequency of the machine that runs this execution
        /// </summary>
        public int CpuFrequency { get; set; }

        /// <summary>
        /// Screen resolution of the machine that runs this execution
        /// </summary>
        public string ScreenResolution { get; set; }

        /// <summary>
        /// Memory size of the machine that runs this execution
        /// </summary>
        public int MemorySize { get; set; }
    }
}
