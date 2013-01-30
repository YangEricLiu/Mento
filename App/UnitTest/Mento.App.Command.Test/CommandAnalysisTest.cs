using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mento.App.CommandAnalysis;

namespace Mento.App.Command.Test
{
    [TestClass]
    public class CommandAnalysisTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            //
        }

        [TestMethod]
        public void CommandAnalyerTest()
        {
            string[] cmds = new string[] { "result", "view", "-result", "TA-Example-001" };

            CommandAnalyer.Execute(cmds);

            
            //Assert.AreEqual(AppDomain.CurrentDomain.BaseDirectory.ToString(), "hello");
        }
    }
}
