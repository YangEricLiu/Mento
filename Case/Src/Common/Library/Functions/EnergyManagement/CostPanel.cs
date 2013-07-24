using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;
using Mento.TestApi.WebUserInterface;

namespace Mento.ScriptCommon.Library.Functions
{
    public class CostPanel : EnergyViewPanel
    {
        private static Grid CommodityGrid = JazzGrid.CommodityCostGrid;
        private static Grid TotalCommotidyGrid = JazzGrid.TotalCommodityCostGrid;
        
        protected override Chart Chart
        {
            get { return JazzChart.EnergyViewChart; }
        }

        protected override Grid EnergyDataGrid
        {
            get { return JazzGrid.EnergyAnalysisEnergyDataList; }
        }

        internal CostPanel() { }

        public void SwitchTagTab(TagTabs tab)
        {
            switch (tab)
            {
                case TagTabs.SystemDimensionTab:
                    //click system tab
                    break;
                case TagTabs.AreaDimensionTab:
                    //click area tab
                    break;
                case TagTabs.HierarchyTag:
                default:
                    //click all tab
                    break;
            }
        }

        public void SelectSystemDimension(string[] systemDimensionPath)
        {
            throw new NotImplementedException();
        }

        public void SelectAreaDimension(string[] areaDimensionPath)
        {
            throw new NotImplementedException();
        }

        public void SelectCommodity(string[] commodityNames = null)
        {
            //total
            if (commodityNames == null || commodityNames.Length <= 0)
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质总览", false);
            }
            else //specified commodity
            {
                TotalCommotidyGrid.CheckRowCheckbox(2, "介质单项", false);
                JazzMessageBox.LoadingMask.WaitSubMaskLoading();
                TimeManager.MediumPause();

                foreach (var commodity in commodityNames)
                {
                    CommodityGrid.CheckRowCheckbox(2, commodity, false);
                    JazzMessageBox.LoadingMask.WaitLoading();
                }
            }
        }

        public void DeselectCommodity(string[] commodityNames)
        {
            throw new NotImplementedException();
        }
    }
}
