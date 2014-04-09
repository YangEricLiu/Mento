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
    [CreateTime("2013-03-18")]
    [ManualCaseID("TC-J1-FVT-Hierarchy-Modify-101")]
    public class PerformanceModifyBuildSuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;

        [SetUp]
        public void CaseSetUp()
        {
            HierarchySettings.NavigatorToHierarchySetting();
            JazzMessageBox.LoadingMask.WaitLoading();
        }

        [TearDown]
        public void CaseTearDown()
        {
            HierarchySettings.NavigatorToNonHierarchy();
        }

        [Test]
        [CaseID("TC-J1-FVT-PerformanceHierarchy-Modify-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(HierarchyData[]), typeof(PerformanceModifyBuildSuite), "TC-J1-FVT-PerformanceHierarchy-Modify-101-1")]
        public void ModifyValidAndVerify(HierarchyData input)
        {
            string customer1 = "Customer1";
            //string customer1 = "NancyCustomer1";
            string customer2 = "Customer2";
            string[] C1OrgSites = { "C1Org1", "C1Org2", "C1Org3", "C1Org4", "C1Org5", "C1Org6", "C1Site1", "C1Site2", "C1Site3", "C1Site4", "C1Site5", "C1Site6" };
            string[] C2OrgSites = { "C2Org1", "C2Org2", "C2Org3", "C2Org4", "C2Org5", "C2Org6", "C2Site1", "C2Site2", "C2Site3", "C2Site4", "C2Site5", "C2Site6" };
            string Build = "Build";
            string[] industries = { "酒店（二星级及以下）", "酒店（五星级）", "酒店（四星级）", "酒店（三星级）", "学校", "制造业", "数据中心", "服装零售" };
            string[] zones = { "严寒地区B区", "寒冷地区", "夏热冬冷地区", "夏热冬暖地区" };

            foreach (string C1OrgSite in C2OrgSites)
            {
                HierarchySettings.SelectHierarchyNode(customer2);
                HierarchySettings.ExpandNode(customer2);
                TimeManager.MediumPause();
                HierarchySettings.SelectHierarchyNode(C1OrgSite);
                HierarchySettings.ExpandNode(C1OrgSite);
                TimeManager.MediumPause();

                for (int i = 0; i < 9; i++)
                {
                    int k = i + 1;
                    string buildN = C1OrgSite + Build + k.ToString();

                    HierarchySettings.SelectHierarchyNode(buildN);
                    TimeManager.MediumPause();

                    //Click "修改 button
                    HierarchySettings.ClickModifyButton();
                    TimeManager.MediumPause();

                    HierarchySettings.FillInIndustry(industries[i%8]);
                    TimeManager.ShortPause();
                    HierarchySettings.FillInZone(zones[i%4]);

                    //Click "Save" button
                    TimeManager.MediumPause();
                    HierarchySettings.ClickSaveButton();
                    TimeManager.LongPause();
                }
            }    
        }
    }
}
