using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;
using Mento.TestApi.WebUserInterface.ControlCollection;

namespace Mento.ScriptCommon.Library.Functions
{
    public class EnergyAnalysisPanel
    {
        internal EnergyAnalysisPanel()
        { 
        }

        //Select hierarchy button
        private static Button SelectHierarchyButton = JazzButton.EnergyViewSelectHierarchyButton;

        //Hierarchy tree

        //TagGrid

        //Toolbar

        //Chart

        //DataGrid


        public void SelectHierarchy()
        {
            SelectHierarchyButton.Click();

        }

    }

    internal class EnergyViewToolbar
    {
        //StartDatePicker
        //StartTimePicker
        //EndDatePicker
        //EndTimePicker
        
        //ViewMenu
        //ConvertTargetSplitButton
        //PeakValleyButton

        //AddTimeSpanButton
        //RemoveAllTagButton
        //MoreMenu
 
    }
}
