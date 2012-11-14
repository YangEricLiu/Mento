using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.WebUserInterface
{
    /// <summary>
    /// Constant value for Element Map Key value, which should be sync up with ElementMap XML file.
    /// </summary>
    public static class ElementKey
    {
        public const string LoadingMessage = "LoadingMessage";
        
        public const string FormulaField = "FormulaField";
        public const string TagNameRow = "TagNameRow";

        public const string TreeNode = "TreeNode";
        public const string IsTreeNodeExpand = "IsTreeNodeExpand";
        
        //Login function
        public const string LoginName = "LoginName";
        public const string LoginPassword = "LoginPassword";

        public const string InvalidNameInputError = "InvalidNameInputError";
        public const string PopUpMessageBox = "PopUpMessageBox";
        public const string LoginSubmit = "LoginSubmit";

        public const string AddHierarchyButton = "AddHierarchyButton";
        public const string HierarchyName = "HierarchyName";
        public const string HierarchyCode = "HierarchyCode";
        public const string HierarchyType = "HierarchyType";
        public const string Orgnization = "Orgnization";
        public const string Site = "Site";
        public const string Building = "Building";
        public const string HierarchyComment = "HierarchyComment";

        public const string CheckNodeButton = "CheckNodeButton";
        public const string HierarchySaveButton = "HierarchySaveButton";
        public const string HierarchyCancelButton = "HierarchyCancelButton";
        public const string HierarchyUpdateButton = "HierarchyUpdateButton";
        public const string HierarchyCreateOKText = "HierarchyCreateOKText";
        public const string HierarchyOKButton = "HierarchyOKButton";

        public const string FormulaTab = "FormulaTab";
        public const string RowCellName = "RowCellName";
        public const string FormulaUpdateButton = "FormulaUpdateButton";
        public const string FormulaSaveButton = "FormulaSaveButton";
        public const string FormulaTagRow = "FormulaTagRow";
        public const string RowCheckBox = "RowCheckBox";
        public const string AssociateTagButton = "AssociateTagButton";
        public const string IsRowChecked = "IsRowChecked";
        public const string TestButton = "TestButton";

        public const string AddVtagButton = "AddVtagButton";
        public const string VtagConfigButton = "VtagConfigButton";
        public const string VtagSaveButton = "VtagSaveButton";
        public const string VtagCancelButton = "VtagCancelButton";
        public const string VtagName = "VtagName";
        public const string VtagCode = "VtagCode";
        public const string VtagCommodity = "VtagCommodity";
        public const string Electric = "Electric";
        public const string VtagUOM = "VtagUOM";
        public const string VtagKWH = "VtagKWH";
        public const string VtagCalculationStep = "VtagCalculationStep";
        public const string Hourly = "Hourly";
        public const string VtagCalculationType = "VtagCalculationType";
        public const string VtagSum = "VtagSum";
        public const string VtagComment = "VtagComment";


        //PTag Configuration
        public const string PtagAddButton = "PtagAddButton";
        public const string PtagSaveButton = "PtagSaveButton";
        public const string PtagUpdateButton = "PtagUpdateButton";
        public const string PtagName = "PtagName";
        public const string PtagCode = "PtagCode";
        public const string PtagMeterCode = "PtagMeterCode";
        public const string PtagChannelId = "PtagChannelId";
        public const string PtagCommodityId = "PtagCommodityId";
        public const string PtagUomId = "PtagUomId";
        public const string PtagCalculationType = "PtagCalculationType";
        public const string PtagComment = "PtagComment";
        //Commodity
        public const string Electricity = "Electricity";
        public const string Water = "Water";
        //UOM
        public const string KWH = "KWH";
        public const string Ton = "Ton";
        //CaculationType
        public const string Sum = "Sum";
        public const string Avg = "Avg";
    }
}
