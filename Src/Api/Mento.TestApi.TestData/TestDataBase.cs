using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    public abstract class SingleTestDataBase<I, E>
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
    }

    public abstract class MultipleTestDataBase<I, E>
        where I : InputTestDataBase
        where E : ExpectedTestDataBase
    {
        public I[] InputData
        {
            get;
            set;
        }

        public E[] ExpectedData
        {
            get;
            set;
        }
    }

    public abstract class InputTestDataBase : TestDataElementBase
    {
    }

    public abstract class ExpectedTestDataBase : TestDataElementBase
    {
    }

    public abstract class TestDataElementBase
    { 
        public virtual string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
