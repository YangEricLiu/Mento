using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.ClientAccess
{
    public class LoginData : TestDataBase<LoginInputData, ExpectedTestDataBase>
    {
    }

    public class LoginInputData : InputTestDataBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
