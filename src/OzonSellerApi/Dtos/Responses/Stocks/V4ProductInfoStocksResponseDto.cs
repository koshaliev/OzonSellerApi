using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Stocks;

// created: 29.01.2025
public class V4ProductInfoStocksResponseDto
{
    /// <summary>
    /// Указатель для выборки следующих данны
    /// </summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>
    /// Информация о товарах.
    /// </summary>
    [JsonPropertyName("items")]
    public List<ProductInfoStocksItem> Items { get; set; } = [];

    /// <summary>
    /// Количество уникальных товаров, для которых выводится информация об остатках.
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// Информация о товаре.
    /// </summary>
    public class ProductInfoStocksItem
    {
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
        /// Информация об остатках.
        /// </summary>
        [JsonPropertyName("stocks")]
        public List<StockInfo> Stocks { get; set; } = [];

        /// <summary>
        /// Информация об остатке.
        /// </summary>
        public class StockInfo
        {
            /// <summary>
            /// Сейчас на складе.
            /// </summary>
            [JsonPropertyName("present")]
            public int Present { get; set; }

            /// <summary>
            /// Зарезервировано.
            /// </summary>
            [JsonPropertyName("reserved")]
            public int Reserved { get; set; }

            // TODO: NotImportant - сделать ENUM для этого поля?
            /// <summary>
            /// Тип упаковки:
            /// <list type="bullet">
            /// <item>SHIPMENT_TYPE_GENERAL — обычный товар;</item>
            /// <item>SHIPMENT_TYPE_BOX — коробка;</item>
            /// <item>SHIPMENT_TYPE_PALLET — палета.</item>
            /// </list>
            /// </summary>
            [JsonPropertyName("shipment_type")]
            public string ShipmentType { get; set; } = "SHIPMENT_TYPE_GENERAL";

            /// <summary>
            /// Идентификатор товара в системе Ozon — SKU.
            /// </summary>
            [JsonPropertyName("sku")]
            public long Sku { get; set; }

            /// <summary>
            /// Тип склада.
            /// </summary>
            [JsonPropertyName("type")]
            public string Type { get; set; } = string.Empty;
        }
    }
}
