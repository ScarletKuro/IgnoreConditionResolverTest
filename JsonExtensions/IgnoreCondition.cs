namespace JsonExtensions;

[Flags]
public enum IgnoreCondition
{
    WhenWriting = 1,
    WhenReading = 2
}