using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;

namespace Mento.Script.EnergyView
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            JazzBrowseManager.OpenJazz();

            JazzFunction.LoginPage.Login();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            JazzBrowseManager.OpenJazz();
        }
    }
}
