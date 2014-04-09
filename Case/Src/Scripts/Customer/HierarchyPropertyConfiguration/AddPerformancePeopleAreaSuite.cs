using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.Framework;
using Mento.Utility;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Attributes;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-06-05")]
    [ManualCaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101")]
    public class AddPerformancePeopleAreaSuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyPeopleAreaSettings PeopleAreaSetting = JazzFunction.HierarchyPeopleAreaSettings;

        [SetUp]
        public void CaseSetUp()
        {
            HierarchySetting.NavigatorToHierarchySetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HierarchySetting.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-PopulationAreaConfiguration-Add-101-3")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(PeopleAreaPropertyData[]), typeof(AddValidPeopleAreaPropertySuite), "TC-J1-FVT-PopulationAreaConfiguration-Add-101-2")]
        public void PAAddValidPupolation(PeopleAreaPropertyData input)
        {
            string customer1 = "Customer1";
            string customer2 = "Customer2";
            string[] C1OrgSites = { "C1Org1", "C1Org2", "C1Org3", "C1Org4", "C1Org5", "C1Org6", "C1Site1", "C1Site2", "C1Site3", "C1Site4", "C1Site5", "C1Site6" };
            string[] C2OrgSites = { "C2Org1", "C2Org2", "C2Org3", "C2Org4", "C2Org5", "C2Org6", "C2Site1", "C2Site2", "C2Site3", "C2Site4", "C2Site5", "C2Site6" };
            string Build = "Build";

            foreach (string C1OrgSite in C1OrgSites)
            {
                HierarchySetting.SelectHierarchyNode(customer1);
                HierarchySetting.ExpandNode(customer1);
                TimeManager.MediumPause();
                HierarchySetting.SelectHierarchyNode(C1OrgSite);
                HierarchySetting.ExpandNode(C1OrgSite);
                TimeManager.MediumPause();

                for (int i = 1; i < 13; i++)
                {
                    //Select one buidling node
                    string buildN = C1OrgSite + Build + i.ToString();

                    HierarchySetting.SelectHierarchyNode(buildN);
                    HierarchySetting.ExpandNode(C1OrgSite);
                    TimeManager.MediumPause();

                    //Verify the "人口面积" tab is available and click
                    PeopleAreaSetting.ClickPeopleAreaTab();
                    TimeManager.LongPause();

                    //Click "+人口面积"/"修改" button
                    PeopleAreaSetting.ClickPeopleAreaCreateButton();
                    TimeManager.LongPause();

                    //Fill valid value to area and save
                    PeopleAreaSetting.InputTotalAreaValue("2000");
                    PeopleAreaSetting.InputCoolingAreaValue("1000");
                    PeopleAreaSetting.InputHeatingAreaValue("1000");

                    PeopleAreaSetting.ClickPeopleCreateButton();
                    TimeManager.MediumPause();
            
                    //Input population value and save
                    PeopleAreaSetting.SelectEffectiveDate("2012-01");
                    PeopleAreaSetting.InputPeopleNumber("100");
                    TimeManager.LongPause();

                    PeopleAreaSetting.ClickSaveButton();
                    TimeManager.LongPause();
                }
            }
        }
    }
}
