using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using System.Configuration;

namespace Mento.Script.EnergyView.Trial
{
    [TestFixture]
    [ManualCaseID("TA-Trial-01")]
    [CreateTime("2012-11-15")]
    [Owner("Aries")]
    public class TryNuintMultipleAssembly : TestSuiteBase
    {
        [Test]
        [CaseID("TA-Trial-001")]
        public void GoMento()
        {
            string Path = ConfigurationManager.AppSettings["path"];
            Assert.That(Path, Is.StringContaining("temp"));
        }
    }
}
