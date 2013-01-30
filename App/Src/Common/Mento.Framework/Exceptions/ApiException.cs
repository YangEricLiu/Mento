using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Exceptions
{
    /// <summary>
    /// Test API exception abstract class
    /// </summary>
    public class ApiException : MentoException
    {
        public ApiException()
            : base()
        {
        }

        public ApiException(string message)
            : base(message)
        { 
        }

        public ApiException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }
    }
}
