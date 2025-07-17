using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter<OcrStatus>))]
public enum OcrStatus
{
    READ,
    NOPLATE
}
