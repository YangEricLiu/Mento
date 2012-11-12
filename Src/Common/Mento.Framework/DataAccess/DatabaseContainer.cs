using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Mento.Framework.Constants;

namespace Mento.Framework
{
    public static class DatabaseContainer
    {
        public static readonly Database Database = DatabaseFactory.CreateDatabase(ConfigurationKey.MENTO_DATABASE_KEY);
    }
}
