using System.Text.Json.Serialization;

namespace OzonSellerApi.Enums;

/// <summary>
/// Статусы метода доставки
/// </summary>
public enum DeliveryMethodStatus
{
    /// <summary>
    /// Создан.
    /// </summary>
    [JsonPropertyName("NEW")]
    New,

    /// <summary>
    /// Редактируется.
    /// </summary>
    [JsonPropertyName("EDITED")]
    Edited,

    /// <summary>
    /// Активный.
    /// </summary>
    [JsonPropertyName("ACTIVE")]
    Active,

    /// <summary>
    /// Неактивный.
    /// </summary>
    [JsonPropertyName("DISABLED")]
    Disabled,

    /// <summary>
    /// Отсутствие (для фильтра в запросе).
    /// </summary>
    [JsonPropertyName("")]
    None
}