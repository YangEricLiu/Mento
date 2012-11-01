using Mento.Framework.Attributes;
using Mento.Framework.Execution;
using Mento.Framework.Script;
using Mento.TestApi.TestData;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Threading = System.Threading;
using System;
using Mento.ScriptCommon.TestData.ClientAccess;
using Mento.ScriptCommon.Library.Functions;

namespace Mento.Script.Administration.Calendar
{
    [TestFixture]
    [ManualCaseID("TA-Trial-Login")]
    [CreateTime("2012-11-01")]
    [Owner("Aries")]
    public class LoginSuite : TestSuiteBase
    {
        [Test]
        [CaseID("TA-Trial-Login-001")]
        [MultipleTestDataSource(typeof(LoginData[]), typeof(LoginSuite), "TA-Trial-Login-001")]
        public void LoginToJazz(LoginData loginData)
        {
            //throw new Exception(loginData.ToString());

            ElementLocator.OpenJazz();

            //Threading.Thread.Sleep(10000);

            FunctionWrapper.Login.Login(loginData.InputData);
            //Assert.IsTrue();

            ElementLocator.QuitJazz();

        }
    }
}
