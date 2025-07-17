#nullable enable

using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class EnumHelper
{
    /// <summary>
    /// Gets an attribute on an enum field value
    /// </summary>
    /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
    /// <param name="enumVal">The enum value</param>
    /// <returns>The attribute of type T that exists on the enum value</returns>
    /// <example><![CDATA[string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;]]></example>
    public static T? GetAttributeOfType<T>(this System.Enum enumVal) where T : System.Attribute
    {
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        return (attributes.Length > 0) ? (T)attributes[0] : null;
    }
}

public class VehicleTypeConverter : JsonConverter<VehicleType>
{
    public override VehicleType Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
    {
        /* Easy way: just replace '-' and ' ' with '_'
        var item = reader.GetString()?.Replace('-','_').Replace(' ', '_'); */
        var item = reader.GetString();
        if (Enum.TryParse<VehicleType>(item, out var vehicleType))
            return vehicleType;
        // better: also search for name in EnumMemberAttributes instead of replacing strings.
        var values = Enum.GetValues(typeToConvert).Cast<VehicleType>();
        foreach (var value in values)
        {
            var enumMemberName = value.GetAttributeOfType<EnumMemberAttribute>();
            if (item == enumMemberName?.Value)
                return value;
        }
        throw new JsonException($"Unable to parse {item}");
    }

    public override void Write(Utf8JsonWriter writer, VehicleType value, JsonSerializerOptions options)
    {
        var othername = value.GetAttributeOfType<EnumMemberAttribute>();
        var itemvalue = othername != null ? othername.Value : value.ToString();
        writer.WriteStringValue(itemvalue);
    }
}

[JsonConverter(typeof(VehicleTypeConverter))]
public enum VehicleType
{
    CAR,
    [EnumMember(Value = "CAR WITH TRAILER")]
    CAR_WITH_TRAILER,
    LORRY,
    [EnumMember(Value = "LORRY WITH TRAILER")]
    LORRY_WITH_TRAILER,
    BUS,
    [EnumMember(Value = "MOTORCYCLE-MOTORBYKE")]
    MOTORCYCLE_MOTORBYKE,
    MOTORCYCLE,
    MOTORBYKE,
    VAN,
    [EnumMember(Value = "HEAVY TRUCK")]
    HEAVY_TRUCK,
    [EnumMember(Value = "LIGHT TRUCK")]
    LIGHT_TRUCK,
    OTHERS,
    UNKNOWN
}
