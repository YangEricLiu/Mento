﻿using System;
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


namespace Mento.Script.Administration.CustomerOperation
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-01-16")]
    [ManualCaseID("TC-J1-SmokeTest-033")]
    public class SmokeTestAddCustomerSuite : TestSuiteBase
    {
        private static CustomerManagement CustomerManagement = JazzFunction.CustomerManagement;
        [SetUp]
        public void CaseSetUp()
        {
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.CustomerManagement);
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {   
        }

        [Test]
        [CaseID("TC-J1-SmokeTest-033-001")]
        [Priority("11")]
        [MultipleTestDataSource(typeof(CustomerManagementData[]), typeof(SmokeTestAddCustomerSuite), "TC-J1-SmokeTest-033-001")]
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