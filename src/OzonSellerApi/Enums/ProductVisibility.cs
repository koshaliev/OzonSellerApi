using System.Text.Json.Serialization;

namespace OzonSellerApi.Enums;

/// <summary>
/// Статусы товаров.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<ProductVisibility>))]
public enum ProductVisibility
{
    /// <summary>
    /// Все товары.
    /// </summary>
    [JsonStringEnumMemberName("ALL")]
    All,

    /// <summary>
    /// Товары, которые видны покупателям.
    /// </summary>
    [JsonStringEnumMemberName("VISIBLE")]
    Visible,

    /// <summary>
    /// Товары, которые не видны покупателям.
    /// </summary>
    [JsonStringEnumMemberName("INVISIBLE")]
    Invisible,

    /// <summary>
    /// Товары, у которых не указано наличие.
    /// </summary>
    [JsonStringEnumMemberName("EMPTY_STOCK")]
    EmptyStock,

    /// <summary>
    /// Товары, которые не прошли модерацию.
    /// </summary>
    [JsonStringEnumMemberName("NOT_MODERATED")]
    NotModerated,

    /// <summary>
    /// Товары, которые прошли модерацию.
    /// </summary>
    [JsonStringEnumMemberName("MODERATED")]
    Moderated,

    /// <summary>
    /// Товары, которые видны покупателям, но недоступны к покупке.
    /// </summary>
    [JsonStringEnumMemberName("DISABLED")]
    Disabled,

    /// <summary>
    /// Товары, создание которых завершилось ошибкой.
    /// </summary>
    [JsonStringEnumMemberName("STATE_FAILED")]
    StateFailed,

    /// <summary>
    /// Товары, готовые к поставке.
    /// </summary>
    [JsonStringEnumMemberName("READY_TO_SUPPLY")]
    ReadyToSupply,

    /// <summary>
    /// Товары, которые проходят проверку валидатором на премодерации.
    /// </summary>
    [JsonStringEnumMemberName("VALIDATION_STATE_PENDING")]
    ValidationStatePending,

    /// <summary>
    /// Товары, которые не прошли проверку валидатором на премодерации.
    /// </summary>
    [JsonStringEnumMemberName("VALIDATION_STATE_FAIL")]
    ValidationStateFail,

    /// <summary>
    /// Товары, которые прошли проверку валидатором на премодерации.
    /// </summary>
    [JsonStringEnumMemberName("VALIDATION_STATE_SUCCESS")]
    ValidationStateSuccess,

    /// <summary>
    /// Товары, готовые к продаже.
    /// </summary>
    [JsonStringEnumMemberName("TO_SUPPLY")]
    ToSupply,

    /// <summary>
    /// Товары в продаже.
    /// </summary>
    [JsonStringEnumMemberName("IN_SALE")]
    InSale,

    /// <summary>
    /// Товары, скрытые от покупателей.
    /// </summary>
    [JsonStringEnumMemberName("REMOVED_FROM_SALE")]
    RemovedFromSale,

    /// <summary>
    /// Товары с завышенной ценой.
    /// </summary>
    [JsonStringEnumMemberName("OVERPRICED")]
    Overpriced,

    /// <summary>
    /// Товары со слишком завышенной ценой.
    /// </summary>
    [JsonStringEnumMemberName("CRITICALLY_OVERPRICED")]
    CriticallyOverpriced,

    /// <summary>
    /// Товары без штрихкода.
    /// </summary>
    [JsonStringEnumMemberName("EMPTY_BARCODE")]
    EmptyBarcode,

    /// <summary>
    /// Товары со штрихкодом.
    /// </summary>
    [JsonStringEnumMemberName("BARCODE_EXISTS")]
    BarcodeExists,

    /// <summary>
    /// Товары на карантине после изменения цены более чем на 50%.
    /// </summary>
    [JsonStringEnumMemberName("QUARANTINE")]
    Quarantine,

    /// <summary>
    /// Товары в архиве.
    /// </summary>
    [JsonStringEnumMemberName("ARCHIVED")]
    Archived,

    /// <summary>
    /// Товары в продаже со стоимостью выше, чем у конкурентов.
    /// </summary>
    [JsonStringEnumMemberName("OVERPRICED_WITH_STOCK")]
    OverpricedWithStock,

    /// <summary>
    /// Товары в продаже с пустым или неполным описанием.
    /// </summary>
    [JsonStringEnumMemberName("PARTIAL_APPROVED")]
    PartialApproved
}
