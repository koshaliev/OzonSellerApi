using OzonSellerApi.Enums;
using OzonSellerApi.Utils;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Requests.Warehouses;
public class V1DeliveryMethodsRequestDto
{
    /// <summary>
    /// Фильтр для поиска методов доставки.
    /// </summary>
    [JsonPropertyName("filter")]
    public required V1DeliveryMethodsRequestDtoFilter Filter { get; set; }

    /// <summary>
    /// Количество элементов в ответе. Максимум — 50, минимум — 1.
    /// </summary>
    [JsonPropertyName("limit")]
    public required long Limit { get; set; } = 1;

    /// <summary>
    /// Количество элементов, которое будет пропущено в ответе. Например, если offset = 10, то ответ начнётся с 11-го найденного элемента.
    /// </summary>
    [JsonPropertyName("offset")]
    public long Offset { get; set; }
}

/// <summary>
/// Фильтр для поиска методов доставки.
/// </summary>
public class V1DeliveryMethodsRequestDtoFilter
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
    [JsonConverter(typeof(DeliveryMethodStatusJsonConverter))]
    public DeliveryMethodStatus Status { get; set; } = DeliveryMethodStatus.None;

    /// <summary>
    /// Идентификатор склада, полученный из метода <see cref="Clients.WarehouseClient.GetWarehouses(CancellationToken)"/>.
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public long WarehouseId { get; set; }
}