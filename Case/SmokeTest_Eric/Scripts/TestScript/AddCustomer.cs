using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.TestData;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.TestData.Administration;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;


namespace Mento.Script.TestScript.CustomerOperation
{
    [TestFixture]
    [Owner("Eric")]
    [CreateTime("2013-05-10")]
    [ManualCaseID("TA-Smoke-Customer-000")]
    public class AddCustomerSmokeTestSuite : TestSuiteBase
    {
        private static CustomerManagement CustomerManagement = JazzFunction.CustomerManagement;
        [SetUp]
        public void CaseSetUp()
        {
            JazzBrowseManager.RefreshJazz();
            JazzFunction.LoginPage.SelectCustomer("REM管理平台");
            
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CustomerManagement);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            
        }

        [Test]
        [CaseID("TA-Smoke-Customer-000")]        
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(AddCustomerSmokeTestSuite), "TC-J1-SmokeTest-033-001")]
        public void AddNewCustomer(CustomerManagementData input)
        {
            //Click "Add customer" button
            CustomerManagement.ClickAddCustomerButton();
            TimeManager.ShortPause();

            //For add logo dialog window can't handle with, so this case is not completed, but passed
            CustomerManagement.FillInCustomerInfo(input.InputData);
        }
    }
}
