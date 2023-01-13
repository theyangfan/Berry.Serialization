using System;
using System.Collections.Generic;
using System.Text;

namespace Berry.Serialization
{
    /// <summary>
    /// 属性自定义特性。
    /// </summary>
    public class CustomJPropertyAttribute : Attribute
    {
        public CustomJPropertyAttribute()
        {
            Serializable = true;
            Deserializable = true;
        }

        public CustomJPropertyAttribute(string name)
        {
            Serializable = true;
            Deserializable = true;
            Name = name;
        }
        /// <summary>
        /// 属性是否可以被序列化
        /// </summary>
        public bool Serializable { get; set; }
        /// <summary>
        /// 属性是否可以被反序列化
        /// </summary>
        public bool Deserializable { get; set; }
        /// <summary>
        /// 属性序列化的Json字段名
        /// </summary>
        public string Name { get; set; }
        public string SerializeName { get; set; }
        /// <summary>
        /// 属性反序列化的Json字段名
        /// </summary>
        public string DeserializeName { get; set; }
    }
}
