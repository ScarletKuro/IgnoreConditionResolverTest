namespace JsonExtensions.Model;

public class JsonTestModel
{
    [JsonIgnoreCondition(IgnoreCondition.WhenReading)]
    public List<string> History { get; set; } = new();
}