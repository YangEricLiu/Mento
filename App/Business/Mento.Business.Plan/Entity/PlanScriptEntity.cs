using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;

namespace Mento.Business.Plan.Entity
{
    /// <summary>
    /// Plan-script many2many relation entity
    /// </summary>
    public class PlanScriptEntity : EntityBase
    {
        /// <summary>
        /// Plan id
        /// </summary>
        public long PlanID { get; set; }

        /// <summary>
        /// Case identity string
        /// </summary>
        public string CaseID { get; set; }
    }
}
