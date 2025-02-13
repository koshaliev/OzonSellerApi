using OzonSellerApi.Enums;
using OzonSellerApi.Utils;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Requests.Products;

// created: 25.01.2025
public class V3ProductListRequestDto
{
    /// <summary>
    /// Фильтр по товарам.
    /// </summary>
    [JsonPropertyName("filter")]
    public required V3ProductListRequestDtoFilter Filter { get; set; }

    /// <summary>
    /// Идентификатор последнего значения на странице. При первом запросе оставьте это поле пустым.
    /// <para>Чтобы получить следующие значения, укажите <c>last_id</c> из ответа предыдущего запроса.</para>
    /// </summary>
    [JsonPropertyName("last_id")]
    public string LastId { get; set; } = string.Empty;

    /// <summary>
    /// Количество значений на странице. Минимум — 1, максимум — 1000.
    /// </summary>
    [JsonPropertyName("limit")]
    public long Limit { get; set; } = 1;
}

public class V3ProductListRequestDtoFilter
{
    /// <summary>
    /// Фильтр по параметру <c>offer_id</c>. Вы можете передавать список значений.
    /// </summary>
    [JsonPropertyName("offer_id")]
    public List<string> OfferId { get; set; } = [];

    /// <summary>
    /// Фильтр по параметру <c>product_id</c>. Вы можете передавать список значений.
    /// </summary>
    [JsonPropertyName("product_id")]
    // [JsonConverter(typeof(LongToStringArrayJsonConverter))]
    public List<long> ProductId { get; set; } = [];

    /// <summary>
    /// Фильтр по видимости товара.
    /// </summary>
    [JsonPropertyName("visibility")]
    public ProductVisibility Visibility { get; set; } = ProductVisibility.All;
}