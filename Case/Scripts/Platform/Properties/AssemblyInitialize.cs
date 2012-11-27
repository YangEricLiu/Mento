using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;

namespace Mento.Script.Platform
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            JazzBrowseManager.OpenJazz();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            JazzBrowseManager.OpenJazz();
        }
    }
}
