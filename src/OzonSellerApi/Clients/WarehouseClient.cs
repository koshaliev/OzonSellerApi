using FluentResults;
using OzonSellerApi.Dtos.Requests.Warehouses;
using OzonSellerApi.Dtos.Responses.Warehouses;
using OzonSellerApi.Extensions;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия со складами и методами доставки.
/// </summary>
public class WarehouseClient : BaseApiClient
{
    public WarehouseClient(HttpClient httpClient, ApiSettings apiSettings) : base(httpClient, apiSettings) { }

    /// <summary>
    /// Список складов.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{V1WarehousesResponseDto}"/>.
    /// <list type="bullet">
    /// <item><description>В случае успеха возвращает данные типа <typeparamref name="V1WarehousesResponseDto"/>.</description></item>
    /// <item><description>При неудачном запросе, результат содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description></item>
    /// <item><description>При ошибки десериализации ответа, результат содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description></item>
    /// </list>
    /// </returns>
    public async Task<Result<V1WarehousesResponseDto>> GetWarehouses(CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/warehouse/list";
        var result = await PostRequestWithEmptyContent<V1WarehousesResponseDto>(endpoint, cancellationToken);
        return result;
    }

    /// <summary>
    /// Список методов доставки склада.
    /// </summary>
    /// <param name="deliveryMethodsRequestDto">Тело запроса.</param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{V1DeliveryMethodsResponseDto}"/>.
    /// <list type="bullet">
    /// <item><description>В случае успеха возвращает данные типа <typeparamref name="V1DeliveryMethodsResponseDto"/>.</description></item>
    /// <item><description>При неудачном запросе, результат содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description></item>
    /// <item> <description>При ошибки десериализации ответа, результат содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description></item>
    /// </list>
    /// </returns>
    public async Task<Result<V1DeliveryMethodsResponseDto>> GetDeliveryMethodsV1(V1DeliveryMethodsRequestDto deliveryMethodsRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/delivery-method/list";
        var result = await PostRequestAsync<V1DeliveryMethodsRequestDto, V1DeliveryMethodsResponseDto>(endpoint, deliveryMethodsRequestDto, cancellationToken);
        return result;
    }
}
