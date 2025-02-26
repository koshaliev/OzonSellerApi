using OzonSellerApi.Exceptions;
using System.Text.Json;
using OzonSellerApi.Dtos.Requests.Products;
using OzonSellerApi.Dtos.Responses.Products;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия с товарами.
/// </summary>

public class ProductClient : ApiClientBase
{
    public ProductClient(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Метод для получения списка всех товаров.
    /// <para>Если вы используете фильтр по идентификатору <c>OfferId</c> или <c>ProductId</c>, остальные параметры заполнять не обязательно. За один раз вы можете использовать только одну группу идентификаторов, не больше <c>1000</c> товаров.</para>
    /// <para>Если вы не используете для отображения идентификаторы, укажите <c>Limit</c> и <c>LastId</c> в следующих запросах.</para>
    /// </summary>
    /// <remarks>⚠ Проверки на общее количество товаров в одной группе идентификаторов нет.</remarks>
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V3ProductListResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V3ProductListResponseDto> GetProductListV3(V3ProductListRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v3/product/list";
        var result = await PostRequestAsync<V3ProductListRequestDto, V3ProductListResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }

    /// <summary>
    /// Метод для получения информации о товарах по их идентификаторам.
    /// </summary>
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V3ProductInfoListResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V3ProductInfoListResponseDto> GetProductInfoListV3(V3ProductInfoListRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v3/product/info/list";
        var result = await PostRequestAsync<V3ProductInfoListRequestDto, V3ProductInfoListResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }

    /// <summary>
    /// Метод для получения описания характеристик товара.
    /// <para>Возвращает описание характеристик товаров по идентификатору и видимости. Товар можно искать по <c>OfferId</c>, <c>ProductId</c> или <c>Sku</c>.</para>
    /// </summary>
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V4ProductInfoAttributesResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V4ProductInfoAttributesResponseDto> GetProductInfoAttributesV4(V4ProductInfoAttributesRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v4/product/info/attributes";
        var result = await PostRequestAsync<V4ProductInfoAttributesRequestDto, V4ProductInfoAttributesResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }
}