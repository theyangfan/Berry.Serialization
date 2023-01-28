using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Berry.Serialization
{
    internal class Example
    {
        static void Main()
        {
            string json = "{\"姓名\": \"张伟\",\"年龄\": 20}";
            Person person = CustomJConvert.DeserializeObject<Person>(json);
            Console.WriteLine(CustomJConvert.SerializeObject(person, Formatting.Indented));
            // Output: {"NAME":"张伟","AGE":20}
        }

        public class Person
        {
            [CustomJProperty(DeserializeName = "姓名", SerializeName = "NAME")]
            public string Name { get; set; }

            [CustomJProperty(DeserializeName = "年龄", SerializeName = "AGE")]
            public int Age { get; set; }
        }
    }
}
