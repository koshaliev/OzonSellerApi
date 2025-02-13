using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Responses.Prices;
// created: 29.01.2025
public class V5ProductInfoPricesResponseDto
{
    /// <summary>
    /// Указатель для выборки следующих данных.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; } = string.Empty;

    /// <summary>
    /// Список товаров.
    /// </summary>
    [JsonPropertyName("items")]
    public List<ProductInfoPricesResponseItem> Items { get; set; } = [];

    /// <summary>
    /// Количество товаров в списке.
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }


    public class ProductInfoPricesResponseItem
    {
        /// <summary>
        /// Максимальная комиссия за эквайринг.
        /// </summary>
        [JsonPropertyName("acquiring")]
        public int Acquiring { get; set; }

        /// <summary>
        /// Информация о комиссиях.
        /// </summary>
        [JsonPropertyName("commissions")]
        public ProductCommissions? Commissions { get; set; }

        /// <summary>
        /// Маркетинговые акции продавца.
        /// </summary>
        [JsonPropertyName("marketing_actions")]
        public ProductMarketingActionsInfo? MarketingActions { get; set; }

        /// <summary>
        /// Идентификатор товара в системе продавца.
        /// </summary>
        [JsonPropertyName("offer_id")]
        public string OfferId { get; set; } = string.Empty;

        /// <summary>
        /// Цена товара.
        /// </summary>
        [JsonPropertyName("price")]
        public ProductPriceInfo? Price { get; set; }

        /// <summary>
        /// Индексы цены товара.
        /// </summary>
        [JsonPropertyName("price_indexes")]
        public ProductPriceIndexes? PriceIndexes { get; set; }

        /// <summary>
        /// Идентификатор товара.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }

        /// <summary>
        /// Объёмный вес товара.
        /// </summary>
        [JsonPropertyName("volume_weight")]
        public decimal VolumeWeight { get; set; }

        /// <summary>
        /// Информация о комиссиях.
        /// </summary>
        public class ProductCommissions
        {
            /// <summary>
            /// Последняя миля (FBO).
            /// </summary>
            [JsonPropertyName("fbo_deliv_to_customer_amount")]
            public decimal FboDelivToCustomerAmount { get; set; }

            /// <summary>
            /// Магистраль до (FBO).
            /// </summary>
            [JsonPropertyName("fbo_direct_flow_trans_max_amount")]
            public decimal FboDirectFlowTransMaxAmount { get; set; }

            /// <summary>
            /// Магистраль от (FBO)
            /// </summary>
            [JsonPropertyName("fbo_direct_flow_trans_min_amount")]
            public decimal FboDirectFlowTransMinAmount { get; set; }

            /// <summary>
            /// Комиссия за возврат и отмену (FBO).
            /// </summary>
            [JsonPropertyName("fbo_return_flow_amount")]
            public decimal FboReturnFlowAmount { get; set; }

            /// <summary>
            /// Последняя миля (FBS).
            /// </summary>
            [JsonPropertyName("fbs_deliv_to_customer_amount")]
            public decimal FbsDelivToCustomerAmount { get; set; }

            /// <summary>
            /// Магистраль до (FBS).
            /// </summary>
            [JsonPropertyName("fbs_direct_flow_trans_max_amount")]
            public decimal FbsDirectFlowTransMaxAmount { get; set; }

            /// <summary>
            /// Магистраль от (FBS).
            /// </summary>
            [JsonPropertyName("fbs_direct_flow_trans_min_amount")]
            public decimal FbsDirectFlowTransMinAmount { get; set; }

            /// <summary>
            /// Максимальная комиссия за обработку отправления (FBS).
            /// </summary>
            [JsonPropertyName("fbs_first_mile_max_amount")]
            public decimal FbsFirstMileMaxAmount { get; set; }

            /// <summary>
            /// Минимальная комиссия за обработку отправления (FBS).
            /// </summary>
            [JsonPropertyName("fbs_first_mile_min_amount")]
            public decimal FbsFirstMileMinAmount { get; set; }

            /// <summary>
            /// Комиссия за возврат и отмену, обработка отправления (FBS).
            /// </summary>
            [JsonPropertyName("fbs_return_flow_amount")]
            public decimal FbsReturnFlowAmount { get; set; }

            /// <summary>
            /// Процент комиссии за продажу (FBO).
            /// </summary>
            [JsonPropertyName("sales_percent_fbo")]
            public decimal SalesPercentFbo { get; set; }

            /// <summary>
            /// Процент комиссии за продажу (FBS).
            /// </summary>
            [JsonPropertyName("sales_percent_fbs")]
            public decimal SalesPercentFbs { get; set; }
        }

        /// <summary>
        /// Маркетинговые акции продавца.
        /// </summary>
        public class ProductMarketingActionsInfo
        {
            /// <summary>
            /// Маркетинговые акции продавца. Параметры <c>DateFrom</c>, <c>DateTo</c>>, <c>Title</c> и <c>Value</c>> указываются для каждой акции продавца.
            /// </summary>
            [JsonPropertyName("actions")]
            public List<ProductMarktetingAction> Actions { get; set; } = [];

            /// <summary>
            /// Дата и время начала текущего периода по всем действующим акциям.
            /// </summary>
            [JsonPropertyName("current_period_from")]
            public DateTimeOffset? CurrentPeriodFrom { get; set; }

            /// <summary>
            /// Дата и время окончания текущего периода по всем действующим акциям.
            /// </summary>
            [JsonPropertyName("current_period_to")]
            public DateTimeOffset? CurrentPeriodTo { get; set; }

            /// <summary>
            /// <c>true</c>, если к товару можно применить акцию за счёт Ozon.
            /// </summary>
            [JsonPropertyName("ozon_actions_exist")]
            public bool OzonActionsExist { get; set; }

            /// <summary>
            /// Маркетинговая акция продавца. 
            /// </summary>
            /// <remarks>
            /// Под вопросом как правильно обрабатывать (пример не соответствует схеме).
            /// </remarks>
            public class ProductMarktetingAction // TODO: ?? - 29.01.2025 - в документации отвратительно сделан пример, в схеме одно, в ответе другое!
            {
                /// <summary>
                /// Дата и время начала акции продавца.
                /// </summary>
                [JsonPropertyName("date_from")]
                public DateTimeOffset DateFrom { get; set; }

                /// <summary>
                /// Дата и время окончания акции продавца.
                /// </summary>
                [JsonPropertyName("date_to")]
                public DateTimeOffset DateTo { get; set; }

                /// <summary>
                /// Название акции продавца.
                /// </summary>
                [JsonPropertyName("title")]
                public string Title { get; set; } = string.Empty;

                /// <summary>
                /// Скидка по акции продавца.
                /// </summary>
                [JsonPropertyName("value")]
                public decimal Value { get; set; }
            }
        }

        /// <summary>
        /// Цена товара.
        /// </summary>
        public class ProductPriceInfo
        {
            /// <summary>
            /// <c>true</c>, если автоприменение акций у товара включено.
            /// </summary>
            [JsonPropertyName("auto_action_enabled")]
            public bool AutoActionEnabled { get; set; }

            // TODO: NotImportant - перевести валюту в ENUM? 
            /// <summary>
            /// Валюта ваших цен. Совпадает с валютой, которая установлена в настройках личного кабинета.
            /// <para>Возможные значения:</para>
            /// <list type="bullet">
            /// <item><description><c>RUB</c> — российский рубль</description></item>
            /// <item><description><c>BYN</c> — белорусский рубль</description></item>
            /// <item><description><c>KZT</c> — тенге</description></item>
            /// <item><description><c>EUR</c> — евро</description></item>
            /// <item><description><c>USD</c> — доллар США</description></item>
            /// <item><description><c>CNY</c> — юань</description></item>
            /// </list>
            /// </summary>
            [JsonPropertyName("currency_code")]
            public string CurrencyCode { get; set; } = string.Empty;

            /// <summary>
            /// Цена на товар с учётом всех акций, которая будет указана на витрине Ozon.
            /// </summary>
            [JsonPropertyName("marketing_price")]
            public decimal MarketingPrice { get; set; }

            /// <summary>
            /// Цена на товар с учётом акций продавца.
            /// </summary>
            [JsonPropertyName("marketing_seller_price")]
            public decimal MarketingSellerPrice { get; set; }

            /// <summary>
            /// Минимальная цена товара после применения всех скидок.
            /// </summary>
            [JsonPropertyName("min_price")]
            public decimal MinPrice { get; set; }

            /// <summary>
            /// Цена до учёта скидок. На карточке товара отображается зачёркнутой.
            /// </summary>
            [JsonPropertyName("old_price")]
            public decimal OldPrice { get; set; }

            /// <summary>
            /// Цена товара с учётом скидок — это значение показывается на карточке товара.
            /// </summary>
            [JsonPropertyName("price")]
            public decimal Price { get; set; }

            /// <summary>
            /// Цена поставщика.
            /// </summary>
            [JsonPropertyName("retail_price")]
            public decimal RetailPrice { get; set; }

            /// <summary>
            /// Ставка НДС для товара.
            /// </summary>
            [JsonPropertyName("vat")]
            public double Vat { get; set; }
        }

        /// <summary>
        /// Индексы цены товара.
        /// </summary>
        public class ProductPriceIndexes
        {
            [JsonPropertyName("color_index")]
            public string ColorIndex { get; set; } = string.Empty;

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

            /// <summary>
            /// Индекс цены товара.
            /// </summary>
            public class PriceIndexData
            {
                /// <summary>
                /// Минимальная цена товара.
                /// </summary>
                [JsonPropertyName("min_price")]
                public decimal MinPrice { get; set; }

                /// <summary>
                /// Валюта цены.
                /// </summary>
                [JsonPropertyName("min_price_currency")]
                public string MinPriceCurrency { get; set; } = string.Empty;

                /// <summary>
                /// Значение индекса цены.
                /// </summary>
                [JsonPropertyName("price_index_value")]
                public decimal PriceIndexValue { get; set; }
            }
        }
    }
}
