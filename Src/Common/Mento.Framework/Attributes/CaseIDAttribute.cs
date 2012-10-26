using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Mento.Framework.Attributes
{
    /// <summary>
    /// Summary description for CaseIDAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CaseIDAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct a MaxTimeAttribute, given a time in milliseconds.
        /// </summary>
        /// <param name="milliseconds">The maximum elapsed time in milliseconds</param>
        public CaseIDAttribute(string caseid)
            : base(caseid) { }
    }


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ScriptPropertyAttribute : PropertyAttribute
    {
        public string CaseID { get; set; }
        public string ManualCaseID { get; set; }
        public string CreateTime { get; set; }
        public string Owner { get; set; }


        public ScriptPropertyAttribute()
        {
            AddProperties(CaseID,ManualCaseID,CreateTime,Owner);
        }

        public ScriptPropertyAttribute(string caseID, string manualCaseID, string createTime, string owner)
        {
            this.CaseID = caseID;
            this.ManualCaseID = ManualCaseID;
            this.CreateTime = createTime;
            this.Owner = owner;

            AddProperties(CaseID, ManualCaseID, CreateTime, Owner);
        }

        public void AddProperties(string caseID, string manualCaseID, string createTime, string owner)
        {
            if (!String.IsNullOrEmpty(CaseID))
                this.Properties.Add("CaseID", CaseID);
            if (!String.IsNullOrEmpty(ManualCaseID))
                this.Properties.Add("ManualCaseID", ManualCaseID);
            if (!String.IsNullOrEmpty(CreateTime))
                this.Properties.Add("CreateTime", CreateTime);
            if (!String.IsNullOrEmpty(Owner))
                this.Properties.Add("Owner", Owner);
        }
    }
}
