using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System;
using LitJson;

namespace Mento.Script.OpenAPI
{
    /// <summary>
    /// The JSON utility class.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Serialize one object whose type is T with DataContractJsonSerializer to string.
        /// </summary>
        /// <typeparam name="T">The type of the object which need be Serialized.</typeparam>
        /// <param name="source">The object which need be Serialized.</param>
        /// <returns>The serialization result string.</returns>
        public static string Serialize2String<T>(T source)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, source);

                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// Serialize one object whose type is T with DataContractJsonSerializer to bytes array.
        /// </summary>
        /// <typeparam name="T">The type of the object which need be Serialized.</typeparam>
        /// <param name="source">The object which need be Serialized.</param>
        /// <returns>The serialization result bytes array.</returns>
        public static byte[] Serialize2Bytes<T>(T source)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, source);

                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserialize specified string to a object whose type is T.
        /// </summary>
        /// <typeparam name="T">The type of deserialize target.</typeparam>
        /// <param name="source">The string which need be deserialized.</param>
        /// <returns>The deserialize target object whose type is T.</returns>
        public static T Deserialize<T>(string source)
        {
            return Deserialize<T>(Encoding.UTF8.GetBytes(source));
        }

        /// <summary>
        /// Deserialize specified bytes array to a object whose type is T.
        /// </summary>
        /// <typeparam name="T">The type of deserialize target.</typeparam>
        /// <param name="source">The bytes array which need be deserialized.</param>
        /// <returns>The deserialize target object whose type is T.</returns>
        public static T Deserialize<T>(byte[] source)
        {
            DataContractJsonSerializer deserialize = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream stream = new MemoryStream(source))
            {
                return (T)deserialize.ReadObject(stream);
            }
        }

        /// <summary>
        /// Deserialize specified JSON string to a dynamic object
        /// </summary>
        /// <param name="source">The JSON string which need be deserialized.</param>
        /// <returns>The deserialize target dynamic object.</returns>
        /// <remarks>This method not decode nesting.</remarks>
        public static dynamic Deserialize(string source)
        {
            return Json.Decode(source);
        }

        /// <summary>
        /// Get the json array data
        /// </summary>
        /// <param name="source">The JSON string which need be serialized.</param>
        /// <returns>The deserialize target dynamic object.</returns>
        /// <remarks>This method not decode nesting.</remarks>
        public static T DeserializeToArray<T>(string source)
        {
            return JsonConvert.DeserializeObject<T>(source);
        }

        public static List<T> JSONStringToList<T>(string JsonStr)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
            return objs;
        }
 
        public static T Deserialize2ArrayList<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

        public static dynamic Deserialize2Array(string source)
        {
            //JArray ja = (JArray)JsonConvert.DeserializeObject(source);
            dynamic ja = JsonConvert.DeserializeObject(source);
            return ja;
        }

        public static JObject Deserialize2Object(string source)
        {
            JObject ja = (JObject)JsonConvert.DeserializeObject(source);

            return ja;
        }
    }
}