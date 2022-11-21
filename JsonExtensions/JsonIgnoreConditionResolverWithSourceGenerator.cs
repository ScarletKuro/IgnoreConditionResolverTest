using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace JsonExtensions;

public class JsonIgnoreConditionResolverWithSourceGenerator : DefaultJsonTypeInfoResolver
{
    private readonly IJsonTypeInfoResolver _source;

    public JsonIgnoreConditionResolverWithSourceGenerator(IJsonTypeInfoResolver source)
    {
        _source = source;
    }

    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        JsonTypeInfo? jti = _source.GetTypeInfo(type, options);

        if (jti is null)
            return null;

        foreach (JsonPropertyInfo jsonPropertyInfo in jti.Properties)
        {
            if (jsonPropertyInfo.AttributeProvider?.GetCustomAttributes(typeof(JsonIgnoreConditionAttribute), inherit: false) is [JsonIgnoreConditionAttribute attr, ..])
            {
                IgnoreCondition ignoreCondition = attr.IgnoreCondition;
                if ((ignoreCondition & IgnoreCondition.WhenWriting) != 0)
                {
                    jsonPropertyInfo.Get = null;
                }

                if ((ignoreCondition & IgnoreCondition.WhenReading) != 0)
                {
                    jsonPropertyInfo.Set = null;
                }
            }
        }

        return jti;
    }
}