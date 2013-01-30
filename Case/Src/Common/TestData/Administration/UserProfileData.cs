using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class UserProfileData : TestDataBase<UserProfileInputData, UserProfileExpectedData>
    {
    }

    public class UserProfileInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Type { get; set; }
        public string AssociatedCustomer { get; set; }
        public string Title { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        public UserProfileInputData(string name, string realname, string type, string associatedcustomer, string title, string telephone, string email, string comment)
        {
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
    public class UserProfileExpectedData : ExpectedTestDataBase
        {
            public string Name { get; set; }
            public string RealName { get; set; }
            public string Type { get; set; }
            public string AssociatedCustomer { get; set; }
            public string Title { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Comment { get; set; }

            public UserProfileExpectedData(string name, string realname, string type, string associatedcustomer, string title, string telephone, string email, string comment)
            {
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

    public class UserAndProfileData : TestDataBase<UserUInputData, UserProfilePExpectedData>
    {
    }

    public class UserUInputData : InputTestDataBase
    {
        public string NameU { get; set; }
        public string RealNameU { get; set; }
        public string TypeU { get; set; }
        public string AssociatedCustomerU { get; set; }
        public string TitleU { get; set; }
        public string TelephoneU { get; set; }
        public string EmailU { get; set; }
        public string CommentU { get; set; }

        public UserUInputData(string name, string realname, string type, string associatedcustomer, string title, string telephone, string email, string comment)
        {
            this.NameU = name;
            this.RealNameU = realname;
            this.TypeU = type;
            this.AssociatedCustomerU = associatedcustomer;
            this.TitleU = title;
            this.TelephoneU = telephone;
            this.EmailU = email;
            this.CommentU = comment;
        }
    }
    public class UserProfilePExpectedData : ExpectedTestDataBase
    {
        public string NameP { get; set; }
        public string RealNameP { get; set; }
        public string TypeP { get; set; }
        public string AssociatedCustomerP { get; set; }
        public string TitleP { get; set; }
        public string TelephoneP { get; set; }
        public string EmailP { get; set; }
        public string CommentP { get; set; }

        public UserProfilePExpectedData(string name, string realname, string type, string associatedcustomer, string title, string telephone, string email, string comment)
        {
            this.NameP = name;
            this.RealNameP = realname;
            this.TypeP = type;
            this.AssociatedCustomerP = associatedcustomer;
            this.TitleP = title;
            this.TelephoneP = telephone;
            this.EmailP = email;
            this.CommentP = comment;
        }
    }

}
