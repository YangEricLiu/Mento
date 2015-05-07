using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Customer
{
    public class AdministratorInfoData : TestDataBase<AdministratorInfoInputData, AdministratorInfoExpectedData>
    {
    }

    public class AdministratorInfoInputData : InputTestDataBase
    {
        public string[] HierarchyNodePath { get; set; }
        public string RealName { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string ValidChar { get; set; }
        public string InvalidChar { get; set; }
    }

    public class AdministratorInfoExpectedData : ExpectedTestDataBase
    {
        public string RealName { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string ValidChar { get; set; }
        public string InvalidChar { get; set; }
    }
}
