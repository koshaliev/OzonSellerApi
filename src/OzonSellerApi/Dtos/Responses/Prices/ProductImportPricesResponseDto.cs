using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Prices;

// created: 29.01.2025
public class ProductImportPricesResponseDto
{
    /// <summary>
    /// Результаты запроса.
    /// </summary>
    [JsonPropertyName("result")]
    public List<ProductImportPricesResponseItem> Result { get; set; } = [];

    public class ProductImportPricesResponseItem
    {
        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Идентификатор товара в системе продавца — артикул.
        /// </summary>
        [JsonPropertyName("offer_id")]
        public string OfferId { get; set; } = string.Empty;

        /// <summary>
        /// Если информации о товаре успешно обновлена — <c>true</c>.
        /// </summary>
        [JsonPropertyName("updated")]
        public bool Updated { get; set; }

        /// <summary>
        /// Массив ошибок, которые возникли при обработке запроса.
        /// </summary>
        [JsonPropertyName("errors")]
        public List<ProductImportPricesResponseItemError> Errors { get; set; } = [];

        public class ProductImportPricesResponseItemError
        {
            /// <summary>
            /// Код ошибки.
            /// </summary>
            [JsonPropertyName("code")]
            public string Code { get; set; } = string.Empty;
            /// <summary>
            /// Причина ошибки.
            /// </summary>
            [JsonPropertyName("message")]
            public string Message { get; set; } = string.Empty;
        }
    }
}
