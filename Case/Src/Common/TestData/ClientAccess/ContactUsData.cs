using System;
using System.Collections.Generic;
using System.Linq;
using Mento.TestApi.TestData;

namespace Mento.ScriptCommon.TestData.ClientAccess
{
    public class ContactUsData : TestDataBase<ContactUsInputData, ContactUsExpectedData>
    {
    }

    public class ContactUsInputData : InputTestDataBase
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string DescriptionFields { get; set; }
        public string[] Names { get; set; }
        public string[]Telephones { get; set; }
        public string[] Companys { get; set; }
        public string[] Titles { get; set; }
        public string[] DescriptionFieldss { get; set; }
        public string Customer { get; set; }
    }

    public class ContactUsExpectedData : ExpectedTestDataBase
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string DescriptionFields { get; set; }
        public string[] InvalidMessages { get; set; }
    }
}
