using FluentResults;
using Microsoft.Extensions.Logging;
using OzonSellerApi.Dtos.Requests.Stocks;
using OzonSellerApi.Dtos.Responses.Stocks;
using OzonSellerApi.Errors;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия с остатками товара на складаха.
/// </summary>
public class StockClient : BaseApiClient
{
    public StockClient(HttpClient httpClient, ILogger<StockClient> logger) : base(httpClient, logger) { }

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
    /// <param name="productStocksRequestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Объект типа <see cref="Result{V2ProductStocksResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="V2ProductStocksResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит ошибку <see cref="JsonDeserializationResultError"/>.</item>
    /// </list>
    /// </returns>
    public async Task<Result<V2ProductStocksResponseDto>> UpdateProductStocksOnWarehousesV2(V2ProductStocksRequestDto productStocksRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v2/products/stocks";
        var result = await PostRequestAsync<V2ProductStocksRequestDto, V2ProductStocksResponseDto>(endpoint, productStocksRequestDto, cancellationToken);
        return result;
    }


    /// <summary>
    /// Возвращает информацию о ĸоличестве товаров:
    /// <list type="bullet">
    /// <item>сĸольĸо единиц есть в наличии,</item>
    /// <item>сĸольĸо зарезервировано поĸупателями.</item>
    /// </list>
    /// </summary>
    /// <param name="productInfoStocksRequestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Объект типа <see cref="Result{V4ProductInfoStocksResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="V4ProductInfoStocksResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит ошибку <see cref="JsonDeserializationResultError"/>.</item>
    /// </list>
    /// </returns>
    public async Task<Result<V4ProductInfoStocksResponseDto>> GetProductInfoStocksV4(V4ProductInfoStocksRequestDto productInfoStocksRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v4/product/info/stocks";
        var result = await PostRequestAsync<V4ProductInfoStocksRequestDto, V4ProductInfoStocksResponseDto>(endpoint, productInfoStocksRequestDto, cancellationToken);
        return result;
    }


    /// <summary>
    /// Информация об остатках на складах продавца (FBS и rFBS).
    /// </summary>
    /// <param name="productInfoStocksByFbsWarehouseRequestDto">Тело запроса</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Объект типа <see cref="Result{V1ProductInfoStocksByFbsWarehouseResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="V1ProductInfoStocksByFbsWarehouseResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит ошибку <see cref="JsonDeserializationResultError"/>.</item>
    /// </list>
    /// </returns>
    public async Task<Result<V1ProductInfoStocksByFbsWarehouseResponseDto>> GetProductInfoStocksByFbsWarehouse(V1ProductInfoStocksByFbsWarehouseRequestDto productInfoStocksByFbsWarehouseRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/product/info/stocks-by-warehouse/fbs";
        var result = await PostRequestAsync<V1ProductInfoStocksByFbsWarehouseRequestDto, V1ProductInfoStocksByFbsWarehouseResponseDto>(endpoint, productInfoStocksByFbsWarehouseRequestDto, cancellationToken);
        return result;
    }
}