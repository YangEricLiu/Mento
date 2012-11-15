using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;

namespace Mento.Business.Script.Entity
{
    /// <summary>
    /// Test script entity
    /// </summary>
    public class ScriptEntity : EntityBase
    {
        /// <summary>
        /// Identity string of this test script
        /// </summary>
        public string CaseID { get; set; }

        /// <summary>
        /// Identity string of the manual case that this test script belongs to
        /// </summary>
        public string ManualCaseID { get; set; }

        /// <summary>
        /// Name of this test script
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the test suite that this test script
        /// </summary>
        public string SuiteName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Priority of this test script
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Name of the product feature that this test script is written for
        /// </summary>
        public string Feature { get; set; }

        /// <summary>
        /// Name of the product module that this test script is written for
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// Owner of this test script
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Create time of this test script
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// Synchronization time of this script
        /// </summary>
        public DateTime? SyncTime { get; set; }

        /// <summary>
        /// Full name of this script
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Assembly name that contains this script
        /// </summary>
        public string Assembly { get; set; }
    }
}
