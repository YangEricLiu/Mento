using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace Mento.Utility
{
    /// <summary>
    /// The reflection helper class.
    /// </summary>
    public static class ReflectionHelper
    {
        public static void SetPrivateFieldValue(object target, Type targetType, string fieldName, object value)
        {
            FieldInfo field = targetType.GetField(fieldName, BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.ExactBinding);

            if (field != null)
                field.SetValue(target, value);
        }

        public static T GetPrivateFielValue<T>(object target, Type targetType, string fieldName)
        {
            FieldInfo field = targetType.GetField(fieldName, BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.ExactBinding);

            if (field == null)
                return default(T);

            return (T)field.GetValue(target);
        }

        public static Stream GetEmbeddedResource(Assembly assembly,string resourceName)
        {
            var query = assembly.GetManifestResourceNames().Where(n => n.EndsWith(resourceName));

            if (query.Count() > 0)
                return assembly.GetManifestResourceStream(query.First());

            return null;
        }

        public static string GetEmbeddedResourceContent(Assembly assembly,string resourceName)
        {
            StreamReader reader = new StreamReader(GetEmbeddedResource(assembly, resourceName));

            string content = reader.ReadToEnd();

            reader.Close();
            reader.Dispose();

            return content;
        }

        public static object MakeDynamicCall(Type callingType, string callMethodName, BindingFlags flags, object callingInstance = null, object[] parameters = null)
        {
            MethodInfo method = GetMethodInfo(callingType, callMethodName, flags);

            return method.Invoke(callingInstance, parameters);
        }

        public static object MakeGenericDynamicCall(Type callingType, string callMethodName, BindingFlags flags, Type genericType, object callingInstance = null, object[] parameters = null)
        {
            MethodInfo method = GetMethodInfo(callingType, callMethodName, flags);
            
            MethodInfo genericMethod = method.MakeGenericMethod(genericType);

            return genericMethod.Invoke(callingInstance, parameters);
        }

        public static MethodInfo GetMethodInfo(Type callingType, string callMethodName, BindingFlags flags)
        {
            return callingType.GetMethod(callMethodName, flags);
        }
    }
}