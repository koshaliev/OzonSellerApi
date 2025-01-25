using System.Text.Json.Serialization;

namespace OzonSellerApi.Enums;
/// <summary>
/// Тип первой мили.
/// </summary>
public enum WarehouseFirstMileType
{
    [JsonPropertyName("DropOff")]
    DropOff,
    [JsonPropertyName("Pickup")]
    Pickup
}