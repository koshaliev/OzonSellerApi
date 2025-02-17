using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Requests.Prices;

// created: 29.01.2025
public class V1ProductImportPricesRequestDto
{
    /// <summary>
    /// Информация о ценах товаров (не более 1000 элеменетов).
    /// </summary>
    [JsonPropertyName("prices")]
    public List<V1ProductImportPricesRequestDtoItem> Prices { get; set; } = [];
}

public class V1ProductImportPricesRequestDtoItem
{
    // TODO: NotImportant - перевести в ENUM?
    /// <summary>
    /// Атрибут для включения и выключения автоприменения акций:
    /// <list type="bullet">
    /// <item><c>ENABLED</c> — включить;</item>
    /// <item><c>DISABLED</c> — выключить;</item>
    /// <item><c>UNKNOWN</c> — ничего не менять, передаётся по умолчанию.</item>
    /// </list>
    /// <para>Например, если ранее вы включили автоприменение акций и не хотите выключать его, передавайте <c>UNKNOWN</c>.</para>
    /// <para>Если вы передаёте <c>ENABLED</c> в этом параметре, установите значение минимальной цены в параметре <c>MinPrice</c> (<c>min_price</c>).</para>
    /// </summary>
    [JsonPropertyName("auto_action_enabled")]
    public string AutoActionEnabled { get; set; } = "UNKNOWN";

    // TODO: NotImportant - перевести валюту в ENUM? 
    /// <summary>
    /// Валюта ваших цен. Переданное значение должно совпадать с валютой, которая установлена в настройках личного кабинета. По умолчанию передаётся <c>RUB</c> — российский рубль.
    /// <para>Например, если у вас установлена валюта взаиморасчётов юань, передавайте значение <c>CNY</c>, иначе вернётся ошибка.</para>
    /// <para>Возможные значения:</para>
    /// <list type="bullet">
    /// <item><c>RUB</c> — российский рубль</item>
    /// <item><c>BYN</c> — белорусский рубль</item>
    /// <item><c>KZT</c> — тенге</item>
    /// <item><c>EUR</c> — евро</item>
    /// <item><c>USD</c> — доллар США</item>
    /// <item><c>CNY</c> — юань</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; set; } = "RUB";

    /// <summary>
    /// Минимальная цена товара после применения акций.
    /// </summary>
    [JsonPropertyName("min_price")]
    public string MinPrice { get; set; } = string.Empty;

    /// <summary>
    /// <c>true</c>, если Ozon учитывает минимальную цену при добавлении в акции. Если ничего не передать, изменений в статусе учёта цены не будет.
    /// </summary>
    [JsonPropertyName("min_price_for_auto_actions_enabled")]
    public bool MinPriceForAutoActionsEnabled { get; set; }

    /// <summary>
    /// Идентификатор товара в системе продавца — артикул.
    /// </summary>
    [JsonPropertyName("offer_id")]
    public string OfferId { get; set; } = string.Empty;

    /// <summary>
    /// Цена до скидок (зачеркнута на карточке товара). Указывается в рублях. Разделитель дробной части — точка, до двух знаков после точки.
    /// <para>Если на товар нет скидок, укажите значение <c>0</c> в этом поле, а текущую цену передайте в поле <c>Price</c> (<c>price</c>).</para>
    /// </summary>
    [JsonPropertyName("old_price")]
    public string OldPrice { get; set; } = string.Empty;

    /// <summary>
    /// Цена товара с учётом скидок, отображается на карточке товара.
    /// <para>Если значение параметра <c>OldPrice</c> больше <c>0</c>, между <c>Price</c> и <c>OldPrice</c> должна быть определённая разница. Она зависит от значения <c>Price</c>.</para>
    /// <list type="bullet">
    /// <item>Если <c>Price <![CDATA[<]]> 400</c> рублей, то минимальная разница = <c>20</c> рублей;</item>
    /// <item>Если <c>400 <![CDATA[<=]]> Price <![CDATA[<=]]> 10000</c> рублей, то минимальная разница = <c>5</c>%;</item>
    /// <item>Если <c>Price <![CDATA[>]]> 10000</c> рублей, то минимальная разница = <c>500</c> рублей.</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("price")]
    public string Price { get; set; } = string.Empty;

    // TODO: NotImportant - перевести в ENUM?
    /// <summary>
    /// Атрибут для автоприменения стратегий цены:
    /// <list type="bullet">
    /// <item><c>ENABLED</c> — включить</item>
    /// <item><c>DISABLED</c> — выключить</item>
    /// <item><c>UNKNOWN</c> — ничего не менять, передаётся по умолчанию</item>
    /// </list>
    /// <para>Если ранее вы включили автоприменение стратегий цены и не хотите выключать его, передавайте <c>UNKNOWN</c> в следующих запросах.</para>
    /// <para>Если вы передаёте <c>ENABLED</c> в этом параметре, установите значение минимальной цены в параметре <c>MinPrice</c>.</para>
    /// <para>Если вы передаёте <c>DISABLED</c> в этом параметре, товар удаляется из стратегии.</para>
    /// </summary>
    [JsonPropertyName("price_strategy_enabled")]
    public string PriceStrategyEnabled { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор товара.
    /// </summary>
    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    /// <summary>
    /// Используйте параметр, если у обычного и эконом-товара совпадает артикул: <c>OfferId = QuantId</c>. Чтобы обновить цену:
    /// <list type="bullet">
    /// <item>обычного товара — передайте значение <c>1</c>;</item>
    /// <item>эконом-товара — передайте размер его кванта.</item>
    /// </list>
    /// <para>⚠ Если у обычного и эконом-товара разные артикулы, не передавайте параметр.</para>
    /// </summary>
    [JsonPropertyName("quant_size")]
    public long QuantSize { get; set; }

    /// <summary>
    /// Ставка НДС для товара:
    /// <list type="bullet">
    /// <item><c>0</c> — не облагается НДС</item>
    /// <item><c>0.05</c> — 5%</item>
    /// <item><c>0.07</c> — 7%</item>
    /// <item><c>0.1</c> — 10%</item>
    /// <item><c>0.2</c> — 20%</item>
    /// </list>
    /// <para>Передавайте значение ставки, актуальное на данный момент.</para>
    /// </summary>
    [JsonPropertyName("vat")]
    public string Vat { get; set; } = string.Empty;
}
