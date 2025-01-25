using System.Text.Json.Serialization;

namespace OzonSellerApi.Enums;
/// <summary>
/// Рабочие дни склада. При сериализации будут представлены как числа от 1 до 7.
/// </summary>
public enum WarehouseWorkingDay
{
    [JsonPropertyName("1")]
    Monday,
    [JsonPropertyName("2")]
    Tuesday,
    [JsonPropertyName("3")]
    Wednesday,
    [JsonPropertyName("4")]
    Thursday,
    [JsonPropertyName("5")]
    Friday,
    [JsonPropertyName("6")]
    Saturday,
    [JsonPropertyName("7")]
    Sunday
}
