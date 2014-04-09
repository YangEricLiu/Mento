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
using Mento.TestApi.TestData.Attribute;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.Script.Customer.HierarchyPropertyConfiguration
{
    [TestFixture]
    [Owner("Emma")]
    [CreateTime("2013-06-18")]
    [ManualCaseID("TC-J1-FVT-CostPerformance-Elec-Add")]
    public class AddElecCostPerformanceSuite : TestSuiteBase
    {
        private static HierarchySettings HierarchySetting = JazzFunction.HierarchySettings;
        private static HierarchyElectricCostSettings CostSettings = JazzFunction.HierarchyElectricCostSettings;

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
        [CaseID("TC-J1-FVT-CostPerformance-Elec-Add-101-1")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(ElectricityComprehensiveCostData[]), typeof(AddElecCostPerformanceSuite), "TC-J1-FVT-CostPerformance-Elec-Add-101-1")]
        public void AddValidCompMode1(ElectricityComprehensiveCostData input)
        {
            string customer1 = "Customer1";
            //string customer1 = "NancyCustomer1";
            string customer2 = "Customer2";
            string[] C1OrgSites = { "C1Site1", "C1Site2", "C1Site3", "C1Site4", "C1Site5", "C1Site6" };
            string[] C2OrgSites = { "C2Org1", "C2Org2", "C2Org3", "C2Org4", "C2Org5", "C2Org6", "C2Site1", "C2Site2", "C2Site3", "C2Site4", "C2Site5", "C2Site6" };
            string Build = "Build";

            foreach (string C1OrgSite in C2OrgSites)
            {
                HierarchySetting.SelectHierarchyNode(customer2);
                HierarchySetting.ExpandNode(customer2);
                TimeManager.MediumPause();

                HierarchySetting.SelectHierarchyNode(C1OrgSite);
                HierarchySetting.ExpandNode(C1OrgSite);
                TimeManager.MediumPause();

                for (int i = 1; i < 13; i++)
                {
                    string buildN = C1OrgSite + Build + i.ToString();
                    string RealTag = buildN + "_ptag1";
                    string ReactiveTag = buildN + "_vtag1";

                    HierarchySetting.SelectHierarchyNode(buildN);
                    TimeManager.MediumPause();

                    //Click "成本属性" tab button
                    CostSettings.ClickCostPropertyTabButton_Update();
                    TimeManager.MediumPause();

                    //Click "+成本属性" button
                    CostSettings.ClickCostCreateButton();
                    TimeManager.ShortPause();

                    //Click "+" before "电力" and select "综合电价"
                    CostSettings.ClickElectricCostCreateButton();
                    TimeManager.ShortPause();

                    //Fill in valid value
                    CostSettings.SelectElectricEffectiveDate("2013-01", 1);
                    CostSettings.SelectElectricPriceMode("综合电价", 1);
                    CostSettings.SelectDemandCostType("时间容量模式", 1);
                    CostSettings.SelectHourTagId(RealTag, 1);
                    CostSettings.FillElectricHourPrice("4", 1);
                    CostSettings.SelectTouTariffId("SP1性能测试峰谷电价1", 1);

                    CostSettings.SelectFactorType("0.85", 1);
                    TimeManager.ShortPause();

                    CostSettings.SelectRealTagId(RealTag, 1);
                    CostSettings.SelectReactiveTagId(ReactiveTag, 1);

                    CostSettings.FillElectricPaddingCost("2", 1);

                    //Click "Save" button and make sure save successful
                    CostSettings.ClickCostSaveButton();
                    JazzMessageBox.LoadingMask.WaitLoading(8);
                }
            }
        }
    }
}
