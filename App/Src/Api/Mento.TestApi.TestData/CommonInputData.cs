using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.TestData
{
    public class CommonTestData
    {
        public CommonInputData InputData { get; set; }
        public CommonExpectedData ExpectedData { get; set; }
    }

    public class CommonInputData
    {
        public string AccountID { get; set; }
        public string Password { get; set; }
        public string PersonName { get; set; }
        public string CustomerName { get; set; }
        public string CommonName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public string Meter { get; set; }
        public string Channel { get; set; }
        public string DataValue { get; set; }
        public string Comments { get; set; }
        public string FeedbackComments { get; set; }
    }

    public class CommonExpectedData
    {
        public string AccountID { get; set; }
        public string Password { get; set; }
        public string PersonName { get; set; }
        public string CustomerName { get; set; }
        public string CommonName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public string Meter { get; set; }
        public string Channel { get; set; }
        public string DataValue { get; set; }
        public string Comments { get; set; }
        public string FeedbackComments { get; set; }
    }
}
