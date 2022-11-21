using JsonExtensions.Model;
using System.Text.Json.Serialization;

namespace JsonExtensions;

[JsonSerializable(typeof(JsonTestModel))]
public partial class JsonTestModelSerializerContext : JsonSerializerContext
{

}