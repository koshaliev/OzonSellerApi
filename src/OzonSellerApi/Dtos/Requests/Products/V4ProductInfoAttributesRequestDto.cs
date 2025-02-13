using OzonSellerApi.Enums;
using System.Text.Json.Serialization;

namespace OzonSellerApi.Dtos.Requests.Products;

// created: 13.02.2025
public class V4ProductInfoAttributesRequestDto
{
    /// <summary>
    /// Фильтр по товарам.
    /// </summary>
    [JsonPropertyName("filter")]
    public required V4ProductInfoAttributesRequestDtoFilter Filter { get; set; }

    /// <summary>
    /// Идентификатор последнего значения на странице. Оставьте это поле пустым при выполнении первого запроса.
    /// <para>Чтобы получить следующие значения, укажите <see cref="LastId"/> из ответа предыдущего запроса.</para>
    /// </summary>
    [JsonPropertyName("last_id")]
    public string LastId { get; set; } = string.Empty;

    /// <summary>
    /// Количество значений на странице (от 1 до 1000).
    /// </summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    /// <summary>
    /// Параметр, по которому товары будут отсортированы.
    /// </summary>
    [JsonPropertyName("sort_by")]
    public string SortBy { get; set; } = string.Empty;

    /// <summary>
    /// Направление сортировки:
    /// <list type="bullet">
    /// <item><description><c>asc</c> — по возрастанию</description></item>
    /// <item><description><c>desc</c> — по убыванию</description></item>
    /// </list>
    /// </summary>
    [JsonPropertyName("sort_dir")]
    public string SortDir { get; set; } = string.Empty;
}

public class V4ProductInfoAttributesRequestDtoFilter
{
    /// <summary>
    /// Фильтр по параметру <see cref="OfferId"/>. Можно передавать список значений.
    /// </summary>
    public List<string> OfferId { get; set; } = [];

    /// <summary>
    /// Фильтр по параметру <see cref="ProductId"/>. Можно передавать список значений.
    /// </summary>
    public List<long> ProductId { get; set; } = [];

    /// <summary>
    /// Фильтр по параметру <see cref="Sku"/>. Можно передавать список значений.
    /// </summary>
    public List<long> Sku { get; set; } = [];

    /// <summary>
    /// Фильтр по видимости товара.
    /// </summary>
    /// <remarks>Значение по умолчанию: <see cref="ProductVisibility.All"/>.</remarks>
    public ProductVisibility Visibility { get; set; }
}
