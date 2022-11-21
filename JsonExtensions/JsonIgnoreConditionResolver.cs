using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace JsonExtensions;

public class JsonIgnoreConditionResolver : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        JsonTypeInfo jti = base.GetTypeInfo(type, options);

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