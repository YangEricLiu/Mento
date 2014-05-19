﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library;

namespace Mento.Script.Customer
{
    [SetUpFixture]
    public class AssemblyInitialize
    {
        [SetUp]
        public void RunBeforeAnyTests()
        {
            TestAssemblyInitializer.InitializeWithOption("Wangxin", "123456qq", null);
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            TestAssemblyInitializer.Desctuct();
        }
    }
}