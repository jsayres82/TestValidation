using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuvo.TestValidation.Utilities
{
    /// <summary>
    /// Provides helper methods for JSON serialization and deserialization.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Serializes an object to a JSON string with custom settings.
        /// </summary>
        public static string ToJson(this object obj) =>
            JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented,
                Converters = { new TestRequirementsConverter(), new GenericValidatorConverter() },
            });

        /// <summary>
        /// Deserializes a JSON string into an object of type T.
        /// </summary>
        public static T FromJson<T>(string json) =>
            JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Converters = { new TestRequirementsConverter() }
            });

        /// <summary>
        /// Reads a JSON file and deserializes its content into an object of type T.
        /// </summary>
        public static T LoadFromJson<T>(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The file at {filePath} does not exist.");

            string json = File.ReadAllText(filePath);
            return FromJson<T>(json);
        }

        /// <summary>
        /// Writes a JSON string to a file at the specified path.
        /// </summary>
        public static void WriteJsonToFile(this string json, string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Serializes an object and writes the JSON to a file.
        /// </summary>
        public static void WriteObjectToJsonFile(this object obj, string filePath)
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();

            var json = obj.ToJson();
            File.WriteAllText(filePath, json);
        }
    }
}
