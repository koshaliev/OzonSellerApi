using OzonSellerApi.Enums;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Postings;
public class PostingFbsUnfulfilledListResponseDto
{
    [JsonPropertyName("result")]
    public PostingFbsUnfulfilledListResponseResult? Result { get; set; }
}

public class PostingFbsUnfulfilledListResponseResult
{
    /// <summary>
    /// Счётчик элементов в ответе.
    /// </summary>
    [JsonPropertyName("count")]
    public long Count { get; set; }

    /// <summary>
    /// Список отправлений и подробная информация по каждому.
    /// </summary>
    [JsonPropertyName("postings")]
    public List<Posting> Postings { get; set; }
}

public class Posting
{
    [JsonPropertyName("posting_number")]
    public string PostingNumber { get; set; }

    [JsonPropertyName("order_id")]
    public object OrderId { get; set; }

    [JsonPropertyName("order_number")]
    public string OrderNumber { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    /// <summary>
    /// Метод доставки.
    /// </summary>
    [JsonPropertyName("delivery_method")]
    public PostingDeliveryMethod DeliveryMethod { get; set; }

    [JsonPropertyName("tracking_number")]
    public string TrackingNumber { get; set; }

    [JsonPropertyName("tpl_integration_type")]
    public string TplIntegrationType { get; set; }

    [JsonPropertyName("in_process_at")]
    public DateTime InProcessAt { get; set; }

    [JsonPropertyName("shipment_date")]
    public DateTime ShipmentDate { get; set; }

    /// <summary>
    /// Дата передачи отправления в доставку.
    /// </summary>
    [JsonPropertyName("delivering_date")]
    public object? DeliveringDate { get; set; }

    /// <summary>
    /// Информация об отмене.
    /// </summary>
    [JsonPropertyName("cancellation")]
    public PostingCancellationInfo Cancellation { get; set; }

    /// <summary>
    /// Данные о покупателе.
    /// </summary>
    [JsonIgnore]
    [JsonPropertyName("customer")]
    public object? Customer { get; set; }

    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }

    /// <summary>
    /// Контактные данные получателя.
    /// </summary>
    [JsonIgnore]
    [JsonPropertyName("addressee")]
    public object? Addressee { get; set; }

    /// <summary>
    /// Штрихкоды отправления.
    /// </summary>
    [JsonPropertyName("barcodes")]
    public PostingBarcodes Barcodes { get; set; }

    /// <summary>
    /// Данные аналитики.
    /// </summary>
    [JsonPropertyName("analytics_data")]
    public AnalyticsData AnalyticsData { get; set; }

    [JsonPropertyName("financial_data")]
    public FinancialData FinancialData { get; set; }

    [JsonPropertyName("is_express")]
    public bool IsExpress { get; set; }

    [JsonPropertyName("requirements")]
    public Requirements Requirements { get; set; }

    [JsonPropertyName("parent_posting_number")]
    public string ParentPostingNumber { get; set; }

    /// <summary>
    /// Доступные действия и информация об отправлении:
    /// </summary>
    [JsonPropertyName("available_actions")]
    public List<FbsPostingAvailableAction> AvailableActions { get; set; } = [];

    [JsonPropertyName("multi_box_qty")]
    public int MultiBoxQty { get; set; }

    [JsonPropertyName("is_multibox")]
    public bool IsMultibox { get; set; }

    [JsonPropertyName("substatus")]
    public string Substatus { get; set; }

    [JsonPropertyName("prr_option")]
    public string PrrOption { get; set; }

    [JsonPropertyName("quantum_id")]
    public int QuantumId { get; set; }

    [JsonPropertyName("tariffication")]
    public Tariffication Tariffication { get; set; }

    [JsonPropertyName("destination_place_id")]
    public string DestinationPlaceId { get; set; }

    [JsonPropertyName("destination_place_name")]
    public string DestinationPlaceName { get; set; }

    [JsonPropertyName("is_presortable")]
    public bool IsPresortable { get; set; }

    [JsonPropertyName("pickup_code_verified_at")]
    public object PickupCodeVerifiedAt { get; set; }


    /// <summary>
    /// Штрихкоды отправления.
    /// </summary>
    public class PostingBarcodes
    {
        /// <summary>
        /// Верхний штрихкод на маркировке отправления.
        /// </summary>
        [JsonPropertyName("upper_barcode")]
        public string UpperBarcode { get; set; }

        /// <summary>
        /// Нижний штрихкод на маркировке отправления.
        /// </summary>
        [JsonPropertyName("lower_barcode")]
        public string LowerBarcode { get; set; }
    }

    /// <summary>
    /// Информация об отмене.
    /// </summary>
    public class PostingCancellationInfo
    {
        /// <summary>
        /// Идентификатор причины отмены отправления.
        /// </summary>
        [JsonPropertyName("cancel_reason_id")]
        public long CancelReasonId { get; set; }

        /// <summary>
        /// Причина отмены.
        /// </summary>
        [JsonPropertyName("cancel_reason")]
        public string CancelReason { get; set; } = string.Empty;

        /// <summary>
        /// Тип отмены отправления:
        /// <list type="bullet">
        /// <item><description><c>seller</c> — отменено продавцом.</description></item>
        /// <item><description><c>client</c> или <c>customer</c> — отменено покупателем.</description></item>
        /// <item><description><c>ozon</c> — отменено Ozon.</description></item>
        /// <item><description><c>system</c> — отменено системой.</description></item>
        /// <item><description><c>delivery</c> — отменено службой доставки.</description></item>
        /// </list>
        /// </summary>
        [JsonPropertyName("cancellation_type")]
        public string CancellationType { get; set; } = string.Empty;

        /// <summary>
        /// Если отмена произошла после сборки отправления — <c>true</c>.
        /// </summary>
        [JsonPropertyName("cancelled_after_ship")]
        public bool CancelledAfterShip { get; set; }

        /// <summary>
        /// Если отмена влияет на рейтинг продавца — true.
        /// </summary>
        [JsonPropertyName("affect_cancellation_rating")]
        public bool AffectCancellationRating { get; set; }

        /// <summary>
        /// Инициатор отмены:
        /// <list type="bullet">
        /// <item><description>Продавец</description></item>
        /// <item><description>Клиент или покупатель</description></item>
        /// <item><description>Ozon</description></item>
        /// <item><description>Система</description></item>
        /// <item><description>Служба доставки</description></item>
        /// </list>
        [JsonPropertyName("cancellation_initiator")]
        public string CancellationInitiator { get; set; } = string.Empty;
    }
}



// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class AnalyticsData
{
    [JsonPropertyName("region")]
    public string Region { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("delivery_type")]
    public string DeliveryType { get; set; }

    [JsonPropertyName("is_premium")]
    public bool IsPremium { get; set; }

    [JsonPropertyName("payment_type_group_name")]
    public string PaymentTypeGroupName { get; set; }

    [JsonPropertyName("warehouse_id")]
    public string WarehouseId { get; set; }

    [JsonPropertyName("warehouse")]
    public string Warehouse { get; set; }

    [JsonPropertyName("tpl_provider_id")]
    public int TplProviderId { get; set; }

    [JsonPropertyName("tpl_provider")]
    public string TplProvider { get; set; }

    [JsonPropertyName("delivery_date_begin")]
    public DateTime DeliveryDateBegin { get; set; }

    [JsonPropertyName("delivery_date_end")]
    public DateTime DeliveryDateEnd { get; set; }

    [JsonPropertyName("is_legal")]
    public bool IsLegal { get; set; }
}

public class PostingDeliveryMethod
{
    /// <summary>
    /// Идентификатор способа доставки.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Название способа доставки.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор склада.
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public string WarehouseId { get; set; } = string.Empty;

    /// <summary>
    /// Название склада.
    /// </summary>
    [JsonPropertyName("warehouse")]
    public string Warehouse { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор службы доставки.
    /// </summary>
    [JsonPropertyName("tpl_provider_id")]
    public long TplProviderId { get; set; }

    /// <summary>
    /// Служба доставки.
    /// </summary>
    [JsonPropertyName("tpl_provider")]
    public string TplProvider { get; set; }
}

public class FinancialData
{
    [JsonPropertyName("products")]
    public List<Product> Products { get; set; }

    [JsonPropertyName("posting_services")]
    public PostingServices PostingServices { get; set; }

    [JsonPropertyName("cluster_from")]
    public string ClusterFrom { get; set; }

    [JsonPropertyName("cluster_to")]
    public string ClusterTo { get; set; }
}

public class ItemServices
{
    [JsonPropertyName("marketplace_service_item_fulfillment")]
    public int MarketplaceServiceItemFulfillment { get; set; }

    [JsonPropertyName("marketplace_service_item_pickup")]
    public int MarketplaceServiceItemPickup { get; set; }

    [JsonPropertyName("marketplace_service_item_dropoff_pvz")]
    public int MarketplaceServiceItemDropoffPvz { get; set; }

    [JsonPropertyName("marketplace_service_item_dropoff_sc")]
    public int MarketplaceServiceItemDropoffSc { get; set; }

    [JsonPropertyName("marketplace_service_item_dropoff_ff")]
    public int MarketplaceServiceItemDropoffFf { get; set; }

    [JsonPropertyName("marketplace_service_item_direct_flow_trans")]
    public int MarketplaceServiceItemDirectFlowTrans { get; set; }

    [JsonPropertyName("marketplace_service_item_return_flow_trans")]
    public int MarketplaceServiceItemReturnFlowTrans { get; set; }

    [JsonPropertyName("marketplace_service_item_deliv_to_customer")]
    public int MarketplaceServiceItemDelivToCustomer { get; set; }

    [JsonPropertyName("marketplace_service_item_return_not_deliv_to_customer")]
    public int MarketplaceServiceItemReturnNotDelivToCustomer { get; set; }

    [JsonPropertyName("marketplace_service_item_return_part_goods_customer")]
    public int MarketplaceServiceItemReturnPartGoodsCustomer { get; set; }

    [JsonPropertyName("marketplace_service_item_return_after_deliv_to_customer")]
    public int MarketplaceServiceItemReturnAfterDelivToCustomer { get; set; }
}

public class PostingServices
{
    [JsonPropertyName("marketplace_service_item_fulfillment")]
    public int MarketplaceServiceItemFulfillment { get; set; }

    [JsonPropertyName("marketplace_service_item_pickup")]
    public int MarketplaceServiceItemPickup { get; set; }

    [JsonPropertyName("marketplace_service_item_dropoff_pvz")]
    public int MarketplaceServiceItemDropoffPvz { get; set; }

    [JsonPropertyName("marketplace_service_item_dropoff_sc")]
    public int MarketplaceServiceItemDropoffSc { get; set; }

    [JsonPropertyName("marketplace_service_item_dropoff_ff")]
    public int MarketplaceServiceItemDropoffFf { get; set; }

    [JsonPropertyName("marketplace_service_item_direct_flow_trans")]
    public int MarketplaceServiceItemDirectFlowTrans { get; set; }

    [JsonPropertyName("marketplace_service_item_return_flow_trans")]
    public int MarketplaceServiceItemReturnFlowTrans { get; set; }

    [JsonPropertyName("marketplace_service_item_deliv_to_customer")]
    public int MarketplaceServiceItemDelivToCustomer { get; set; }

    [JsonPropertyName("marketplace_service_item_return_not_deliv_to_customer")]
    public int MarketplaceServiceItemReturnNotDelivToCustomer { get; set; }

    [JsonPropertyName("marketplace_service_item_return_part_goods_customer")]
    public int MarketplaceServiceItemReturnPartGoodsCustomer { get; set; }

    [JsonPropertyName("marketplace_service_item_return_after_deliv_to_customer")]
    public int MarketplaceServiceItemReturnAfterDelivToCustomer { get; set; }
}

public class Product
{
    [JsonPropertyName("price")]
    public string Price { get; set; }

    [JsonPropertyName("offer_id")]
    public string OfferId { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("sku")]
    public int Sku { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("mandatory_mark")]
    public List<object> MandatoryMark { get; set; }

    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; set; }

    [JsonPropertyName("commission_amount")]
    public int CommissionAmount { get; set; }

    [JsonPropertyName("commission_percent")]
    public int CommissionPercent { get; set; }

    [JsonPropertyName("payout")]
    public int Payout { get; set; }

    [JsonPropertyName("product_id")]
    public int ProductId { get; set; }

    [JsonPropertyName("old_price")]
    public int OldPrice { get; set; }

    [JsonPropertyName("total_discount_value")]
    public int TotalDiscountValue { get; set; }

    [JsonPropertyName("total_discount_percent")]
    public double TotalDiscountPercent { get; set; }

    [JsonPropertyName("actions")]
    public List<string> Actions { get; set; }

    [JsonPropertyName("picking")]
    public object Picking { get; set; }

    [JsonPropertyName("client_price")]
    public string ClientPrice { get; set; }

    [JsonPropertyName("item_services")]
    public ItemServices ItemServices { get; set; }
}

public class Requirements
{
    [JsonPropertyName("products_requiring_gtd")]
    public List<object> ProductsRequiringGtd { get; set; }

    [JsonPropertyName("products_requiring_country")]
    public List<object> ProductsRequiringCountry { get; set; }

    [JsonPropertyName("products_requiring_mandatory_mark")]
    public List<object> ProductsRequiringMandatoryMark { get; set; }

    [JsonPropertyName("products_requiring_rnpt")]
    public List<object> ProductsRequiringRnpt { get; set; }

    [JsonPropertyName("products_requiring_jw_uin")]
    public List<object> ProductsRequiringJwUin { get; set; }
}

public class Tariffication
{
    [JsonPropertyName("current_tariff_rate")]
    public int CurrentTariffRate { get; set; }

    [JsonPropertyName("current_tariff_type")]
    public string CurrentTariffType { get; set; }

    [JsonPropertyName("current_tariff_charge")]
    public string CurrentTariffCharge { get; set; }

    [JsonPropertyName("current_tariff_charge_currency_code")]
    public string CurrentTariffChargeCurrencyCode { get; set; }

    [JsonPropertyName("next_tariff_rate")]
    public int NextTariffRate { get; set; }

    [JsonPropertyName("next_tariff_type")]
    public string NextTariffType { get; set; }

    [JsonPropertyName("next_tariff_charge")]
    public string NextTariffCharge { get; set; }

    [JsonPropertyName("next_tariff_starts_at")]
    public DateTime NextTariffStartsAt { get; set; }

    [JsonPropertyName("next_tariff_charge_currency_code")]
    public string NextTariffChargeCurrencyCode { get; set; }
}