using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class UserSettingsData : TestDataBase<UserInputData, UserExpectedData>
    {
    }

    public class UserInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public string OriginalName { get; set; }
        public string AccountID { get; set; }
        public string RealName { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string AssociatedCustomer { get; set; }
        public string Title { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public string[] TypeList { get; set; }
        public string[] FunctionScopeList { get; set; }
        public string[] titleList { get; set; }

        public UserInputData(string originalname,string commonName, string name, string realname, string type, string associatedcustomer, string title, string telephone, string email, string comments,string[] typeList,string[] functionScopeList)
        {
            this.CommonName = commonName;
            this.OriginalName = originalname;
            this.AccountID = name;
            this.RealName = realname;
            this.Type = type;
            this.AssociatedCustomer = associatedcustomer;
            this.Title = title;
            this.Telephone = telephone;
            this.Email = email;
            this.Comments = comments;
            this.TypeList = typeList;
            this.FunctionScopeList = functionScopeList;
        }
    }
    public class UserExpectedData : ExpectedTestDataBase
        {
            public string CommonName { get; set; }
            public string AccountID { get; set; }
            public string RealName { get; set; }
            public string DisplayName { get; set; }
            public string Type { get; set; }
            public string AssociatedCustomer { get; set; }
            public string Title { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Comments { get; set; }
            public string OriginalName { get; set; }
            public string Message { get; set; }
            public string[] TypeList { get; set; }
            public string[] FunctionScopeList { get; set; }

            public UserExpectedData(string originalname, string commonName, string name, string realname, string type, string associatedcustomer, string title, string telephone, string email, string comments, string message, string[] typeList, string[] functionScopeList)
            {
                this.CommonName = commonName;
                this.OriginalName = originalname;
                this.AccountID = name;
                this.RealName = realname;
                this.Type = type;
                this.AssociatedCustomer = associatedcustomer;
                this.Title = title;
                this.Telephone = telephone;
                this.Email = email;
                this.Comments = comments;
                this.Message = message;
                this.TypeList = typeList;
                this.FunctionScopeList = functionScopeList;
            }       
        }
}
