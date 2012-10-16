using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;

namespace Mento.Business.Script.Entity
{
    public class ScriptEntity : EntityBase
    {
        public string CaseID { get; set; }

        public string ManualCaseID { get; set; }

        public string Name { get; set; }

        public string SuiteName { get; set; }

        public int Type { get; set; }

        public int Priority { get; set; }

        public string Feature { get; set; }

        public string Module { get; set; }

        public string Owner { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? SyncTime { get; set; }
    }
}
