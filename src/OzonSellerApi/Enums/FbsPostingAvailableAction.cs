using System.Text.Json.Serialization;

namespace OzonSellerApi.Enums;
public enum FbsPostingAvailableAction
{
    /// <summary>
    /// Открыть спор
    /// </summary>
    [JsonStringEnumMemberName("arbitration")]
    Arbitration,

    /// <summary>
    /// Перевести в статус «Ожидает отгрузки»
    /// </summary>
    [JsonStringEnumMemberName("awaiting_delivery")]
    AwaitingDelivery,

    /// <summary>
    /// Начать чат с покупателем
    /// </summary>
    [JsonStringEnumMemberName("can_create_chat")]
    CanCreateChat,

    /// <summary>
    /// Отменить отправление
    /// </summary>
    [JsonStringEnumMemberName("cancel")]
    Cancel,

    /// <summary>
    /// Просмотреть по трек-номеру историю изменения статусов в личном кабинете
    /// </summary>
    [JsonStringEnumMemberName("click_track_number")]
    ClickTrackNumber,

    /// <summary>
    /// Телефон покупателя
    /// </summary>
    [JsonStringEnumMemberName("customer_phone_available")]
    CustomerPhoneAvailable,

    /// <summary>
    /// Весовые товары в отправлении
    /// </summary>
    [JsonStringEnumMemberName("has_weight_products")]
    HasWeightProducts,

    /// <summary>
    /// Скрыть регион и город покупателя в отчёте
    /// </summary>
    [JsonStringEnumMemberName("hide_region_and_city")]
    HideRegionAndCity,

    /// <summary>
    /// Получить информацию из счёта-фактуры
    /// </summary>
    [JsonStringEnumMemberName("invoice_get")]
    InvoiceGet,

    /// <summary>
    /// Создать счёт-фактуру
    /// </summary>
    [JsonStringEnumMemberName("invoice_send")]
    InvoiceSend,

    /// <summary>
    /// Отредактировать счёт-фактуру
    /// </summary>
    [JsonStringEnumMemberName("invoice_update")]
    InvoiceUpdate,

    /// <summary>
    /// Скачать большую этикетку
    /// </summary>
    [JsonStringEnumMemberName("label_download_big")]
    LabelDownloadBig,

    /// <summary>
    /// Скачать маленькую этикетку
    /// </summary>
    [JsonStringEnumMemberName("label_download_small")]
    LabelDownloadSmall,

    /// <summary>
    /// Скачать этикетку
    /// </summary>
    [JsonStringEnumMemberName("label_download")]
    LabelDownload,

    /// <summary>
    /// Перевести в статус «Условно доставлен»
    /// </summary>
    [JsonStringEnumMemberName("non_int_delivered")]
    NonIntDelivered,

    /// <summary>
    /// Перевести в статус «Доставляется»
    /// </summary>
    [JsonStringEnumMemberName("non_int_delivering")]
    NonIntDelivering,

    /// <summary>
    /// Перевести в статус «Курьер в пути»
    /// </summary>
    [JsonStringEnumMemberName("non_int_last_mile")]
    NonIntLastMile,

    /// <summary>
    /// Отменить часть товаров в отправлении
    /// </summary>
    [JsonStringEnumMemberName("product_cancel")]
    ProductCancel,

    /// <summary>
    /// Необходимо указать дату отгрузки, воспользуйтесь методом /v1/posting/cutoff/set
    /// </summary>
    [JsonStringEnumMemberName("set_cutoff")]
    SetCutoff,

    /// <summary>
    /// Изменить время доставки покупателю
    /// </summary>
    [JsonStringEnumMemberName("set_timeslot")]
    SetTimeslot,

    /// <summary>
    /// Указать или изменить трек-номер
    /// </summary>
    [JsonStringEnumMemberName("set_track_number")]
    SetTrackNumber,

    /// <summary>
    /// Отправление собирается
    /// </summary>
    [JsonStringEnumMemberName("ship_async_in_process")]
    ShipAsyncInProcess,

    /// <summary>
    /// Собрать отправление повторно после ошибки сборки
    /// </summary>
    [JsonStringEnumMemberName("ship_async_retry")]
    ShipAsyncRetry,

    /// <summary>
    /// Собрать отправление
    /// </summary>
    [JsonStringEnumMemberName("ship_async")]
    ShipAsync,

    /// <summary>
    /// Необходимо заполнить дополнительную информацию
    /// </summary>
    [JsonStringEnumMemberName("ship_with_additional_info")]
    ShipWithAdditionalInfo,

    /// <summary>
    /// Собрать отправление
    /// </summary>
    [JsonStringEnumMemberName("ship")]
    Ship,

    /// <summary>
    /// Изменить дополнительную информацию
    /// </summary>
    [JsonStringEnumMemberName("update_cis")]
    UpdateCis
}
