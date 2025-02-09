using System.Text.Json.Serialization;

namespace OzonSellerApi.Enums;
/// <summary>
/// Тип первой мили.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<WarehouseFirstMileType>))]
public enum WarehouseFirstMileType
{
    [JsonStringEnumMemberName("DropOff")]
    DropOff,
    [JsonStringEnumMemberName("Pickup")]
    Pickup
}