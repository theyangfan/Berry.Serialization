using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Berry.Serialization
{
    /// <summary>
    /// Provides methods for converting between .NET types and JSON types.
    /// </summary>
    public static class CustomJConvert
    {
        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string SerializeObject(object value)
        {
            return SerializeObject(value, Formatting.None);
        }

        /// <summary>
        /// Serializes the specified object to a JSON string using formatting.
        /// </summary>
        /// <param name="value">The object to serilize.</param>
        /// <param name="formatting">Indicates how the output should be formatted.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string SerializeObject(object value, Formatting formatting)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new ContractSerializeResolver();
            return JsonConvert.SerializeObject(value, formatting, settings);
        }

        /// <summary>
        /// Deserializes the JSON to the specified .NET type.
        /// </summary>
        /// <typeparam name="T">The type of the objetc to deserialize to.</typeparam>
        /// <param name="value">The JSON to deserialize.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        public static T DeserializeObject<T>(string value)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new ContractDeserializeResolver();
            return JsonConvert.DeserializeObject<T>(value, settings);
        }
    }
}
