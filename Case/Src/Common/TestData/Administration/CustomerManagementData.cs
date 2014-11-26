using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
    public class CustomerManagementData : TestDataBase<CustomerInputData, CustomerExpectedData>
    {
    }

    public class CustomerInputData : InputTestDataBase
    {
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string LogoPath { get; set; }
        public string Address { get; set; }
        public string RealName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string OperationTime { get; set; }
        public string Comments { get; set; }
        public string[] MapOptions { get; set; }
        public string CustomerAdmin { get; set; }

        public CustomerInputData(string commonName, string code, string logoPath, string address, string realName, string telephone, string email, string operationTime, string comments, string[] mapOptions, string customerAdmin)
        {
            this.CommonName = commonName;
            this.Code = code;
            this.LogoPath = logoPath;
            this.Address = address;
            this.RealName = realName;
            this.Telephone = telephone;
            this.Email = email;
            this.OperationTime = telephone;
            this.Comments = comments;
            this.MapOptions = mapOptions;
            this.CustomerAdmin = customerAdmin;
        }
    }

    public class CustomerExpectedData : ExpectedTestDataBase
    {
        public string CommonName { get; set; }
        public string Code { get; set; }
        public string LogoPath { get; set; }
        public string Address { get; set; }
        public string RealName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string OperationTime { get; set; }
        public string Comments { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string[] MapOptions { get; set; }
        public string CustomerAdmin { get; set; }
        public string[] CustomerAdminName { get; set; }

        public CustomerExpectedData(string commonName, string code, string logoPath, string address, string realName, string telephone, string email, string operationTime, string comments, string message, string[] mapOptions, string customerAdmin)
        {
            this.CommonName = commonName;
            this.Code = code;
            this.LogoPath = logoPath;
            this.Address = address;
            this.RealName = realName;
            this.Telephone = telephone;
            this.Email = email;
            this.OperationTime = operationTime;
            this.Comments = comments;
            this.Message = message;
            this.MapOptions = mapOptions;
            this.CustomerAdmin = customerAdmin;
        }
    }

}
