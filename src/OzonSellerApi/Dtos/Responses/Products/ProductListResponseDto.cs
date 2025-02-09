using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Products;

// created: 25.01.2025
public class ProductListResponseDto
{
    /// <summary>
    /// Список товаров.
    /// </summary>
    [JsonPropertyName("items")]
    public List<ProductItem> Items { get; set; } = [];

    /// <summary>
    /// Идентификатор последнего значения на странице. 
    /// <para>Чтобы получить следующие значения, передайте полученное значение в следующем запросе в параметре last_id.</para>
    /// </summary>
    [JsonPropertyName("last_id")]
    public string LastId { get; set; } = string.Empty;

    /// <summary>
    /// Всего товаров.
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    public class ProductItem
    {
        /// <summary>
        /// Товар в архиве.
        /// </summary>
        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        /// <summary>
        /// Есть остатки на складах FBO.
        /// </summary>
        [JsonPropertyName("has_fbo_stocks")]
        public bool HasFboStocks { get; set; }

        /// <summary>
        /// Есть остатки на складах FBS.
        /// </summary>
        [JsonPropertyName("has_fbs_stocks")]
        public bool HasFbsStocks { get; set; }

        /// <summary>
        /// Уценённый товар.
        /// </summary>
        [JsonPropertyName("is_discounted")]
        public bool IsDiscounted { get; set; }

        /// <summary>
        /// Идентификатор товара в системе продавца — артикул.
        /// </summary>
        [JsonPropertyName("offer_id")]
        public string OfferId { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }

        /// <summary>
        /// Созданные кванты
        /// </summary>
        [JsonPropertyName("quants")]
        public List<ProductItemQuant> Quants { get; set; } = [];
    }

    public class ProductItemQuant
    {
        /// <summary>
        /// Идентификатор эконом-товара.
        /// </summary>
        [JsonPropertyName("quant_code")]
        public string QuantCode { get; set; } = string.Empty;

        /// <summary>
        /// Размер кванта.
        /// </summary>
        [JsonPropertyName("quant_size")]
        public long QuantSize { get; set; }
    }
}