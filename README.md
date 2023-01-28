# Berry.Serialization

[![Downloads](https://img.shields.io/nuget/dt/Berry.Serialization.svg)](https://www.nuget.org/packages/Berry.Serialization)

基于 [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) 设计的 JSON 类型 和 .NET 类型转换器。包含一个自定义特性 `CustomJPropertyAttribute` ，用于分别控制属性是否支持序列化与反序列化，以及自定义序列化和反序列化的属性名。

*A JSON types and .NET types converter based on [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) . Include a custom .net attribute `CustomJPropertyAttribute`, used to control whether the property supports serialization and deserialization, and to customize the property name when serializing and deserializing, respectively.*

---

## 程序包（Packages）

Berry.Serialization 的 NuGet 软件包发布在NuGet.org上:

*The release NuGet packages for Berry.Serialization are on NuGet.org:*

| Package             | Download                                                                                                               |
| ------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| Berry.Serialization | [![NuGet](https://img.shields.io/nuget/v/Berry.Serialization.svg)](https://www.nuget.org/packages/Berry.Serialization) |

---

## 示例（Example）

#### .NET Class

```c#
public class Person
{
    // 添加自定义特性
    // add custom attribute
    [CustomJProperty(DeserializeName = "姓名", SerializeName = "NAME")]
    public string Name { get; set; }

    [CustomJProperty(DeserializeName = "年龄", SerializeName = "AGE")]
    public int Age { get; set; }
}
```

#### 使用(Usage)

```c#
string json = "{\"姓名\": \"张伟\",\"年龄\": 20}";
Person person = CustomJConvert.DeserializeObject<Person>(json);
Console.WriteLine(CustomJConvert.SerializeObject(person));
// output
{"NAME":"张伟","AGE":20}
```
