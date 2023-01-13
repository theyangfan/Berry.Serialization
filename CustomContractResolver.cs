using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Berry.Serialization
{
    /// <summary>
    /// 数据协定（Data Contract）序列化解析器，数据协定是一组字段的抽象说明，其中包含每个字段的名称和数据类型。
    /// 用于JSON序列化时解析类型的 <see cref="JsonContract"/> 信息
    /// </summary>
    public class ContractSerializeResolver : DefaultContractResolver
    {
        /// <summary>
        /// 重写 CreateProperty，自定义创建 <see cref="JsonProperty"/>。
        /// </summary>
        /// <param name="member">成员信息</param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
#if NETSTANDARD2_0
            CustomJPropertyAttribute attr = member.GetCustomAttribute(typeof(CustomJPropertyAttribute)) as CustomJPropertyAttribute;
#elif NET40_OR_GREATER
            CustomPropertyAttribute attr = null;
            object[] attrs = member.GetCustomAttributes(typeof(CustomPropertyAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                attr = attrs[0] as CustomPropertyAttribute;
            }
#endif
            if (attr != null)
            {
                property.PropertyName = attr.SerializeName ?? attr.Name ?? property.PropertyName;
                property.Readable = attr.Serializable;
            }
            return property;
        }
    }
    /// <summary>
    /// 数据协定（Data Contract）反序列化解析器，数据协定是一组字段的抽象说明，其中包含每个字段的名称和数据类型。
    /// 用于JSON反序列化时解析类型的 <see cref="JsonContract"/> 信息
    /// </summary>
    public class ContractDeserializeResolver : DefaultContractResolver
    {
        /// <summary>
        /// 重写 CreateProperty，自定义创建 <see cref="JsonProperty"/>。
        /// </summary>
        /// <param name="member">成员信息</param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
#if NETSTANDARD2_0
            CustomJPropertyAttribute attr = member.GetCustomAttribute(typeof(CustomJPropertyAttribute)) as CustomJPropertyAttribute;
#elif NET40_OR_GREATER
            CustomPropertyAttribute attr = null;
            object[] attrs = member.GetCustomAttributes(typeof(CustomPropertyAttribute), false);
            if(attrs != null && attrs.Length > 0)
            {
                attr = attrs[0] as CustomPropertyAttribute;
            }
#endif
            if (attr != null)
            {
                property.PropertyName = attr.DeserializeName ?? attr.Name ?? property.PropertyName;
                property.Writable = attr.Deserializable;
            }
            return property;
        }
    }
}
