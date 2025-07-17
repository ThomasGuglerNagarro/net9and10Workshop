using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter<Direction>))]
public enum Direction
{
    APPROACH,
    RECEADING,
}
