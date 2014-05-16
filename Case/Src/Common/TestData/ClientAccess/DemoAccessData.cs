using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;
using Mento.ScriptCommon.TestData.Common;

namespace Mento.ScriptCommon.TestData.ClientAccess
{
    public class DemoAccessData : TestDataBase<DemoAccessInputData, DemoAccessExpectedData>
    {
    }
    
    public class DemoAccessInputData : InputTestDataBase
    {
        public string Email { get; set; }
        public string CommonName { get; set; }
        public string Hierarchies { get; set; }

    }

    public class DemoAccessExpectedData : ExpectedTestDataBase
    {
        public string Email { get; set; }
        public string EmailSendedSuccessMessage { get; set; }
        public string CommonName { get; set; }
        public string Hierarchies { get; set; }


    }
}
