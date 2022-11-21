using JsonExtensions;
using JsonExtensions.Model;
using System.Text.Json;

namespace IgnoreConditionResolverTest;

public class UnitTest1
{
    [Fact]
    public void ResolverWithoutSourceGeneratorOnReading()
    {
        var options = new JsonSerializerOptions { TypeInfoResolver = new JsonIgnoreConditionResolver() };
        JsonTestModel value = new JsonTestModel { History = null! };
        var json = JsonSerializer.Serialize(value, options);
        JsonTestModel? deserializeValue = JsonSerializer.Deserialize<JsonTestModel>(json, options);
        Assert.Equal("{\"History\":null}", json);
        Assert.NotNull(deserializeValue);
        Assert.NotNull(deserializeValue.History);
    }

    [Fact]
    public void ResolverWithSourceGeneratorOnReading()
    {
        var options = new JsonSerializerOptions { TypeInfoResolver = new JsonIgnoreConditionResolverWithSourceGenerator(JsonTestModelSerializerContext.Default) };
        JsonTestModel value = new JsonTestModel { History = null! };
        var json = JsonSerializer.Serialize(value, options);
        JsonTestModel? deserializeValue = JsonSerializer.Deserialize<JsonTestModel>(json, options);
        Assert.Equal("{\"History\":null}", json);
        Assert.NotNull(deserializeValue);
        Assert.NotNull(deserializeValue.History);
    }
}