using OzonSellerApi.Enums;
using OzonSellerApi.Utils;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Requests.Stocks;

// created: 29.01.2025
public class V4ProductInfoStocksRequestDto
{
    /// <summary>
    /// Указатель для выборки следующих данных.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>
    /// Фильтр по товарам.
    /// </summary>
    [JsonPropertyName("filter")]
    public required V4ProductInfoStocksRequestDtoFilter Filter { get; set; }

    /// <summary>
    /// Количество значений на странице. Минимум — 1, максимум — 1000.
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 1;
}

/// <summary>
/// Фильтр по товарам.
/// </summary>
public class V4ProductInfoStocksRequestDtoFilter
{
    /// <summary>
    /// Фильтр по параметру <c>OfferId</c> (<c>offer_id</c>). Можно передавать список значений.
    /// </summary>
    [JsonPropertyName("offer_id")]
    public List<string> OfferId { get; set; } = [];

    /// <summary>
    /// Фильтр по параметру <c>ProductId</c> (<c>product_id</c>). Можно передавать список значений.
    /// </summary>
    [JsonPropertyName("product_id")]
    // [JsonConverter(typeof(LongToStringArrayJsonConverter))]
    public List<long> ProductId { get; set; } = [];
    /// <summary>
    /// Фильтр по видимости товара.
    /// </summary>
    [JsonPropertyName("visibility")]
    public ProductVisibility Visibility { get; set; } = ProductVisibility.All;

    /// <summary>
    /// Товары по тарифу «Эконом».
    /// </summary>
    [JsonPropertyName("with_quant")]
    public required ProductInfoStocksRequestDtoQuantFilter WithQuant { get; set; }


    /// <summary>
    /// Фильтр для выборки товаров по тарифу «Эконом».
    /// </summary>
    public class ProductInfoStocksRequestDtoQuantFilter
    {
        /// <summary>
        /// Активные эконом-товары.
        /// </summary>
        [JsonPropertyName("created")]
        public bool Created { get; set; }

        /// <summary>
        /// Эконом-товары во всех статусах.
        /// </summary>
        [JsonPropertyName("exists")]
        public bool Exists { get; set; }
    }
}