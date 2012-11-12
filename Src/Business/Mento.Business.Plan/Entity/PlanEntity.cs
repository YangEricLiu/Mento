using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Framework.Enumeration;

namespace Mento.Business.Plan.Entity
{
    /// <summary>
    /// Plan entity
    /// </summary>
    public class PlanEntity : EntityBase
    {
        /// <summary>
        /// Identity string of a plan
        /// </summary>
        public string PlanID { get; set; }

        /// <summary>
        /// Name of a plan
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Testing target product version of a plan
        /// </summary>
        public string TargetVersion { get; set; }

        /// <summary>
        /// Owner of a plan
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Update time of a plan, if a plan is deleted, this field will be the delete time
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Status of a plan
        /// </summary>
        public EntityStatus Status { get; set; }
    }
}
