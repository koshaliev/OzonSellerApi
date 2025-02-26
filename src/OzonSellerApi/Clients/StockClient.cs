using OzonSellerApi.Exceptions;
using System.Text.Json;
using OzonSellerApi.Dtos.Requests.Stocks;
using OzonSellerApi.Dtos.Responses.Stocks;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия с остатками товара на складаха.
/// </summary>
public class StockClient : ApiClientBase
{
    public StockClient(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Позволяет изменить информацию о количестве товара в наличии.
    /// </summary>
    /// <remarks>
    /// <para>⚠ Переданный остаток учитывает зарезервированные товары. Перед обновлением остатков проверьте количество зарезервированных товаров с помощью метода <see cref="Clients.StockClient.GetProductInfoStocksByFbsWarehouse(V1ProductInfoStocksByFbsWarehouseRequestDto, CancellationToken)"/> (/v1/product/info/stocks-by-warehouse/fbs).</para>
    /// <para>За один запрос можно изменить наличие для <c>100</c> товаров. С одного аккаунта продавца можно отправить до <c>80</c> запросов в минуту.</para>
    /// <para>Обновлять остатки товара на одном складе можно только <c>1</c> раз в <c>30</c>> секунд, иначе в ответе будет ошибка <c>TOO_MANY_REQUESTS</c>.</para>
    /// <para>Вы можете задать наличие товара только после того, как его статус сменится на price_sent.</para>
    /// <para>⚠ Остатки крупногабаритных товаров можно обновлять только на предназначенных для них складах.</para>
    /// </remarks>
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V2ProductStocksResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V2ProductStocksResponseDto> UpdateProductStocksOnWarehousesV2(V2ProductStocksRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v2/products/stocks";
        var result = await PostRequestAsync<V2ProductStocksRequestDto, V2ProductStocksResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }


    /// <summary>
    /// Возвращает информацию о ĸоличестве товаров:
    /// <list type="bullet">
    /// <item>сĸольĸо единиц есть в наличии,</item>
    /// <item>сĸольĸо зарезервировано поĸупателями.</item>
    /// </list>
    /// </summary>
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V4ProductInfoStocksResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V4ProductInfoStocksResponseDto> GetProductInfoStocksV4(V4ProductInfoStocksRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v4/product/info/stocks";
        var result = await PostRequestAsync<V4ProductInfoStocksRequestDto, V4ProductInfoStocksResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }


    /// <summary>
    /// Информация об остатках на складах продавца (FBS и rFBS).
    /// </summary>
    /// <param name="requestDto">Тело запроса</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V1ProductInfoStocksByFbsWarehouseResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V1ProductInfoStocksByFbsWarehouseResponseDto> GetProductInfoStocksByFbsWarehouse(V1ProductInfoStocksByFbsWarehouseRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/product/info/stocks-by-warehouse/fbs";
        var result = await PostRequestAsync<V1ProductInfoStocksByFbsWarehouseRequestDto, V1ProductInfoStocksByFbsWarehouseResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }
}