using OzonSellerApi.Utils;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Products;

// created: 26.01.2025
public class V3ProductInfoListResponseDto
{
    /// <summary>
    /// Массив данных.
    /// </summary>
    [JsonPropertyName("items")]
    public List<ProductInfoItem> Items { get; set; } = [];


    public class ProductInfoItem
    {
        /// <summary>
        /// Все штрихкоды товара.
        /// </summary>
        [JsonPropertyName("barcodes")]
        public List<string> Barcodes { get; set; } = [];

        /// <summary>
        /// Изображение цвета товара.
        /// </summary>
        [JsonPropertyName("color_image")]
        public List<string> ColorImage { get; set; } = [];

        /// <summary>
        /// Информация о комиссиях.
        /// </summary>
        [JsonPropertyName("commissions")]
        public List<Commission> Commissions { get; set; } = [];

        /// <summary>
        /// Дата и время создания товара.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор категории. 
        /// <para>Используйте его с методами /v1/description-category/attribute и /v1/description-category/attribute/values.</para>
        /// </summary>
        [JsonPropertyName("description_category_id")]
        public long DescriptionCategoryId { get; set; }

        /// <summary>
        /// Остатки уценённого товара на складе Ozon.
        /// </summary>
        [JsonPropertyName("discounted_fbo_stocks")]
        public int DiscountedFboStocks { get; set; }

        /// <summary>
        /// Информация об ошибках при создании или валидации товара.
        /// </summary>
        [JsonPropertyName("errors")]
        public List<ProductError> Errors { get; set; } = [];

        /// <summary>
        /// Признак, что у товара есть уценённые аналоги на складе Ozon.
        /// </summary>
        [JsonPropertyName("has_discounted_fbo_item")]
        public bool HasDiscountedFboItem { get; set; }

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Массив ссылок на изображения. Изображения в массиве расположены в порядке их расположения на сайте. 
        /// <para>Если параметр <c>primary_image</c> не указан, первое изображение в массиве главное для товара.</para>
        /// </summary>
        [JsonPropertyName("images")]
        public List<string> Images { get; set; } = [];

        /// <summary>
        /// Массив изображений 360.
        /// </summary>
        [JsonPropertyName("images360")]
        public List<string> Images360 { get; set; } = [];

        /// <summary>
        /// <c>true</c>, если товар архивирован вручную.
        /// </summary>
        [JsonPropertyName("is_archived")]
        public bool IsArchived { get; set; }

        /// <summary>
        /// <c>true</c>, если товар архивирован автоматически.
        /// </summary>
        [JsonPropertyName("is_autoarchived")]
        public bool IsAutoarchived { get; set; }

        /// <summary>
        /// Признак, является ли товар уценённым:
        /// <list type="bullet">
        /// <item>Если товар создавался продавцом как уценённый — <c>true</c>.</item>
        /// <item>Если товар не уценённый или был уценён Ozon — <c>false</c>.</item>
        /// </list>
        /// </summary>
        [JsonPropertyName("is_discounted")]
        public bool IsDiscounted { get; set; }

        /// <summary>
        /// Признак крупногабаритного товара.
        /// </summary>
        [JsonPropertyName("is_kgt")]
        public bool IsKgt { get; set; }

        /// <summary>
        /// true, если возможна предоплата.
        /// </summary>
        [JsonPropertyName("is_prepayment_allowed")]
        public bool IsPrepaymentAllowed { get; set; }

        /// <summary>
        /// Признак супер-товара.
        /// </summary>
        [JsonPropertyName("is_super")]
        public bool IsSuper { get; set; }

        /// <summary>
        /// Цена на товар с учётом всех акций. Это значение будет указано на витрине Ozon.
        /// </summary>
        /// 
        [JsonPropertyName("marketing_price")]
        [JsonConverter(typeof(StringToDecimalJsonConverter))]
        public decimal MarketingPrice { get; set; }

        /// <summary>
        /// Минимальная цена товара после применения акций.
        /// </summary>
        [JsonPropertyName("min_price")]
        [JsonConverter(typeof(StringToDecimalJsonConverter))]

        public decimal MinPrice { get; set; }

        /// <summary>
        /// Информация о модели товара.
        /// </summary>
        [JsonPropertyName("model_info")]
        public ProductModelInfo? ModelInfo { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор товара в системе продавца — артикул.
        /// </summary>
        [JsonPropertyName("offer_id")]
        public string OfferId { get; set; } = string.Empty;

        /// <summary>
        /// Цена до учёта скидок. На карточке товара отображается зачёркнутой.
        /// </summary>
        [JsonPropertyName("old_price")]
        [JsonConverter(typeof(StringToDecimalJsonConverter))]
        public decimal OldPrice { get; set; }

        /// <summary>
        /// Цена товара с учётом скидок — это значение показывается на карточке товара.
        /// </summary>
        [JsonPropertyName("price")]
        [JsonConverter(typeof(StringToDecimalJsonConverter))]
        public decimal Price { get; set; }

        /// <summary>
        /// Ценовые индексы товара.
        /// </summary>
        [JsonPropertyName("price_indexes")]
        public ProductPriceIndexes? PriceIndexes { get; set; }

        /// <summary>
        /// Главное изображение товара.
        /// </summary>
        [JsonPropertyName("primary_image")]
        public List<string> PrimaryImage { get; set; } = [];

        /// <summary>
        /// Информация об источниках создания товара.
        /// </summary>
        [JsonPropertyName("sources")]
        public List<ProductSource> Sources { get; set; } = [];

        /// <summary>
        /// Информация о статусах товара.
        /// </summary>
        [JsonPropertyName("statuses")]
        public ProductStatuses? Statuses { get; set; }

        /// <summary>
        /// Информация об остатках товара.
        /// </summary>
        [JsonPropertyName("stocks")]
        public ProductStocksInfo? Stocks { get; set; }

        /// <summary>
        /// Идентификатор типа товара.
        /// </summary>
        [JsonPropertyName("type_id")]
        public long TypeId { get; set; }

        /// <summary>
        /// Дата последнего обновления товара.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        /// <summary>
        /// Ставка НДС для товара.
        /// </summary>
        [JsonPropertyName("vat")]
        public string Vat { get; set; } = string.Empty;

        /// <summary>
        /// Настройки видимости товара.
        /// </summary>
        [JsonPropertyName("visibility_details")]
        public ProductVisibilityDetails? VisibilityDetails { get; set; }

        /// <summary>
        /// Объёмный вес товара.
        /// </summary>
        [JsonPropertyName("volume_weight")]
        public decimal VolumeWeight { get; set; }

        public class Commission
        {
            [JsonPropertyName("delivery_amount")]
            public decimal DeliveryAmount { get; set; }

            [JsonPropertyName("percent")]
            public decimal Percent { get; set; }

            [JsonPropertyName("return_amount")]
            public decimal ReturnAmount { get; set; }

            [JsonPropertyName("sale_schema")]
            public string SaleSchema { get; set; } = string.Empty;

            [JsonPropertyName("value")]
            public decimal Value { get; set; }
        }

        /// <summary>
        /// Информация об ошибке при создании или валидации товара.
        /// </summary>
        public class ProductError
        {
            /// <summary>
            /// Идентификатор характеристики.
            /// </summary>
            [JsonPropertyName("attribute_id")]
            public long AttributeId { get; set; }

            /// <summary>
            /// Код ошибки.
            /// </summary>
            [JsonPropertyName("code")]
            public string Code { get; set; } = string.Empty;

            /// <summary>
            /// Поле, в котором найдена ошибка.
            /// </summary>
            [JsonPropertyName("field")]
            public string Field { get; set; } = string.Empty;

            // TODO: NotImportant - сделать Enum: "ERROR_LEVEL_UNSPECIFIED" "ERROR_LEVEL_ERROR" "ERROR_LEVEL_WARNING" "ERROR_LEVEL_INTERNAL"
            // Описание уровней ошибок:
            //      ERROR_LEVEL_UNSPECIFIED — не определено;
            //      ERROR_LEVEL_ERROR — некритичная ошибка, товар можно продавать;
            //      ERROR_LEVEL_WARNING — критичная ошибка, товар можно продавать;
            //      ERROR_LEVEL_INTERNAL — критичная ошибка, товар нельзя продавать.
            /// <summary>
            /// Уровень ошибки.
            /// </summary>
            [JsonPropertyName("level")]
            public string Level { get; set; } = string.Empty;

            /// <summary>
            /// Статус товара, в котором произошла ошибка.
            /// </summary>
            [JsonPropertyName("state")]
            public string State { get; set; } = string.Empty;

            /// <summary>
            /// Описание ошибок.
            /// </summary>
            [JsonPropertyName("texts")]
            public ErrorTexts? Texts { get; set; }

            /// <summary>
            /// Описание ошибок.
            /// </summary>
            public class ErrorTexts
            {
                /// <summary>
                /// Название атрибута, в котором произошла ошибка.
                /// </summary>
                [JsonPropertyName("attribute_name")]
                public string AttributeName { get; set; } = string.Empty;

                /// <summary>
                /// Описание ошибки.
                /// </summary>
                [JsonPropertyName("description")]
                public string Description { get; set; } = string.Empty;

                /// <summary>
                /// Код ошибки в системе Ozon.
                /// </summary>
                [JsonPropertyName("hint_code")]
                public string HintCode { get; set; } = string.Empty;

                /// <summary>
                /// Текст ошибки.
                /// </summary>
                [JsonPropertyName("message")]
                public string Message { get; set; } = string.Empty;

                /// <summary>
                /// В каких параметрах допущена ошибка.
                /// </summary>
                [JsonPropertyName("params")]
                public List<Param> Params { get; set; } = [];

                /// <summary>
                /// Краткое описание ошибки.
                /// </summary>
                [JsonPropertyName("short_description")]
                public string ShortDescription { get; set; } = string.Empty;

                /// <summary>
                /// В каком параметре допущена ошибка.
                /// </summary>
                public class Param
                {
                    /// <summary>
                    /// Название параметра.
                    /// </summary>
                    [JsonPropertyName("name")]
                    public string Name { get; set; } = string.Empty;

                    /// <summary>
                    /// Значение параметра.
                    /// </summary>
                    [JsonPropertyName("value")]
                    public string Value { get; set; } = string.Empty;
                }
            }
        }

        /// <summary>
        /// Информация о модели товара.
        /// </summary>
        public class ProductModelInfo
        {
            /// <summary>
            /// Количество товаров в ответе.
            /// </summary>
            [JsonPropertyName("count")]
            public long Count { get; set; }

            /// <summary>
            /// Идентификатор модели товара.
            /// </summary>
            [JsonPropertyName("model_id")]
            public long ModelId { get; set; }
        }

        /// <summary>
        /// Ценовые индексы товара.
        /// </summary>
        public class ProductPriceIndexes
        {
            [JsonPropertyName("color_index")]
            public string ColorIndex { get; set; } = string.Empty; // NotImportant - TODO: Enum: "COLOR_INDEX_UNSPECIFIED" "COLOR_INDEX_WITHOUT_INDEX" "COLOR_INDEX_GREEN" "COLOR_INDEX_YELLOW" "COLOR_INDEX_RED"

            /// <summary>
            /// Цена товара у конкурентов на других площадках.
            /// </summary>
            [JsonPropertyName("external_index_data")]
            public PriceIndexData? ExternalIndexData { get; set; }

            /// <summary>
            /// Цена товара у конкурентов на Ozon.
            /// </summary>
            [JsonPropertyName("ozon_index_data")]
            public PriceIndexData? OzonIndexData { get; set; }

            /// <summary>
            /// Цена вашего товара на других площадках.
            /// </summary>
            [JsonPropertyName("self_marketplaces_index_data")]
            public PriceIndexData? SelfMarketplacesIndexData { get; set; }

            public class PriceIndexData
            {
                [JsonPropertyName("minimal_price")]
                [JsonConverter(typeof(StringToDecimalJsonConverter))]
                public decimal MinimalPrice { get; set; }

                [JsonPropertyName("minimal_price_currency")]
                public string MinimalPriceCurrency { get; set; } = string.Empty;

                [JsonPropertyName("price_index_value")]
                public decimal PriceIndexValue { get; set; }
            }
        }

        /// <summary>
        /// Информация об источниках создания товара.
        /// </summary>
        public class ProductSource
        {
            /// <summary>
            /// Дата создания товара.
            /// </summary>
            [JsonPropertyName("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            /// <summary>
            /// Список квантов с товарами.
            /// </summary>
            [JsonPropertyName("quant_code")]
            public string QuantCode { get; set; } = string.Empty;

            [JsonPropertyName("shipment_type")]
            public string ShipmentType { get; set; } = string.Empty; // NotImportant - TODO: Enum: "SHIPMENT_TYPE_UNSPECIFIED" "SHIPMENT_TYPE_GENERAL" "SHIPMENT_TYPE_BOX" "SHIPMENT_TYPE_PALLET"

            /// <summary>
            /// Идентификатор товара на Ozon — SKU.
            /// </summary>
            [JsonPropertyName("sku")]
            public long Sku { get; set; }

            /// <summary>
            /// Схема продажи.
            /// </summary>
            [JsonPropertyName("source")]
            public string Source { get; set; } = string.Empty;
        }

        /// <summary>
        /// Информация о статусах товара.
        /// </summary>
        public class ProductStatuses
        {
            /// <summary>
            /// true, если товар создан корректно.
            /// </summary>
            [JsonPropertyName("is_created")]
            public bool IsCreated { get; set; }

            /// <summary>
            /// Статус модерации.
            /// </summary>
            [JsonPropertyName("moderate_status")]
            public string ModerateStatus { get; set; } = string.Empty;

            /// <summary>
            /// Статус товара.
            /// </summary>
            [JsonPropertyName("status")]
            public string Status { get; set; } = string.Empty;

            /// <summary>
            /// Описание статуса товара.
            /// </summary>
            [JsonPropertyName("status_description")]
            public string StatusDescription { get; set; } = string.Empty;

            /// <summary>
            /// Статус товара, в котором возникла ошибка.
            /// </summary>
            [JsonPropertyName("status_failed")]
            public string StatusFailed { get; set; } = string.Empty;

            /// <summary>
            /// Название статуса товара.
            /// </summary>
            [JsonPropertyName("status_name")]
            public string StatusName { get; set; } = string.Empty;

            /// <summary>
            /// Описание статуса.
            /// </summary>
            [JsonPropertyName("status_tooltip")]
            public string StatusTooltip { get; set; } = string.Empty;

            /// <summary>
            /// Время последнего изменения статуса.
            /// </summary>
            [JsonPropertyName("status_updated_at")]
            public DateTimeOffset StatusUpdatedAt { get; set; }

            /// <summary>
            /// Статус валидации.
            /// </summary>
            [JsonPropertyName("validation_status")]
            public string ValidationStatus { get; set; } = string.Empty;
        }

        /// <summary>
        /// Информация об остатках товара.
        /// </summary>
        public class ProductStocksInfo
        {
            /// <summary>
            /// true, если есть остаток на складах.
            /// </summary>
            [JsonPropertyName("has_stock")]
            public bool HasStock { get; set; }

            /// <summary>
            /// Статус остатков товара.
            /// </summary>
            [JsonPropertyName("stocks")]
            public List<ProductStock> Stocks { get; set; } = [];

            public class ProductStock
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

                /// <summary>
                /// Идентификатор товара в системе Ozon — SKU.
                /// </summary>
                [JsonPropertyName("sku")]
                public long Sku { get; set; }

                /// <summary>
                /// Схема продажи.
                /// </summary>
                [JsonPropertyName("source")]
                public string Source { get; set; } = string.Empty;
            }
        }

        /// <summary>
        /// Настройки видимости товара.
        /// </summary>
        public class ProductVisibilityDetails
        {
            /// <summary>
            /// Если установлена цена — true.
            /// </summary>
            [JsonPropertyName("has_price")]
            public bool HasPrice { get; set; }

            /// <summary>
            /// Если есть остаток на складах — true.
            /// </summary>
            [JsonPropertyName("has_stock")]
            public bool HasStock { get; set; }
        }
    }
}