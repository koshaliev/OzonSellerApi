using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Requests.Stocks;

// created: 29.01.2025
public class V2ProductStocksRequestDto
{
    /// <summary>
    /// Информация о товарах на складах.
    /// </summary>
    [JsonPropertyName("stocks")]
    public List<V2ProductStocksRequestItem> Stocks { get; set; } = [];

    public class V2ProductStocksRequestItem
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
        /// Используйте параметр, если у обычного и эконом-товара совпадает артикул — <c>offer_id = quant_id</c>. Чтобы обновить количество:
        /// <list type="bullet">
        /// <item>обычного товара — передайте значение 1;</item>
        /// <item>эконом-товара — передайте размер его кванта.</item>
        /// </list>
        /// <para>Если у обычного и эконом-товара разные артикулы, не передавайте параметр.</para>
        /// </summary>
        [JsonPropertyName("quant_size")]
        public long QuantSize { get; set; }

        /// <summary>
        /// Количество товара в наличии без учёта зарезервированных товаров.
        /// </summary>
        [JsonPropertyName("stock")]
        public long Stock { get; set; }

        /// <summary>
        /// Идентификатор склада, полученный из метода <see cref="Clients.WarehouseClient.GetWarehouses(CancellationToken)"/> (/v1/warehouse/list).
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public long WarehouseId { get; set; }
    }
}
