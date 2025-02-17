using FluentResults;
using OzonSellerApi.Dtos.Requests.Prices;
using OzonSellerApi.Dtos.Responses.Prices;
using OzonSellerApi.Errors;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия с ценами.
/// </summary>
public class PriceClient
{
    private readonly BaseApiClient _apiClient;

    public PriceClient(BaseApiClient apiClient) => _apiClient = apiClient;

    /// <summary>
    /// Позволяет изменить цену одного или нескольких товаров. Цену каждого товара можно обновлять не больше 10 раз в час. Чтобы сбросить <c>OldPrice</c> (<c>old_price</c>), поставьте <c>0</c> у этого параметра.
    /// <para>Если у товара установлена минимальная цена и включено автоприменение в акции, отключите его и обновите минимальную цену, иначе вернётся ошибка <c>action_price_enabled_min_price_missing</c>.</para>
    /// </summary>
    /// <remarks>За раз можно обновить остатки у 1000 товаров (ограничение Ozon Seller API).
    /// </remarks>
    /// <param name=""></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{V1ProductImportPricesResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="V1ProductImportPricesResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит <see cref="JsonDeserializationResultError"/> и <see cref="ApiResultError"/> с пустым <c>ResponseContent</c></item>
    /// </list>
    /// </returns>
    public async Task<Result<V1ProductImportPricesResponseDto>> UpdateProductPrices(V1ProductImportPricesRequestDto productImportPricesRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/product/import/prices";
        var result = await _apiClient.PostRequestAsync<V1ProductImportPricesRequestDto, V1ProductImportPricesResponseDto>(endpoint, productImportPricesRequestDto, cancellationToken);
        return result;
    }

    // В запросе вы можете передать максимум 1000 товаров.
    /// <summary>
    /// Получить информацию о цене товара.
    /// </summary>
    /// <param name="productInfoPricesRequestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{ProductInfoPricesResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="ProductInfoPricesResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит <see cref="JsonDeserializationResultError"/> и <see cref="ApiResultError"/> с пустым <c>ResponseContent</c></item>
    /// </list>
    /// </returns>
    public async Task<Result<V5ProductInfoPricesResponseDto>> GetProductInfoPrices(V5ProductInfoPricesRequestDto productInfoPricesRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v5/product/info/prices";
        var result = await _apiClient.PostRequestAsync<V5ProductInfoPricesRequestDto, V5ProductInfoPricesResponseDto>(endpoint, productInfoPricesRequestDto, cancellationToken);
        return result;
    }
}
