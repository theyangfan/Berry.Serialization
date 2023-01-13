using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Berry.Serialization
{
    public class CustomJConvert
    {
        public static string SerializeObject(object value)
        {
            return SerializeObject(value, Formatting.None);
        }

        public static string SerializeObject(object value, Formatting formatting)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new ContractSerializeResolver();
            return JsonConvert.SerializeObject(value, formatting, settings);
        }

        public static T DeserializeObject<T>(string value)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new ContractDeserializeResolver();
            return JsonConvert.DeserializeObject<T>(value, settings);
        }
    }
}
