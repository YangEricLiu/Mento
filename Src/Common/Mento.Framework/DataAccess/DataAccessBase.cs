using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Mento.Framework.Constants;
using System.Data;
using System.Reflection;

namespace Mento.Framework
{
    /// <summary>
    /// Data access base class
    /// </summary>
    public abstract class DataAccessBase
    {
        /// <summary>
        /// Database connection instance
        /// </summary>
        protected static readonly Database Database = DatabaseContainer.Database;

        /// <summary>
        /// Construct entities from a data reader
        /// </summary>
        /// <typeparam name="T">The entity type to be constructed</typeparam>
        /// <param name="reader">The data reader which will rerurn a data row from database</param>
        /// <returns>Entity list of the desired type</returns>
        protected virtual List<T> ReadEntity<T>(IDataReader reader) where T : EntityBase
        { 
            List<T> list = new List<T>();

            while (reader.Read())
            {
                T entity = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (reader.GetSchemaTable().AsEnumerable().Where(r => String.Equals(r["ColumnName"].ToString(), property.Name, StringComparison.OrdinalIgnoreCase)).Count() <= 0)
                        continue;

                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(entity, reader[property.Name].ToString(), null);
                    }
                    else if (property.PropertyType == typeof(long))
                    {
                        property.SetValue(entity, (long)reader[property.Name], null);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        property.SetValue(entity, (bool)reader[property.Name], null);
                    }
                    else if (property.PropertyType == typeof(double))
                    {
                        property.SetValue(entity, (double)reader[property.Name], null);
                    }
                    else if (property.PropertyType == typeof(decimal))
                    {
                        property.SetValue(entity, (decimal)reader[property.Name], null);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        property.SetValue(entity, Convert.ToDateTime(reader[property.Name]), null);
                    }
                    else if (property.PropertyType.IsEnum)
                    {
                        property.SetValue(entity, Enum.Parse(property.PropertyType,reader[property.Name].ToString()), null);
                    }
                    else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        var realType = property.PropertyType.GetGenericArguments()[0];
                        if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                            if (realType.IsEnum)
                                property.SetValue(entity, Enum.Parse(realType, reader[property.Name].ToString()), null);
                            else if (realType == typeof(DateTime))
                                property.SetValue(entity, Convert.ToDateTime(reader[property.Name]), null);
                    }
                }

                list.Add(entity);
            }

            return list;
        
        }
    }
}
