﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.TestApi.TestData
{
    public abstract class ISingleTestData<I, E>
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

    public abstract class IMultipleTestData<I, E>
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

    public abstract class InputTestDataBase
    {
    }

    public abstract class ExpectedTestDataBase
    {
    }
}
