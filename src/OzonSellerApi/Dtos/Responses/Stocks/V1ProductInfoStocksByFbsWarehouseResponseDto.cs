using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Stocks;

// created: 29.01.2025
public class V1ProductInfoStocksByFbsWarehouseResponseDto
{
    /// <summary>
    /// Результат работы метода.
    /// </summary>
    [JsonPropertyName("result")]
    public List<ProductInfoStocksByFbsWarehouseItem> Result { get; set; } = [];

    public class ProductInfoStocksByFbsWarehouseItem
    {
        /// <summary>
        /// SKU товара.
        /// </summary>
        [JsonPropertyName("sku")]
        public int Sku { get; set; }

        /// <summary>
        /// Общее количество товара на складе.
        /// </summary>
        [JsonPropertyName("present")]
        public int Present { get; set; }

        /// <summary>
        /// Идентификатор товара в системе продавца.
        /// </summary>
        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Количество зарезервированных товаров на складе.
        /// </summary>
        [JsonPropertyName("reserved")]
        public int Reserved { get; set; }

        /// <summary>
        /// Идентификатор склада.
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public int WarehouseId { get; set; }

        /// <summary>
        /// Название склада.
        /// </summary>
        [JsonPropertyName("warehouse_name")]
        public string WarehouseName { get; set; } = string.Empty;
    }
}