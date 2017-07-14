using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace gsub.Common
{
    /// <summary>
    ///     Handles serialization and deserialization of the configuration.
    ///     Serializes "$type" because we are using inheritance of abstract classes.
    /// </summary>
    internal static class SerializationHelper
    {
        public static T Deserialize<T>(JsonReader reader)
        {
            var serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new DefaultContractResolver(),
                TypeNameHandling = TypeNameHandling.Auto
            };

            return serializer.Deserialize<T>(reader);
        }

        public static T Deserialize<T>(string jsonText)
        {
            return Deserialize<T>(new JsonTextReader(new StringReader(jsonText)));
        }


        public static string Serialize<T>(T instance, IContractResolver contractResolver)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = contractResolver,
                TypeNameHandling = TypeNameHandling.Auto
            };
            return JsonConvert.SerializeObject(instance, Formatting.Indented, settings);
        }

        public static string Serialize<T>(T instance)
        {
            return Serialize(instance, new DefaultContractResolver());
        }

        public static bool SerializeToFile<T>(T instance, string filename)
        {
            string json = Serialize(instance, new DefaultContractResolver());
            try
            {
                File.WriteAllText(filename, json);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}