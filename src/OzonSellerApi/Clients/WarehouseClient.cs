using FluentResults;
using OzonSellerApi.Dto.Requests.Warehouses;
using OzonSellerApi.Dto.Responses.Warehouses;
using OzonSellerApi.Extensions;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия со складами и методами доставки.
/// </summary>
internal class WarehouseClient : BaseApiClient
{
    public WarehouseClient(HttpClient httpClient, ApiSettings apiSettings) : base(httpClient, apiSettings)
    {
    }

    /// <summary>
    /// Список складов.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{WarehousesResponseDto}"/>.
    /// <list type="bullet">
    ///     <item>
    ///         <description>В случае успеха возвращает данные типа <typeparamref name="WarehousesResponseDto"/>.</description>
    ///     </item>
    ///     <item>
    ///         <description>При неудачном запросе, <c>Result</c> содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description>
    ///     </item>
    ///     <item>
    ///         <description>При ошибки десериализации ответа, <c>Result</c> содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description>
    ///     </item>
    /// </list>
    /// </returns>
    public async Task<Result<WarehousesResponseDto>> GetWarehouses(CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/warehouse/list";
        var result = await PostRequestWithEmptyContent<WarehousesResponseDto>(endpoint, cancellationToken);
        return result;
    }

    /// <summary>
    /// Список методов доставки склада.
    /// </summary>
    /// <param name="deliveryMethodsRequestDto">Тело запроса.</param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{WarehousesResponseDto}"/>.
    /// <list type="bullet">
    ///     <item>
    ///         <description>В случае успеха возвращает данные типа <typeparamref name="WarehousesResponseDto"/>.</description>
    ///     </item>
    ///     <item>
    ///         <description>При неудачном запросе, <c>Result</c> содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description>
    ///     </item>
    ///     <item>
    ///         <description>При ошибки десериализации ответа, <c>Result</c> содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description>
    ///     </item>
    /// </list>
    /// </returns>
    public async Task<Result<DeliveryMethodsResponseDto>> GetDeliveryMethods(DeliveryMethodsRequestDto deliveryMethodsRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/delivery-method/list";
        var result = await PostRequestAsync<DeliveryMethodsRequestDto, DeliveryMethodsResponseDto>(endpoint, deliveryMethodsRequestDto, cancellationToken);
        return result;
    }
}
