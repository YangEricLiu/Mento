using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;

namespace Mento.Script.Information
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            ElementLocator.OpenJazz();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            ElementLocator.CloseJazz();
        }
    }
}
