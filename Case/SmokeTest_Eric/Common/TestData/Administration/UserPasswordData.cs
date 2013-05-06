using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class UserPasswordData : TestDataBase<UserInputData, UserExpectedData>
    {
    }

    public class PasswordInputData : InputTestDataBase
    {
        public string OriginalPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string[] SpecialChar { get; set; }

        public PasswordInputData(string[] specialchar, string originalpassword, string newpassword, string confirmpassword)
        {
            this.SpecialChar = specialchar;
            this.OriginalPassword = originalpassword;
            this.NewPassword = newpassword;
            this.ConfirmPassword = confirmpassword;
        }
    }
    public class PasswordExpectedData : ExpectedTestDataBase
        {
            public string OriginalPassword { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmPassword { get; set; }
            public string[] SpecialChar { get; set; }

            public PasswordExpectedData(string[] specialchar, string originalpassword, string newpassword, string confirmpassword)          {
                this.SpecialChar = specialchar;
                this.OriginalPassword = originalpassword;
                this.NewPassword = newpassword;
                this.ConfirmPassword = confirmpassword;
            }        
        }
}
