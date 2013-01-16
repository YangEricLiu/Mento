using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;
using Mento.Utility;

namespace Mento.ScriptCommon.TestData.Administration
{
     public class CustomerManagementData : TestDataBase<CustomerInputData,ExpectedTestDataBase>
    {
    }

     public class CustomerInputData : InputTestDataBase
     {
         public string Name { get; set; }
         public string Code { get; set; }
         public string Address { get; set; }
         public string ResponsiblePerson { get; set; }
         public string Telephone { get; set; }
         public string Email { get; set; }
         public string OperationTime { get; set; }
         public string Comment { get; set; }

         public CustomerInputData(string name, string code, string address, string responsiblePerson, string telephone, string email, string operationTime, string comment)
         {
             this.Name = name;
             this.Code = code;
             this.Address = address;
             this.ResponsiblePerson = responsiblePerson;
             this.Telephone = telephone;
             this.Email = email;
             this.OperationTime = operationTime;
             this.Comment = comment;
         }
     }
}
