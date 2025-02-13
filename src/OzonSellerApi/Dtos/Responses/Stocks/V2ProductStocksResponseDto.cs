using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Stocks;
public class V2ProductStocksResponseDto
{
    [JsonPropertyName("result")]
    public List<ProductStocksResponseItem> Result { get; set; } = [];

    public class ProductStocksResponseItem
    {
        /// <summary>
        /// Идентификатор склада.
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public long WarehouseId { get; set; }

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }

        /// <summary>
        /// Показывает, количество товара какого типа вы обновляете:
        /// <list type="bullet">
        /// <item><c>1</c> — если обновляете остатки обычного товара;</item>
        /// <item>размер кванта — если обновляете остатки эконом-товара.</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("quant_size")]
        public long QuantSize { get; set; }

        /// <summary>
        /// Идентификатор товара в системе продавца — артикул.
        /// </summary>
        [JsonPropertyName("offer_id")]
        public string OfferId { get; set; } = string.Empty;

        /// <summary>
        /// Если запрос выполнен успешно и остатки обновлены — true.
        /// </summary>
        [JsonPropertyName("updated")]
        public bool Updated { get; set; }

        /// <summary>
        /// Массив ошибок, которые возникли при обработке запроса.
        /// </summary>
        [JsonPropertyName("errors")]
        public List<ProductStocksResponseItemError> Errors { get; set; } = [];

        public class ProductStocksResponseItemError
        {
            [JsonPropertyName("code")]
            public string Code { get; set; } = string.Empty;
            [JsonPropertyName("message")]
            public string Message { get; set; } = string.Empty;
        }
    }
}
