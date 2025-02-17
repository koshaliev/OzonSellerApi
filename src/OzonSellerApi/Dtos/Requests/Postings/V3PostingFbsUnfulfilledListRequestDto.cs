using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Requests.Postings;

// created: 29.01.2025
public class V3PostingFbsUnfulfilledListRequestDto
{
    /// <summary>
    /// Направление сортировки:
    /// <list type="bullet">
    /// <item><c>asc</c> — по возрастанию</item>
    /// <item><c>desc</c> — по убыванию</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("dir")]
    public string Dir { get; set; } = string.Empty;

    /// <summary>
    /// Фильтр запроса.
    /// <para>Используйте фильтр либо по времени сборки — cutoff, либо по дате передачи отправления в доставку — delivering_date.Если использовать их вместе, в ответе вернётся ошибка.</para>
    /// <para>Чтобы использовать фильтр по времени сборки, заполните поля cutoff_from и cutoff_to.</para>
    /// <para>Чтобы использовать фильтр по дате передачи отправления в доставку, заполните поля <c>DeliveringDateFrom</c> и <c>DeliveringDateTo</c>.</para>
    /// </summary>
    [JsonPropertyName("filter")]
    public required V3PostingFbsUnfulfilledListRequestDtoFilter Filter { get; set; }

    /// <summary>
    /// Количество значений в ответе: минимум — 1, максимум — 1000.
    /// </summary>
    [JsonPropertyName("limit")]
    public long Limit { get; set; }

    /// <summary>
    /// Количество элементов, которое будет пропущено в ответе. Например, если <c>Offset</c> = 10, то ответ начнётся с 11-го найденного элемента.
    /// </summary>
    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    /// <summary>
    /// Дополнительные поля, которые нужно добавить в ответ.
    /// </summary>
    [JsonPropertyName("with")]
    public required V3PostingFbsUnfulfilledListRequestDtoWithData With { get; set; }
}

public class V3PostingFbsUnfulfilledListRequestDtoFilter
{
    /// <summary>
    /// Фильтр по времени, до которого продавцу нужно собрать заказ. Начало периода.
    /// <para>Формат: YYYY-MM-DDThh:mm:ss.mcsZ. Пример: 2020-03-18T07:34:50.359Z.</para>
    /// </summary>
    [JsonPropertyName("cutoff_from")]
    public DateTimeOffset CutoffFrom { get; set; }

    /// <summary>
    /// Фильтр по времени, до которого продавцу нужно собрать заказ. Конец периода.
    /// <para>Формат: YYYY-MM-DDThh:mm:ss.mcsZ. Пример: 2020-03-18T07:34:50.359Z</para>
    /// </summary>
    [JsonPropertyName("cutoff_to")]
    public DateTimeOffset CutoffTo { get; set; }

    /// <summary>
    /// Минимальная дата передачи отправления в доставку.
    /// </summary>
    [JsonPropertyName("delivering_date_from")]
    public DateTimeOffset DeliveringDateFrom { get; set; }

    /// <summary>
    /// Максимальная дата передачи отправления в доставку.
    /// </summary>
    [JsonPropertyName("delivering_date_to")]
    public DateTimeOffset DeliveringDateTo { get; set; }

    /// <summary>
    /// Идентификатор способа доставки.
    /// </summary>
    [JsonPropertyName("delivery_method_id")]
    public List<long> DeliveryMethodId { get; set; } = [];

    /// <summary>
    /// Укажите true, чтобы получить только отправления квантов.
    /// <para>По умолчанию — false, в ответе придут все отправления.</para>
    /// </summary>
    [JsonPropertyName("is_quantum")]
    public bool IsQuantum { get; set; }

    /// <summary>
    /// Идентификатор службы доставки.
    /// </summary>
    [JsonPropertyName("provider_id")]
    public List<long> ProviderId { get; set; } = [];

    /// <summary>
    /// Статус отправления:
    /// <list type="bullet">
    /// <item><c>acceptance_in_progress</c> — идёт приёмка</item>
    /// <item><c>awaiting_approve</c> — ожидает подтверждения</item>
    /// <item><c>awaiting_packaging</c> — ожидает упаковки</item>
    /// <item><c>awaiting_registration</c> — ожидает регистрации</item>
    /// <item><c>awaiting_deliver</c> — ожидает отгрузки</item>
    /// <item><c>arbitration</c> — арбитраж</item>
    /// <item><c>client_arbitration</c> — клиентский арбитраж доставки</item>
    /// <item><c>delivering</c> — доставляется</item>
    /// <item><c>driver_pickup</c> — у водителя</item>
    /// <item><c>not_accepted</c> — не принят на сортировочном центре</item>
    /// </list>
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор склада.
    /// </summary>
    [JsonPropertyName("warehouse_id")]
    public List<long> WarehouseId { get; set; } = [];
}

public class V3PostingFbsUnfulfilledListRequestDtoWithData
{
    /// <summary>
    /// Добавить в ответ данные аналитики.
    /// </summary>
    [JsonPropertyName("analytics_data")]
    public bool AnalyticsData { get; set; }

    /// <summary>
    /// Добавить в ответ штрихкоды отправления.
    /// </summary>
    [JsonPropertyName("barcodes")]
    public bool Barcodes { get; set; }

    /// <summary>
    /// Добавить в ответ финансовые данные.
    /// </summary>
    [JsonPropertyName("financial_data")]
    public bool FinancialData { get; set; }

    /// <summary>
    /// Выполнить транслитерацию возвращаемых значений.
    /// </summary>
    [JsonPropertyName("translit")]
    public bool Translit { get; set; }
}
