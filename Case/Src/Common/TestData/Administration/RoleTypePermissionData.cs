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
        public string[] NameList { get; set; }
        public RoleTypeInputData(string roleTypeName,string[] nameList)
        {
            this.CommonName = roleTypeName;
            this.NameList = nameList;
        }
    }
    public class RoleTypeExpectedData : ExpectedTestDataBase
        {
            public string CommonName { get; set; }
            public string[] NameList { get; set; }
            public RoleTypeExpectedData(string roleTypeName, string[] nameList)
            {
                this.CommonName = roleTypeName;
            }        
        }
}
