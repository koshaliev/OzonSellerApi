using FluentResults;
using OzonSellerApi.Dtos.Requests.Prices;
using OzonSellerApi.Dtos.Responses.Prices;
using OzonSellerApi.Extensions;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия с ценами.
/// </summary>
public class PriceClient : BaseApiClient
{
    // TODO: 29.01.2025 - проверить десериализацию всех ответов у методов

    public PriceClient(HttpClient httpClient, ApiSettings apiSettings) : base(httpClient, apiSettings) { }

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
    /// <item><description>В случае успеха возвращает данные типа <typeparamref name="V1ProductImportPricesResponseDto"/>.</description></item>
    /// <item><description>При неудачном запросе, результат содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description></item>
    /// <item><description>При ошибки десериализации ответа, результат содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description></item>
    /// </list>
    /// </returns>
    public async Task<Result<V1ProductImportPricesResponseDto>> UpdateProductPrices(V1ProductImportPricesRequestDto productImportPricesRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/product/import/prices";
        var result = await PostRequestAsync<V1ProductImportPricesRequestDto, V1ProductImportPricesResponseDto>(endpoint, productImportPricesRequestDto, cancellationToken);
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
    /// <item><description>В случае успеха возвращает данные типа <typeparamref name="ProductInfoPricesResponseDto"/>.</description></item>
    /// <item><description>При неудачном запросе, результат содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description></item>
    /// <item><description>При ошибки десериализации ответа, тело ответа содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description></item>
    /// </list>
    /// </returns>
    public async Task<Result<V5ProductInfoPricesResponseDto>> GetProductInfoPrices(V5ProductInfoPricesRequestDto productInfoPricesRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v5/product/info/prices";
        var result = await PostRequestAsync<V5ProductInfoPricesRequestDto, V5ProductInfoPricesResponseDto>(endpoint, productInfoPricesRequestDto, cancellationToken);
        return result;
    }
}
