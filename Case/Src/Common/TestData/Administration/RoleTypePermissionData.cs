using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class RoleTypePermissionData : TestDataBase<RoleTypeInputData, RoleTypeExpectedData>
    {
    }
    public class RoleTypeInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public string[] NameList { get; set; }
    }
    public class RoleTypeExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        public string[] NameList { get; set; }      
     }
}
