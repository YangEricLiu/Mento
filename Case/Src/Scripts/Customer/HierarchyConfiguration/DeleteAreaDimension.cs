﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Mento.TestApi.WebUserInterface;
using Mento.ScriptCommon.Library.Functions;
using Mento.Framework.Script;
using Mento.ScriptCommon.Library;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.Utility;
using Mento.Framework.Attributes;
using Mento.ScriptCommon.TestData.Customer;
using Mento.TestApi.TestData;
using Mento.TestApi.TestData.Attribute;

namespace Mento.Script.Customer.HierarchyConfiguration
{
    [TestFixture]
    [Owner("greenie")]
    [CreateTime("2013-06-17")]
    [ManualCaseID("TC-J1-FVT-AreaDimensionConfiguration-001")]
    public class DeleteAreaDimension : TestSuiteBase
    {
        private static HierarchySettings HierarchySettings = JazzFunction.HierarchySettings;
        private static AreaDimensionSettings AreaSettings = JazzFunction.AreaDimensionSettings;
        private AssociateSettings AssociateSettings = JazzFunction.AssociateSettings;

        [SetUp]
        public void ScriptSetUp()
        {
            HierarchySettings.NavigatorToHierarchySetting();
            TimeManager.MediumPause();
        }

        [TearDown]
        public void ScriptTearDown()
        {
            JazzFunction.LoginPage.RefreshJazz("自动化测试");
            TimeManager.LongPause();
        }

        /// <summary>
        /// Precondition: make sure the hiearchy node has been added  "自动化测试", "测试楼宇园区", "楼宇配置测试"
        /// Prepare Data: 1.[楼宇配置测试""DeleteArea1"] ,["楼宇配置测试","L1","L2","L3","L4",]   [  "楼宇配置测试","CheckAll"]
        ///                       2. an Vtag "VtagForAreaDimensionNode" has been assosiated under   [  "楼宇配置测试","CheckAll"]
        /// </summary>  
        [Test]
        [Category("P4_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-Delete-001-DeleteAreaNodeThenCancels")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(DeleteAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-Delete-001-DeleteAreaNodeThenCancel")]
        public void DeleteAreaNodeThenCancel(AreaDimensionData input)
        {
            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            //Click "删除" button and "取消"
            AreaSettings.ClickDeleteButton();
            //TimeManager.ShortPause();

            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Messages[0]));
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Messages[1]));
            
            AreaSettings.CancelErrorMsgBox();

            //Verify 
            // Verify the Area Node is not deleted
            TimeManager.MediumPause();
            Assert.AreEqual(AreaSettings.GetAreaDimensionName(),input.InputData.CommonName);
            TimeManager.MediumPause();

        }

        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteLeafAreaNode")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(DeleteAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteLeafAreaNode")]
        public void DeleteLeafAreaNode(AreaDimensionData input)
        {
            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            //Click "删除" button and "确认"
            AreaSettings.ClickDeleteButton();
            //Verify that message box popup for confirm delete
            string msgText1 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText1.Contains(input.ExpectedData.Messages[0]));
            Assert.IsTrue(msgText1.Contains(input.ExpectedData.Messages[1]));

            AreaSettings.ConfirmErrorMsgBox();
            JazzMessageBox.LoadingMask.WaitLoading();
            //AreaSettings

            //Verify the area node has been deleted under the correct hierarchy path

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();

            //  Could not select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
        }


        [Test]
        [Category("P3_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteNonLeafAreaNode")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(DeleteAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteNonLeafAreaNode")]
        public void DeleteNonLeafAreaNode(AreaDimensionData input)
        {
            string[] AreaNode2 = new string[] {"楼宇配置测试","L1","L2" };
            string[] AreaNode1 = new string[] {"楼宇配置测试","L1"};

            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            //Click "删除" button and "确认"
            AreaSettings.ClickDeleteButton();
            //Verify that message box popup for confirm delete
            string msgText3= JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText3.Contains(input.ExpectedData.Messages[0]));
            Assert.IsTrue(msgText3.Contains(input.ExpectedData.Messages[1]));

            AreaSettings.ConfirmErrorMsgBox();
            TimeManager.MediumPause();

            string msgText2 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText2.Contains(input.ExpectedData.Messages[3]));
            AreaSettings.OKErrorMsgBox();
            TimeManager.ShortPause();

            //Delete all child nodes  L4 
            AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath);
            TimeManager.MediumPause();

            AreaSettings.ClickDeleteButton();
            AreaSettings.ConfirmErrorMsgBox();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Delete L3 again
            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            //Click "删除" button and "确认"
            AreaSettings.ClickDeleteButton();
            //Verify that message box popup for confirm delete
            Assert.IsTrue(msgText3.Contains(input.ExpectedData.Messages[0]));
            Assert.IsTrue(msgText3.Contains(input.ExpectedData.Messages[1]));

            AreaSettings.ConfirmErrorMsgBox();
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.ShortPause();

            //Verify the area node has been deleted under the correct hierarchy path
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath));

            //Verify the Child area node has been deleted under the correct hierarchy path

            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
        
            // check  Level  1 deleted
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            AreaSettings.SelectAreaDimensionNodePath(AreaNode1);
            TimeManager.LongPause();

            //Click "删除" button and "确认"
            AreaSettings.ClickDeleteButton();
            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Messages[2]));
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Messages[1]));

            AreaSettings.ConfirmErrorMsgBox();
            JazzMessageBox.LoadingMask.WaitLoading();

            //Verify the area node has been deleted under the correct hierarchy path
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.ShortPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();

            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNode1));

            // check level 2 also deleted
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsSystemDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.HierarchySettingsAreaDimension);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();

            //  Could select the node path
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(AreaNode2));
        }



        [Test]
        [Category("P2_Emma")]
        [CaseID("TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteandVerifyEverywhere")]
        [Type("BFT")]
        [MultipleTestDataSource(typeof(AreaDimensionData[]), typeof(DeleteAreaDimension), "TC-J1-FVT-AreaDimensionConfiguration-Delete-101-DeleteandVerifyEverywhere")]
        public void DeleteandVerifyEverywhere(AreaDimensionData input)
        {
            //Select a Building node.	
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            AreaSettings.ClickDeleteButton();
            TimeManager.ShortPause();
            //Verify that message box popup for confirm delete
            string msgText = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Messages[0]));
            Assert.IsTrue(msgText.Contains(input.ExpectedData.Messages[1]));
            AreaSettings.ConfirmErrorMsgBox();
            TimeManager.ShortPause();

            //can't delete when area have associated tags 
            string msgText2 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText2.Contains(input.ExpectedData.Messages[2]));
            AreaSettings.OKErrorMsgBox();
            TimeManager.ShortPause();

            //Disassociated tag and delete area node again
            AssociateSettings.NavigateToAreaDimensionAssociate();
            TimeManager.ShortPause();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.ShortPause();

            AssociateSettings.FocusOnTag(input.InputData.TagName);
            TimeManager.ShortPause();
            AssociateSettings.ClickDisassociateButton(input.InputData.TagName);
            JazzMessageBox.LoadingMask.WaitLoading();
            TimeManager.MediumPause();

            //Delete again
            HierarchySettings.SelectHierarchyNodePath(input.InputData.HierarchyNodePath);
            TimeManager.MediumPause();

            AreaSettings.NavigateToAreaDimensionSetting();
            AreaSettings.SelectAreaDimensionNodePath(input.InputData.AreaNodePath);
            TimeManager.MediumPause();

            AreaSettings.ClickDeleteButton();
            TimeManager.ShortPause();
            //Verify that message box popup for confirm delete
            string msgText3 = JazzMessageBox.MessageBox.GetMessage();
            Assert.IsTrue(msgText3.Contains(input.ExpectedData.Messages[0]));
            Assert.IsTrue(msgText3.Contains(input.ExpectedData.Messages[1]));
            AreaSettings.ConfirmErrorMsgBox();
            TimeManager.ShortPause();

            //1. Check  on AssociationAreaDimension
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.AssociationAreaDimension);
            Assert.IsFalse(AreaSettings.SelectAreaDimensionNodePath(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();

            //2. Energy Analysis area node added
            JazzFunction.Navigator.NavigateToTarget(NavigationTarget.EnergyAnalysis);
            TimeManager.LongPause();
            JazzFunction.EnergyAnalysisPanel.SelectHierarchy(input.InputData.HierarchyNodePath);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();
            TimeManager.MediumPause();
            JazzFunction.EnergyAnalysisPanel.SwitchTagTab(TagTabs.AreaDimensionTab);
            JazzMessageBox.LoadingMask.WaitSubMaskLoading();

            Assert.IsFalse(JazzFunction.EnergyAnalysisPanel.SelectAreaDimension(input.ExpectedData.AreaNodePath));
            TimeManager.MediumPause();
        }
    }
}
