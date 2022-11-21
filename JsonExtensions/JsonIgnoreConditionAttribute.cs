namespace JsonExtensions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class JsonIgnoreConditionAttribute : Attribute
{
    public IgnoreCondition IgnoreCondition { get; }

    public JsonIgnoreConditionAttribute(IgnoreCondition ignoreCondition) => IgnoreCondition = ignoreCondition;
}