using OzonSellerApi.Exceptions;
using System.Text.Json;
using OzonSellerApi.Dtos.Requests.Prices;
using OzonSellerApi.Dtos.Responses.Prices;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия с ценами.
/// </summary>
public class PriceClient : ApiClientBase
{
    public PriceClient(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Позволяет изменить цену одного или нескольких товаров. Цену каждого товара можно обновлять не больше 10 раз в час. Чтобы сбросить <c>OldPrice</c> (<c>old_price</c>), поставьте <c>0</c> у этого параметра.
    /// <para>Если у товара установлена минимальная цена и включено автоприменение в акции, отключите его и обновите минимальную цену, иначе вернётся ошибка <c>action_price_enabled_min_price_missing</c>.</para>
    /// </summary>
    /// <remarks>⚠ За раз можно обновить остатки у 1000 товаров (ограничение Ozon Seller API).</remarks>
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V1ProductImportPricesResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V1ProductImportPricesResponseDto> UpdateProductPrices(V1ProductImportPricesRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/product/import/prices";
        var result = await PostRequestAsync<V1ProductImportPricesRequestDto, V1ProductImportPricesResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }

    // В запросе вы можете передать максимум 1000 товаров.
    /// <summary>
    /// Получить информацию о цене товара.
    /// </summary>
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V5ProductInfoPricesResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V5ProductInfoPricesResponseDto> GetProductInfoPrices(V5ProductInfoPricesRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v5/product/info/prices";
        var result = await PostRequestAsync<V5ProductInfoPricesRequestDto, V5ProductInfoPricesResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }
}
