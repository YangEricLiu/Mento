using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.TestData;

namespace Administration.Calendar.TestData
{
    public class MultipleExampleData : MultipleTestDataBase<ExampleInputData, ExampleExpectedData>
    {
    }

    public class TagTestData : MultipleTestDataBase<TagInput, ExpectedTestDataBase>
    { 
    }

    public class TagInput : InputTestDataBase
    {
        public long TagID { get; set; }
        public string TagName { get; set; }


    }
}
