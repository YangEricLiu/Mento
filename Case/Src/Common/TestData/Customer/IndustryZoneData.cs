using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class IndustryAndZoneData : TestDataBase<IndustryAndZoneInputData, IndustryAndZoneExpectedData>
    {
    }

     public class IndustryAndZoneInputData : InputTestDataBase
     {
         public string[] HierarchyNodePath { get; set; }
         public string CommonName { get; set; }
         public string Type { get; set; }


         public IndustryAndZoneInputData(string[] hierarchyNodePath, string commonName, string type)
        {

            this.HierarchyNodePath = hierarchyNodePath;
            this.CommonName = commonName;
            this.Type = type;
        }
     }

     public class IndustryAndZoneExpectedData : ExpectedTestDataBase
     {
         public string[] Industry { get; set; }
         public string[] Zone { get; set; }

         public IndustryAndZoneExpectedData(string[] industry, string[] zone)
        {

            this.Industry = industry;
            this.Zone = zone;
        } 
     }   
}
