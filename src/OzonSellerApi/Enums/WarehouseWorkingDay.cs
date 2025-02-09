using System.Text.Json.Serialization;

namespace OzonSellerApi.Enums;
/// <summary>
/// Рабочие дни склада. При сериализации будут представлены как числа от 1 до 7.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<WarehouseWorkingDay>))]
public enum WarehouseWorkingDay
{
    [JsonStringEnumMemberName("1")]
    Monday,
    [JsonStringEnumMemberName("2")]
    Tuesday,
    [JsonStringEnumMemberName("3")]
    Wednesday,
    [JsonStringEnumMemberName("4")]
    Thursday,
    [JsonStringEnumMemberName("5")]
    Friday,
    [JsonStringEnumMemberName("6")]
    Saturday,
    [JsonStringEnumMemberName("7")]
    Sunday
}