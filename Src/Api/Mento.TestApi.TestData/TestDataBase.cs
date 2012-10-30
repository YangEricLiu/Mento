using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    public abstract class TestDataBase<I, E>
        where I : InputTestDataBase
        where E : ExpectedTestDataBase
    {
        public I InputData
        {
            get;
            set;
        }

        public E ExpectedData
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }

    public abstract class InputTestDataBase 
    {
    }

    public abstract class ExpectedTestDataBase 
    {
    }
}
