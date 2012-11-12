using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mento.Business.Script.Entity;
using Mento.Business.Script.DataAccess;

namespace Mento.Business.Case.Test
{
    [TestClass]
    public class ScriptDataAccessTest
    {
        private static ScriptDA ScriptDA = new ScriptDA();

        [TestCleanup]
        public void TestCleanup()
        {
            ScriptDA.DeleteAll();
        }

        [TestMethod]
        public void CreateTest()
        {
            ScriptEntity script = new ScriptEntity() { CaseID="TEST_CASE_ID_001"};

            long result = ScriptDA.Create(script);

            Assert.IsTrue(ScriptDA.RetrieveAll().Select(x=>x.CaseID).Contains(script.CaseID));
        }

        [TestMethod]
        public void DeleteTest()
        {
            ScriptEntity script = new ScriptEntity() { CaseID = "TEST_CASE_ID_002" };

            long result = ScriptDA.Create(script);

            Assert.IsTrue(ScriptDA.RetrieveAll().Select(x => x.CaseID).Contains(script.CaseID));

            ScriptDA.DeleteAll();

            Assert.IsTrue(!ScriptDA.RetrieveAll().Select(x => x.CaseID).Contains(script.CaseID));
        }
    }
}
