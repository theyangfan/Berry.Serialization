using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Berry.Serialization
{
    /// <summary>
    /// The serialize resolver.
    /// </summary>
    internal class ContractSerializeResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
#if NETSTANDARD2_0
            CustomJPropertyAttribute attr = member.GetCustomAttribute(typeof(CustomJPropertyAttribute)) as CustomJPropertyAttribute;
#elif NET40_OR_GREATER
            CustomJPropertyAttribute attr = null;
            object[] attrs = member.GetCustomAttributes(typeof(CustomJPropertyAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                attr = attrs[0] as CustomJPropertyAttribute;
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
    /// The deserialize resolver.
    /// </summary>
    internal class ContractDeserializeResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
#if NETSTANDARD2_0
            CustomJPropertyAttribute attr = member.GetCustomAttribute(typeof(CustomJPropertyAttribute)) as CustomJPropertyAttribute;
#elif NET40_OR_GREATER
            CustomJPropertyAttribute attr = null;
            object[] attrs = member.GetCustomAttributes(typeof(CustomJPropertyAttribute), false);
            if(attrs != null && attrs.Length > 0)
            {
                attr = attrs[0] as CustomJPropertyAttribute;
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
