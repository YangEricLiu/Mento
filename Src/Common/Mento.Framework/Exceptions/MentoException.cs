using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Exceptions
{
    /// <summary>
    /// Mento exception abstract class
    /// </summary>
    public abstract class MentoException : Exception
    {
        public MentoException()
            : base()
        {
        }

        public MentoException(string message)
            : base(message)
        { 
        }

        public MentoException(string message, Exception innerException)
            : base(message, innerException)
        { 
        }
    }
}
