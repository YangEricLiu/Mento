using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Utility;

namespace Mento.TestApi.TestData
{
    /// <summary>
    /// Test data base class
    /// </summary>
    /// <typeparam name="I">Input data type</typeparam>
    /// <typeparam name="E">Expected data type</typeparam>
    public abstract class TestDataBase<I, E>
        where I : InputTestDataBase
        where E : ExpectedTestDataBase
    {
        /// <summary>
        /// Input data property
        /// </summary>
        public I InputData
        {
            get;
            set;
        }

        /// <summary>
        /// Expected data property
        /// </summary>
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

    /// <summary>
    /// Input test data base class
    /// </summary>
    public abstract class InputTestDataBase 
    {
    }

    /// <summary>
    /// Expected test data base class
    /// </summary>
    public abstract class ExpectedTestDataBase 
    {
    }
}
