using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.ClientAccess
{
    public class UserProfileData : TestDataBase<UserProfileInputData, UserProfileExpectedData>
    {
    }

    public class UserProfileInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public string[] TypeList { get; set; }
        public string[] TitleList { get; set; }

        public UserProfileInputData(string name, string realname, string type, string title, string telephone, string email, string comments, string[] typeList, string[] titleList)
        {
            this.Name = name;
            this.RealName = realname;
            this.Type = type;
            this.Title = title;
            this.Telephone = telephone;
            this.Email = email;
            this.Comments = comments;
            this.TitleList = titleList;
            this.TypeList = typeList;
        }
    }
    public class UserProfileExpectedData : ExpectedTestDataBase
        {
            public string Name { get; set; }
            public string RealName { get; set; }
            public string Type { get; set; }
            public string Title { get; set; }
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Comments { get; set; }
            public string[] TypeList { get; set; }
            public string[] TitleList { get; set; }

            public UserProfileExpectedData(string name, string realname, string type, string title, string telephone, string email, string comments, string[] typeList, string[] titleList)
            {
                this.Name = name;
                this.RealName = realname;
                this.Type = type;
                this.Title = title;
                this.Telephone = telephone;
                this.Email = email;
                this.Comments = comments;
                this.TitleList = titleList;
                this.TypeList = typeList;
            }        
        }
}
