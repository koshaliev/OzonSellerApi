using OzonSellerApi.Enums;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dto.Responses.Warehouses;
public class DeliveryMethodsResponseDto
{
    /// <summary>
    /// Список методов доставки склада
    /// </summary>
    [JsonPropertyName("result")]
    public List<DeliveryMethod> DeliveryMethods { get; set; } = [];

    /// <summary>
    /// Признак, что в запросе вернулась только часть методов доставки:
    /// <para><c>true</c> — сделайте повторный запрос с новым параметром offset для получения остальных методов;</para>
    /// <para><c>false</c> — ответ содержит все методы доставки по запросу.</para>
    /// 
    /// </summary>
    [JsonPropertyName("has_next")]
    public bool HasNext { get; set; }

    /// <summary>
    /// Метод доставки
    /// </summary>
    public class DeliveryMethod
    {
        /// <summary>
        /// Идентификатор метода доставки.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор продавца.
        /// </summary>
        [JsonPropertyName("company_id")]
        public long CompanyId { get; set; }

        /// <summary>
        /// Название метода доставки.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Статус метода доставки
        /// </summary>
        [JsonPropertyName("status")]
        public DeliveryMethodStatus Status { get; set; }

        /// <summary>
        /// Время, до которого продавцу нужно собрать заказ.
        /// </summary>
        [JsonPropertyName("cutoff")]
        public string Cutoff { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор службы доставки.
        /// </summary>
        [JsonPropertyName("provider_id")]
        public long ProviderId { get; set; }

        /// <summary>
        /// Идентификатор услуги по доставке заказа.
        /// </summary>
        [JsonPropertyName("template_id")]
        public long TemplateId { get; set; }

        /// <summary>
        /// Идентификатор склада.
        /// </summary>
        [JsonPropertyName("warehouse_id")]
        public long WarehouseId { get; set; }

        /// <summary>
        /// Дата и время создания метода доставки.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Дата и время последнего обновления метода метода доставки.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Минимальное время на сборку заказа в минутах в соответствии с настройками склада.
        /// </summary>
        [JsonPropertyName("sla_cut_in")]
        public long SlaCutIn { get; set; }
    }
}