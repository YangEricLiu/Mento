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
        public string RoleTypeName { get; set; }
        public RoleTypeInputData(string roleTypeName)
        {
            this.RoleTypeName = roleTypeName;
        }
    }
    public class RoleTypeExpectedData : ExpectedTestDataBase
        {
            public string RoleTypeName { get; set; }
            public RoleTypeExpectedData(string roleTypeName)
            {
                this.RoleTypeName = roleTypeName;
            }        
        }
}
