using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Mento.Utility
{
    public static class ReflectionHelper
    {
        public static void SetPrivateFieldValue(object target, Type targetType, string fieldName, object value)
        {
            FieldInfo field = targetType.GetField(fieldName, BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.ExactBinding);

            if (field != null)
                field.SetValue(target, value);
        }
    }
}
