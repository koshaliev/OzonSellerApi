using OzonSellerApi.Enums;
using OzonSellerApi.Utils;
using System.Text.Json.Serialization;
using static OzonSellerApi.Dtos.Responses.Postings.FinancialData.FinancialDataProduct;

namespace OzonSellerApi.Dtos.Responses.Postings;
public class V3PostingFbsUnfulfilledListResponseDto
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
    public List<Posting> Postings { get; set; } = [];
}

public class Posting
{
    /// <summary>
    /// Номер отправления.
    /// </summary>
    [JsonPropertyName("posting_number")]
    public string PostingNumber { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор заказа, к которому относится отправление.
    /// </summary>
    [JsonPropertyName("order_id")]
    public long OrderId { get; set; }

    /// <summary>
    /// Номер заказа, к которому относится отправление.
    /// </summary>
    [JsonPropertyName("order_number")]
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// Статус отправления:
    /// <list type="bullet">
    /// <item>acceptance_in_progress — идёт приёмка</item>
    /// <item>arbitration — арбитраж</item>
    /// <item>awaiting_approve — ожидает подтверждения</item>
    /// <item>awaiting_deliver — ожидает отгрузки</item>
    /// <item>awaiting_packaging — ожидает упаковки</item>
    /// <item>awaiting_registration — ожидает регистрации</item>
    /// <item>awaiting_verification — создано</item>
    /// <item>cancelled — отменено</item>
    /// <item>cancelled_from_split_pending — отменён из-за разделения отправления</item>
    /// <item>client_arbitration — клиентский арбитраж доставки</item>
    /// <item>delivering — доставляется</item>
    /// <item>driver_pickup — у водителя</item>
    /// <item>not_accepted — не принят на сортировочном центре</item>
    /// <item>sent_by_seller — отправлено продавцом</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Метод доставки.
    /// </summary>
    [JsonPropertyName("delivery_method")]
    public PostingDeliveryMethod? DeliveryMethod { get; set; }

    /// <summary>
    /// Трек-номер отправления.
    /// </summary>
    [JsonPropertyName("tracking_number")]
    public string TrackingNumber { get; set; } = string.Empty;

    /// <summary>
    /// Тип интеграции со службой доставки:
    /// </summary>
    [JsonPropertyName("tpl_integration_type")]
    public string TplIntegrationType { get; set; } = string.Empty;

    /// <summary>
    /// Дата и время начала обработки отправления.
    /// </summary>
    [JsonPropertyName("in_process_at")]
    public DateTime InProcessAt { get; set; }

    /// <summary>
    /// Дата и время, до которой необходимо собрать отправление. Если отправление не собрать к этой дате — оно автоматически отменится.
    /// </summary>
    [JsonPropertyName("shipment_date")]
    public DateTimeOffset ShipmentDate { get; set; }

    /// <summary>
    /// Дата передачи отправления в доставку.
    /// </summary>
    [JsonPropertyName("delivering_date")]
    public DateTimeOffset DeliveringDate { get; set; }

    /// <summary>
    /// Информация об отмене.
    /// </summary>
    [JsonPropertyName("cancellation")]
    public PostingCancellationInfo? Cancellation { get; set; }

    /// <summary>
    /// Список товаров в отправлении.
    /// </summary>
    [JsonPropertyName("products")]
    public List<PostingProduct> Products { get; set; } = [];

    /// <summary>
    /// Штрихкоды отправления.
    /// </summary>
    [JsonPropertyName("barcodes")]
    public PostingBarcodes? Barcodes { get; set; }

    /// <summary>
    /// Данные аналитики.
    /// </summary>
    [JsonPropertyName("analytics_data")]
    public AnalyticsData? AnalyticsData { get; set; }

    /// <summary>
    /// Данные о стоимости товара, размере скидки, выплате и комиссии.
    /// </summary>
    [JsonPropertyName("financial_data")]
    public FinancialData? FinancialData { get; set; }

    /// <summary>
    /// Если использовалась быстрая доставка Ozon Express — <c>true</c>>.
    /// </summary>
    [JsonPropertyName("is_express")]
    public bool IsExpress { get; set; }

    /// <summary>
    /// Cписок продуктов, для которых нужно передать страну-изготовителя, номер грузовой таможенной декларации (ГТД), регистрационный номер партии товара (РНПТ) или маркировку «Честный ЗНАК», чтобы перевести отправление в следующий статус.
    /// </summary>
    [JsonPropertyName("requirements")]
    public Requirements? Requirements { get; set; }

    /// <summary>
    /// Номер родительского отправления, в результате разделения которого появилось текущее.
    /// </summary>
    [JsonPropertyName("parent_posting_number")]
    public string ParentPostingNumber { get; set; } = string.Empty;

    /// <summary>
    /// Доступные действия и информация об отправлении:
    /// </summary>
    [JsonPropertyName("available_actions")]
    public List<FbsPostingAvailableAction> AvailableActions { get; set; } = [];

    /// <summary>
    /// Количество коробок, в которые упакован товар.
    /// </summary>
    [JsonPropertyName("multi_box_qty")]
    public int MultiBoxQty { get; set; }

    // TODO: реализовать эндпоинт /v3/posting/multiboxqty/set
    /// <summary>
    /// Признак, что в отправлении есть многокоробочный товар и нужно передать количество коробок для него:
    /// <list type="bullet">
    /// <item>true — до сборки передайте количество коробок через метод [WIP] (/v3/posting/multiboxqty/set).</item>
    /// <item>false — отправление собрано с указанием количества коробок в параметре multi_box_qty или в отправлении нет многокоробочного товара.</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("is_multibox")]
    public bool IsMultibox { get; set; }

    /// <summary>
    /// Подстатусы отправления:
    /// <list type="bullet">
    /// <item>posting_acceptance_in_progress — идёт приёмка</item>
    /// <item>posting_in_arbitration — арбитраж</item>
    /// <item>posting_created — создано</item>
    /// <item>posting_in_carriage — в перевозке</item>
    /// <item>posting_not_in_carriage — не добавлено в перевозку</item>
    /// <item>posting_registered — зарегистрировано</item>
    /// <item>posting_transferring_to_delivery (status=awaiting_deliver) — передаётся в доставку</item>
    /// <item>posting_awaiting_passport_data — ожидает паспортных данных</item>
    /// <item>posting_created — создано</item>
    /// <item>posting_awaiting_registration — ожидает регистрации</item>
    /// <item>posting_registration_error — ошибка регистрации</item>
    /// <item>posting_transferring_to_delivery (status=awaiting_registration) — передаётся курьеру</item>
    /// <item>posting_split_pending — создано</item>
    /// <item>posting_canceled — отменено</item>
    /// <item>posting_in_client_arbitration — клиентский арбитраж доставки</item>
    /// <item>posting_delivered — доставлено</item>
    /// <item>posting_received — получено</item>
    /// <item>posting_conditionally_delivered — условно доставлено</item>
    /// <item>posting_in_courier_service — курьер в пути</item>
    /// <item>posting_in_pickup_point — в пункте выдачи</item>
    /// <item>posting_on_way_to_city — в пути в ваш город</item>
    /// <item>posting_on_way_to_pickup_point — в пути в пункт выдачи</item>
    /// <item>posting_returned_to_warehouse — возвращено на склад</item>
    /// <item>posting_transferred_to_courier_service — передаётся в службу доставки</item>
    /// <item>posting_driver_pick_up — у водителя</item>
    /// <item>posting_not_in_sort_center — не принято на сортировочном центре</item>
    /// <item>sent_by_seller — отправлено продавцом</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("substatus")]
    public string Substatus { get; set; } = string.Empty;

    /// <summary>
    /// Код услуги погрузочно-разгрузочных работ:
    /// <list type="bullet">
    /// <item>lift — подъём на лифте.</item>
    /// <item>stairs — подъём по лестнице.</item>
    /// <item>none — покупатель отказался от услуги, поднимать товары не нужно.</item>
    /// <item>delivery_default — доставка включена в стоимость, по условиям оферты нужно доставить товар на этаж.</item>
    /// </list>
    /// Параметр актуален для КГТ-отправлений с доставкой силами продавца или интегрированной службой.
    /// </summary>
    [JsonPropertyName("prr_option")]
    public string PrrOption { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор эконом-товара.
    /// </summary>
    [JsonPropertyName("quantum_id")]
    public long QuantumId { get; set; }

    /// <summary>
    /// Информация по тарификации отгрузки.
    /// </summary>
    [JsonPropertyName("tariffication")]
    public Tariffication? Tariffication { get; set; }

    /// <summary>
    /// Дата и время успешной валидации кода курьера. Чтобы проверить код курьера, воспользуйтесь методом [WIP] (/v1/posting/fbs/pick-up-code/verify).
    /// </summary>
    [JsonPropertyName("pickup_code_verified_at")]
    public DateTimeOffset PickupCodeVerifiedAt { get; set; }


    /// <summary>
    /// Штрихкоды отправления.
    /// </summary>
    public class PostingBarcodes
    {
        /// <summary>
        /// Верхний штрихкод на маркировке отправления.
        /// </summary>
        [JsonPropertyName("upper_barcode")]
        public string? UpperBarcode { get; set; }

        /// <summary>
        /// Нижний штрихкод на маркировке отправления.
        /// </summary>
        [JsonPropertyName("lower_barcode")]
        public string? LowerBarcode { get; set; }
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
        /// <item><c>seller</c> — отменено продавцом.</item>
        /// <item><c>client</c> или <c>customer</c> — отменено покупателем.</item>
        /// <item><c>ozon</c> — отменено Ozon.</item>
        /// <item><c>system</c> — отменено системой.</item>
        /// <item><c>delivery</c> — отменено службой доставки.</item>
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
        /// <item>Продавец</item>
        /// <item>Клиент или покупатель</item>
        /// <item>Ozon</item>
        /// <item>Система</item>
        /// <item>Служба доставки</item>
        /// </list>
        [JsonPropertyName("cancellation_initiator")]
        public string CancellationInitiator { get; set; } = string.Empty;
    }
}

/// <summary>
/// Данные аналитики.
/// </summary>
public class AnalyticsData
{
    /// <summary>
    /// Регион доставки. Только для отправлений rFBS.
    /// </summary>
    [JsonPropertyName("region")]
    public string Region { get; set; } = string.Empty;

    /// <summary>
    /// Город доставки. Только для отправлений rFBS.
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Способ доставки.
    /// </summary>
    [JsonPropertyName("delivery_type")]
    public string DeliveryType { get; set; } = string.Empty;

    /// <summary>
    /// Наличие подписки Premium.
    /// </summary>
    [JsonPropertyName("is_premium")]
    public bool IsPremium { get; set; }

    /// <summary>
    /// Способы оплаты:
    /// <list type="bullet">
    /// <item>картой онлайн</item>
    /// <item>Ozon Карта</item>
    /// <item>автосписание с Ozon Карты при выдаче</item>
    /// <item>сохранённой картой при получении</item>
    /// <item>Система Быстрых Платежей</item>
    /// <item>Ozon Рассрочка</item>
    /// <item>оплата на расчётный счёт</item>
    /// <item>SberPay</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("payment_type_group_name")]
    public string PaymentTypeGroupName { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор склада.
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public long WarehouseId { get; set; }

    /// <summary>
    /// Название склада отправки заказа.
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
    public string TplProvider { get; set; } = string.Empty;

    /// <summary>
    /// Дата и время начала доставки.
    /// </summary>
    [JsonPropertyName("delivery_date_begin")]
    public DateTimeOffset DeliveryDateBegin { get; set; }

    /// <summary>
    /// Дата и время конца доставки.
    /// </summary>
    [JsonPropertyName("delivery_date_end")]
    public DateTimeOffset DeliveryDateEnd { get; set; }

    /// <summary>
    /// Признак, что получатель юридическое лицо: 
    /// <list type="bullet">
    /// <item><c>true</c> — юридическое лицо,</item>
    /// <item><c>false</c> — физическое лицо.</item>
    /// </list> 
    /// </summary>
    [JsonPropertyName("is_legal")]
    public bool IsLegal { get; set; }
}

/// <summary>
/// Метод доставки.
/// </summary>
public class PostingDeliveryMethod
{
    /// <summary>
    /// Идентификатор способа доставки.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Название способа доставки.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор склада.
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public long WarehouseId { get; set; }

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
    public string TplProvider { get; set; } = string.Empty;
}

/// <summary>
/// Данные о стоимости товара, размере скидки, выплате и комиссии.
/// </summary>
public class FinancialData
{
    /// <summary>
    /// Список товаров в заказе.
    /// </summary>
    [JsonPropertyName("products")]
    public List<FinancialDataProduct> Products { get; set; } = [];

    /// <summary>
    /// Код региона, откуда отправляется заказ.
    /// </summary>
    [JsonPropertyName("cluster_from")]
    public string ClusterFrom { get; set; } = string.Empty;

    /// <summary>
    /// Код региона, куда доставляется заказ.
    /// </summary>
    [JsonPropertyName("cluster_to")]
    public string ClusterTo { get; set; } = string.Empty;

    public class FinancialDataProduct
    {
        /// <summary>
        /// Цена товара с учётом скидок — это значение показывается на карточке товара.
        /// </summary>
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Количество товара в отправлении.
        /// </summary>
        [JsonPropertyName("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// Валюта ваших цен. Cовпадает с валютой, которая установлена в настройках личного кабинета.
        /// </summary>
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; } = string.Empty;

        /// <summary>
        /// Размер комиссии за товар.
        /// </summary>
        [JsonPropertyName("commission_amount")]
        public decimal CommissionAmount { get; set; }

        /// <summary>
        /// Процент комиссии.
        /// </summary>
        [JsonPropertyName("commission_percent")]
        public long CommissionPercent { get; set; }

        /// <summary>
        /// Код валюты, в которой рассчитывались комиссии.
        /// </summary>
        [JsonPropertyName("commissions_currency_code")]
        public string CommissionsCurrencyCode { get; set; } = string.Empty;

        /// <summary>
        /// Выплата продавцу.
        /// </summary>
        [JsonPropertyName("payout")]
        public decimal Payout { get; set; }

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }

        /// <summary>
        /// Цена до учёта скидок. На карточке товара отображается зачёркнутой.
        /// </summary>
        [JsonPropertyName("old_price")]
        public decimal OldPrice { get; set; }

        /// <summary>
        /// Сумма скидки.
        /// </summary>
        [JsonPropertyName("total_discount_value")]
        public decimal TotalDiscountValue { get; set; }

        /// <summary>
        /// Процент скидки
        /// </summary>
        [JsonPropertyName("total_discount_percent")]
        public double TotalDiscountPercent { get; set; }

        /// <summary>
        /// Действия.
        /// </summary>
        [JsonPropertyName("actions")]
        public List<string> Actions { get; set; } = [];


        public class PostingProduct
        {
            /// <summary>
            /// Обязательная маркировка товара.
            /// </summary>
            [JsonPropertyName("mandatory_mark")]
            public List<string> MandatoryMark { get; set; } = [];

            /// <summary>
            /// Название товара.
            /// </summary>
            [JsonPropertyName("name")]
            public string Name { get; set; } = string.Empty;

            /// <summary>
            /// Идентификатор товара в системе продавца — артикул.
            /// </summary>
            [JsonPropertyName("offer_id")]
            public string OfferId { get; set; } = string.Empty;

            /// <summary>
            /// Цена товара.
            /// </summary>
            [JsonConverter(typeof(StringToDecimalJsonConverter))]
            [JsonPropertyName("price")]
            public decimal Price { get; set; }

            /// <summary>
            /// Количество товара в отправлении.
            /// </summary>
            [JsonPropertyName("quantity")]
            public int Quantity { get; set; }

            /// <summary>
            /// Идентификатор товара в системе Ozon — SKU.
            /// </summary>
            [JsonPropertyName("sku")]
            public long Sku { get; set; }

            /// <summary>
            /// Валюта ваших цен. Совпадает с валютой, которая установлена в настройках личного кабинета.
            /// </summary>
            [JsonPropertyName("currency_code")]
            public string CurrencyCode { get; set; } = string.Empty;
        }
    }
}

/// <summary>
/// Cписок продуктов, для которых нужно передать страну-изготовителя, номер грузовой таможенной декларации (ГТД), регистрационный номер партии товара (РНПТ) или маркировку «Честный ЗНАК», чтобы перевести отправление в следующий статус.
/// </summary>
public class Requirements
{
    // TODO: релизовать методы: /v3/posting/fbs/ship/package; /v3/posting/fbs/ship; /v2/posting/fbs/product/country/set
    /// <summary>
    /// Список идентификаторов товаров (SKU), для которых нужно передать номера таможенной декларации (ГТД).
    /// Для сборки отправления передайте для всех перечисленных товаров номер таможенной декларации или информацию о том, что номера нет, с помощью метода [WIP] (/v3/posting/fbs/ship/package) или [WIP] (/v3/posting/fbs/ship).
    /// </summary>
    [JsonPropertyName("products_requiring_gtd")]
    public List<long> ProductsRequiringGtd { get; set; } = [];

    /// <summary>
    /// Список идентификаторов товаров (SKU), для которых нужно передать информацию о стране-изготовителе.
    /// Для сборки отправления передайте информацию о стране-изготовителе для всех перечисленных товаров с помощью метода [WIP] (/v2/posting/fbs/product/country/set).
    /// </summary>
    [JsonPropertyName("products_requiring_country")]
    public List<long> ProductsRequiringCountry { get; set; } = [];

    /// <summary>
    /// Список идентификаторов товаров (SKU), для которых нужно передать маркировку «Честный ЗНАК».
    /// </summary>
    [JsonPropertyName("products_requiring_mandatory_mark")]
    public List<long> ProductsRequiringMandatoryMark { get; set; } = [];

    /// <summary>
    /// Список идентификаторов товаров (SKU), для которых нужно передать регистрационный номер партии товара (РНПТ).
    /// </summary>
    [JsonPropertyName("products_requiring_rnpt")]
    public List<long> ProductsRequiringRnpt { get; set; } = [];

    /// <summary>
    /// Список товаров, для которых нужно передать уникальный идентификационный номер (УИН) ювелирного изделия.
    /// </summary>
    [JsonPropertyName("products_requiring_jw_uin")]
    public List<long> ProductsRequiringJwUin { get; set; } = [];
}

/// <summary>
/// Информация по тарификации отгрузки.
/// </summary>
public class Tariffication
{
    /// <summary>
    /// Текущий процент тарификации.
    /// </summary>
    [JsonPropertyName("current_tariff_rate")]
    public decimal CurrentTariffRate { get; set; }

    /// <summary>
    /// Текущий тип тарификации — скидка или надбавка.
    /// </summary>
    [JsonPropertyName("current_tariff_type")]
    public string CurrentTariffType { get; set; } = string.Empty;

    /// <summary>
    /// Текущая сумма скидки или надбавки.
    /// </summary>
    [JsonConverter(typeof(StringToDecimalJsonConverter))]
    [JsonPropertyName("current_tariff_charge")]
    public decimal CurrentTariffCharge { get; set; }

    /// <summary>
    /// Валюта суммы.
    /// </summary>
    [JsonPropertyName("current_tariff_charge_currency_code")]
    public string CurrentTariffChargeCurrencyCode { get; set; } = string.Empty;

    /// <summary>
    /// Процент, по которому будет тарифицироваться отправление через указанное в параметре <see cref="Tariffication.NextTariffStartsAt"/> время
    /// </summary>
    [JsonConverter(typeof(StringToDecimalJsonConverter))]
    [JsonPropertyName("next_tariff_rate")]
    public decimal NextTariffRate { get; set; }

    /// <summary>
    /// Тип тарифа, по которому будет тарифицироваться отправление через указанное в параметре <see cref="Tariffication.NextTariffStartsAt"/> время — скидка или надбавка.
    /// </summary>
    [JsonPropertyName("next_tariff_type")]
    public string NextTariffType { get; set; } = string.Empty;

    /// <summary>
    /// Сумма скидки или надбавки на следующем шаге тарификации.
    /// </summary>
    [JsonConverter(typeof(StringToDecimalJsonConverter))]
    [JsonPropertyName("next_tariff_charge")]
    public decimal NextTariffCharge { get; set; }

    /// <summary>
    /// Дата и время, когда начнёт применяться новый тариф.
    /// </summary>
    [JsonPropertyName("next_tariff_starts_at")]
    public DateTimeOffset NextTariffStartsAt { get; set; }

    /// <summary>
    /// Валюта нового тарифа.
    /// </summary>
    [JsonPropertyName("next_tariff_charge_currency_code")]
    public string NextTariffChargeCurrencyCode { get; set; } = string.Empty;
}