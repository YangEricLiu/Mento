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
        public string OriginalName { get; set; }
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Type { get; set; }
        public string AssociatedCustomer { get; set; }
        public string Title { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string[] SpecialChar { get; set; }

        public UserInputData(string originalname, string[] specialchar, string name, string realname, string type, string associatedcustomer, string title, string telephone, string email, string comment)
        {
            this.OriginalName = originalname;
            this.SpecialChar = SpecialChar;
            this.Name = name;
            this.RealName = realname;
            this.Type = type;
            this.AssociatedCustomer = associatedcustomer;
            this.Title = title;
            this.Telephone = telephone;
            this.Email = email;
            this.Comment = comment;
        }
    }
    public class UserExpectedData : ExpectedTestDataBase
        {
            public string Name { get; set; }
            public string RealName { get; set; }
            public string Type { get; set; }
            public string AssociatedCustomer { get; set; }
            public string Title { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Comment { get; set; }
            public string OriginalName { get; set; }
            public string[] SpecialChar { get; set; }

            public UserExpectedData(string originalname, string[] specialchar, string name, string realname, string type, string associatedcustomer, string title, string telephone, string email, string comment)
            {
                this.OriginalName = originalname;
                this.SpecialChar = specialchar;
                this.Name = name;
                this.RealName = realname;
                this.Type = type;
                this.AssociatedCustomer = associatedcustomer;
                this.Title = title;
                this.Telephone = telephone;
                this.Email = email;
                this.Comment = comment;
            }        
        }
}
