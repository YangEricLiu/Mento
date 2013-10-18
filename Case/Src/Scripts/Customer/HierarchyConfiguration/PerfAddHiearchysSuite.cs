
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
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-03-12")]
    [ManualCaseID("TC-J1-FVT-Hierarchy-Perf-101")]
    public class PerfAddHierarchysSuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;

        [SetUp]
        public void CaseSetUp()
        {
            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.LongPause();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HierarchySettings.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Perf-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(PerfAddHierarchysSuite), "TC-J1-FVT-Hierarchy-Perf-101-1")]
        public void AddValidOrg(HierarchyData input)
        {
            //Add 10 orgnizations to customer
            string path1 = "PerfTesting";
            string[] orgs = { "PerfOrg001", "PerfOrg002", "PerfOrg003", "PerfOrg004", "PerfOrg005", "PerfOrg006", "PerfOrg007", "PerfOrg008", "PerfOrg009", "PerfOrg010" };    

            foreach (string org in orgs)
            {
                HierarchySettings.SelectHierarchyNode(path1);
                TimeManager.MediumPause();
                HierarchySettings.ClickCreateChildHierarchyButton();
                TimeManager.MediumPause();

                HierarchySettings.FillInName(org);
                HierarchySettings.FillIncode(org);
                HierarchySettings.FillInType("Orgnization");
                TimeManager.ShortPause();

                //Click "Save" button
                TimeManager.MediumPause();
                HierarchySettings.ClickSaveButton();
                TimeManager.Pause(3000);
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Perf-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(PerfAddHierarchysSuite), "TC-J1-FVT-Hierarchy-Perf-101-1")]
        public void AddValidSite(HierarchyData input)
        {
            //Add 10 sites to each org
            string path1 = "PerfTesting";
            string[] orgs = { "PerfOrg001", "PerfOrg002", "PerfOrg003", "PerfOrg004", "PerfOrg005", "PerfOrg006", "PerfOrg007", "PerfOrg008", "PerfOrg009", "PerfOrg010" };           

            foreach (string org in orgs)
            {
                for (int i = 1; i < 11; i++)
                {
                    HierarchySettings.SelectHierarchyNode(path1);
                    TimeManager.MediumPause();
                    HierarchySettings.ExpandNode(path1);
                    TimeManager.MediumPause();
                    HierarchySettings.SelectHierarchyNode(org);
                    TimeManager.MediumPause();
                    HierarchySettings.ClickCreateChildHierarchyButton();
                    TimeManager.MediumPause();

                    string site = "_Site";
                    string iString = i.ToString();
                    string siteName = org + site + iString;

                    HierarchySettings.FillInName(siteName);
                    HierarchySettings.FillIncode(siteName);
                    HierarchySettings.FillInType("Site");
                    TimeManager.ShortPause();

                    //Click "Save" button
                    TimeManager.MediumPause();
                    HierarchySettings.ClickSaveButton();
                    TimeManager.Pause(3000);
                }
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Perf-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(PerfAddHierarchysSuite), "TC-J1-FVT-Hierarchy-Perf-101-1")]
        public void AddValidBuilding(HierarchyData input)
        {
            //Add 10 sites to each org
            string path1 = "PerfTesting";
            string[] orgs = { "PerfOrg001", "PerfOrg002", "PerfOrg003", "PerfOrg004", "PerfOrg005", "PerfOrg006", "PerfOrg007", "PerfOrg008", "PerfOrg009", "PerfOrg010" };

            foreach (string org in orgs)
            {
                HierarchySettings.SelectHierarchyNode(path1);
                TimeManager.MediumPause();
                HierarchySettings.ExpandNode(path1);
                TimeManager.MediumPause();
                HierarchySettings.SelectHierarchyNode(org);
                TimeManager.MediumPause();
                HierarchySettings.ExpandNode(org);
                TimeManager.MediumPause();

                for (int i = 1; i < 11; i++)
                {
                    string site = "_Site";
                    string iString = i.ToString();
                    string siteName = org + site + iString;

                    for (int j = 1; j < 11; j++)
                    {
                        HierarchySettings.SelectHierarchyNode(siteName);
                        TimeManager.MediumPause();
                        HierarchySettings.ClickCreateChildHierarchyButton();
                        TimeManager.MediumPause();

                        string build = "_B";
                        string jString = j.ToString();
                        string buildName = siteName + build + jString;

                        HierarchySettings.FillInName(buildName);
                        HierarchySettings.FillIncode(buildName);
                        HierarchySettings.FillInType("Building");
                        TimeManager.ShortPause();
                        HierarchySettings.FillInIndustry("办公建筑");
                        HierarchySettings.FillInZone("温和地区");
                        TimeManager.ShortPause();

                        //Click "Save" button
                        TimeManager.MediumPause();
                        HierarchySettings.ClickSaveButton();
                        TimeManager.Pause(3000);
                    }

                    HierarchySettings.CollapseNode(siteName);
                    TimeManager.ShortPause();
                }

                HierarchySettings.CollapseNode(org);
                TimeManager.ShortPause();
            }
        }

        [Test]
        [CaseID("TC-J1-FVT-Hierarchy-Perf-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(PerfAddHierarchysSuite), "TC-J1-FVT-Hierarchy-Perf-101-1")]
        public void Add20BuidlingSite(HierarchyData input)
        {
            //Add 10 sites to each org
            string[] path1 = {"NancyOtherCustomer3", "园区能耗标识"};
            string building = "BuildingLabelling";

                HierarchySettings.SelectHierarchyNodePath(path1);
                TimeManager.MediumPause();

                for (int i = 18; i < 21; i++)
                {
                    string iString = i.ToString();
                    string buildName = building + iString;

                        HierarchySettings.ClickCreateChildHierarchyButton();
                        TimeManager.MediumPause();

                        HierarchySettings.FillInName(buildName);
                        HierarchySettings.FillIncode(buildName);
                        HierarchySettings.FillInType("Building");
                        TimeManager.ShortPause();
                        HierarchySettings.FillInIndustry("酒店（三星级）");
                        HierarchySettings.FillInZone("夏热冬暖地区");
                        TimeManager.ShortPause();

                        //Click "Save" button
                        TimeManager.MediumPause();
                        HierarchySettings.ClickSaveButton();
                        TimeManager.Pause(3000);

                        HierarchySettings.SelectHierarchyNode("园区能耗标识");
                }
        }
    } 
}
