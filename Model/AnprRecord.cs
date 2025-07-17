#nullable enable

using System.Text.Json.Serialization;

/// <summary>
/// ANPR Record. (duplicate model in mock service could be refactored to a shared library)
/// </summary>
public class AnprRecord
{
    /// <summary>
    /// camera number - fixed configured value.
    /// </summary>
    [JsonRequired]
    public long CameraNumber { get; set; }

    /// <summary>
    /// site adress of the camera - a fixed configured value for the fixed camera sites.
    /// </summary>
    [JsonRequired]
    public string? SiteAddress { get; set; }

    /// <summary>
    /// geo-coordinates of the camera site in WGS-84 format - a fixed configured value for the fixed camera sites.
    /// </summary>
    [JsonRequired]
    public GeoPos? Position { get; set; }

    /// <summary>
    /// uniqueness must be valid for at least 30 days.
    /// </summary>
    [JsonRequired]
    public string? TriggerId { get; set; }

    /// <summary>
    /// two-digit ISO country code.
    /// </summary>
    [JsonRequired]
    public string? Country { get; set; }

    /// <summary>
    /// recognised licence plate alphanumeric.
    /// </summary>
    [JsonRequired]
    public string? Plate { get; set; }

    /// <summary>
    /// base64 encoded image section with the recognised licence plate.
    /// </summary>
    /// <remarks>
    /// This string should be base64-encoded.
    /// </remarks>
    [JsonRequired]
    public string? PlateImage { get; set; }

    /// <summary>
    /// base64 encoded overview image with the vehicle of the recognised licence plate.
    /// </summary>
    /// <remarks>
    /// This string should be base64-encoded.
    /// </remarks>
    [JsonRequired]
    public string? OverviewImage { get; set; }

    /// <summary>
    /// recognised dangerous goods plate alphanumeric.
    /// </summary>
    public string? Adr { get; set; }

    /// <summary>
    /// confidence value of the OCR process for the number plate recognition. The value is related to the attribute cameraTypeVersion.
    /// </summary>
    [JsonRequired]
    public long OcrScore { get; set; }

    /// <summary>
    /// status of the results of the OCR process for licence plate recognition.
    /// </summary>
    [JsonRequired]
    public OcrStatus OcrStatus { get; set; }

    /// <summary>
    /// camera type and version.
    /// </summary>
    [JsonRequired]
    public string? CameraTypeVersion { get; set; } // TODO Laut openapi string, laut example aber enum..

    /// <summary>
    /// timestamp of the vehicle passage detection in ISO-8601 format.
    /// </summary>
    [JsonRequired]
    public string? Timestamp { get; set; }

    /// <summary>
    /// driving direction of the detected vehicle in relation to the camera orientation.
    /// </summary>
    [JsonRequired]
    public Direction Direction { get; set; }

    /// <summary>
    /// indicaties the lane of the detected vehicle passage - a fixed configured value for the fixed camera sites.
    /// </summary>
    [JsonRequired]
    public string? LaneDescr { get; set; }

    /// <summary>
    /// recognised vehicle make.
    /// </summary>
    public string? Make { get; set; }

    /// <summary>
    /// recognised type of the vehicle make.
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// recognised vehicle class.
    /// </summary>
    public VehicleType Type { get; set; }

    /// <summary>
    /// recognised vehicle colour.
    /// </summary>
    public string? Color { get; set; }

    public string? PassageId { get; set; }
    public string NotNullableString { get; set; }
}
