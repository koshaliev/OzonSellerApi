using System.Text.Json.Serialization;

namespace OzonSellerApi.Enums;
/// <summary>
/// Возможные статусы склада.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<WarehouseStatus>))]
public enum WarehouseStatus
{
    /// <summary>
    /// Активируется.
    /// </summary>
    [JsonStringEnumMemberName("new")]
    New,

    /// <summary>
    /// Активный.
    /// </summary
    [JsonStringEnumMemberName("created")]
    Created,

    /// <summary>
    /// В архиве.
    /// </summary
    [JsonStringEnumMemberName("disabled")]
    Disabled,

    /// <summary>
    /// Заблокирован.
    /// </summary
    [JsonStringEnumMemberName("blocked")]
    Blocked,

    /// <summary>
    /// На паузе.
    /// </summary
    [JsonStringEnumMemberName("disabled_due_to_limit")]
    DisabledDueToLimit,

    /// <summary>
    /// Ошибка.
    /// </summary
    [JsonStringEnumMemberName("error")]
    Error
}