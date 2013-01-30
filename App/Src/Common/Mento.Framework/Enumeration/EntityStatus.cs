using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework.Enumeration
{
    /// <summary>
    /// Represents the status that an entity active or deleted
    /// </summary>
    public enum EntityStatus
    {
        /// <summary>
        /// Represents the status that an entity is deleted
        /// </summary>
        Deleted = 0,

        /// <summary>
        /// Represents the status that an entity is active
        /// </summary>
        Active = 1,
    }
}
