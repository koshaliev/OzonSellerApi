using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Requests.Products;

// created: 26.01.2025
public class V3ProductInfoListRequestDto
{
    /// <summary>
    /// Идентификатор товара в системе продавца — артикул.
    /// </summary>
    [JsonPropertyName("offer_id")]
    public List<string> OfferId { get; set; } = [];

    /// <summary>
    /// Идентификатор товара.
    /// </summary>
    [JsonPropertyName("product_id")]
    // [JsonConverter(typeof(LongToStringArrayJsonConverter))]
    public List<long> ProductId { get; set; } = [];

    /// <summary>
    /// Идентификатор товара в системе Ozon — SKU.
    /// </summary>
    [JsonPropertyName("sku")]
    // [JsonConverter(typeof(LongToStringArrayJsonConverter))]
    public List<long> Sku { get; set; } = [];
}