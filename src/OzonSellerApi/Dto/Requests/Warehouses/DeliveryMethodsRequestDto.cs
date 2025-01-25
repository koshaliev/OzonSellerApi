using OzonSellerApi.Enums;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dto.Requests.Warehouses;
public class DeliveryMethodsRequestDto
{
    /// <summary>
    /// Фильтр для поиска методов доставки.
    /// </summary>
    [JsonPropertyName("filter")]
    public required DeliveryMethodsRequestDtoFilter Filter { get; set; }

    /// <summary>
    /// Количество элементов в ответе. Максимум — 50, минимум — 1.
    /// </summary>
    [JsonPropertyName("limit")]
    public required long Limit { get; set; }

    /// <summary>
    /// Количество элементов, которое будет пропущено в ответе. Например, если offset = 10, то ответ начнётся с 11-го найденного элемента.
    /// </summary>
    [JsonPropertyName("offset")]
    public required long Offset { get; set; }
}

/// <summary>
/// Фильтр для поиска методов доставки.
/// </summary>
public class DeliveryMethodsRequestDtoFilter
{
    /// <summary>
    /// Идентификатор службы доставки.
    /// </summary>
    [JsonPropertyName("provider_id")]
    public long ProviderId { get; set; }

    /// <summary>
    /// Статус метода доставки:
    /// </summary>
    [JsonPropertyName("status")]
    public DeliveryMethodStatus Status { get; set; }

    /// <summary>
    /// Идентификатор склада.
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public long WarehouseId { get; set; }
}