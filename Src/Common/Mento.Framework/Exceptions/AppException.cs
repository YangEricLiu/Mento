using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Exceptions
{
    /// <summary>
    /// App exception abstract class
    /// </summary>
    public class AppException : MentoException
    {
        public AppException()
            : base()
        {
        }

        public AppException(string message)
            : base(message)
        { 
        }

        public AppException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }
    }
}
