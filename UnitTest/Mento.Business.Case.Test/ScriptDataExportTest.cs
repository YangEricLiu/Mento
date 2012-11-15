using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mento.Business.Script.DataAccess;
using Mento.Business.Script.BusinessLogic;
using Mento.Business.Script.Entity;
using System.Reflection;
using Mento.Utility;
using Mento.Framework.Constants;
using Mento.Framework.Attributes;
using Mento.Framework.Configuration;

namespace Mento.Business.Case.Test
{
    [TestClass]
    public class ScriptDataExportTest
    {
        private static ScriptDA ScriptDA = new ScriptDA();
        ScriptBL ll = new ScriptBL();

        [TestInitialize]
        public void TestInitialize()
        {
            //ScriptDA.DeleteAll();
        }

        /*[TestMethod]
        public void GetScriptsDataTest()
        {
            ScriptEntity script1 = new ScriptEntity() { CaseID = "TEST_CASE_ID_002", ManualCaseID = "Manual_ID_002"};
            ScriptEntity script2 = new ScriptEntity() { CaseID = "TEST_CASE_ID_003", ManualCaseID = "Manual_ID_003"};
            ScriptEntity script3 = new ScriptEntity() { CaseID = "TEST_CASE_ID_004", ManualCaseID = "Manual_ID_004" };

            long result = ScriptDA.Create(script1);
            long result2 = ScriptDA.Create(script2);
            long result3 = ScriptDA.Create(script3);

            ScriptEntity[] scripts = ScriptDA.RetrieveAll();

            Assert.IsTrue(ScriptDA.RetrieveAll().Select(x => x.ManualCaseID).Contains(script3.ManualCaseID));
        }*/

        [TestMethod]
        public void GetScriptsDataTest()
        {
            ScriptEntity script1 = new ScriptEntity() { CaseID = "TEST_CASE_ID_009", ManualCaseID = "Manual_ID_082" };
            ScriptEntity script2 = new ScriptEntity() { CaseID = "TEST_CASE_ID_093", ManualCaseID = "Manual_ID_073" };
            ScriptEntity script3 = new ScriptEntity() { CaseID = "TEST_CASE_ID_008", ManualCaseID = "Manual_ID_064" };

            long result = ScriptDA.Create(script1);
            long result2 = ScriptDA.Create(script2);
            long result3 = ScriptDA.Create(script3);

            //Dictionary<MethodInfo, List<Type>> validationResult;
            //ll.Synchronize(out validationResult);
            ll.Export();

            //string excelFilePath = ExportConfig.GetExportLocationConfig(ConfigurationKey.SCRIPT_EXPORT_DIRECTORY);
            //Assert.AreEqual(excelFilePath, "D:\\backup\\ScriptMetaData.xlsx");
            //Assert.IsTrue(ScriptDA.RetrieveAll().Select(x => x.ManualCaseID).Contains(script3.ManualCaseID));
        }
    }
}
