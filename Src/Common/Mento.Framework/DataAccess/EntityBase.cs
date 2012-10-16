using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mento.Framework
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Identity of the entity
        /// </summary>
        public long ID { get; set; }
    }
}
