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
         public string Name { get; set; }
         public string Code { get; set; }
         public string LogoPath { get; set; }
         public string Address { get; set; }
         public string ResponsiblePerson { get; set; }
         public string Telephone { get; set; }
         public string Email { get; set; }
         public string OperationTime { get; set; }
         public string Comment { get; set; }
     }

     public class CustomerExpectedData : ExpectedTestDataBase
     {
         public string Name { get; set; }
         public string Code { get; set; }
         public string LogoPath { get; set; }
         public string Address { get; set; }
         public string ResponsiblePerson { get; set; }
         public string Telephone { get; set; }
         public string Email { get; set; }
         public string OperationTime { get; set; }
         public string Comment { get; set; }
         public string Message { get; set; }
         public string ErrorMessage { get; set; }
     }
}
