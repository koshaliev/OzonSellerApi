using OzonSellerApi.Exceptions;
using System.Text.Json;
using OzonSellerApi.Dtos.Requests.Warehouses;
using OzonSellerApi.Dtos.Responses.Warehouses;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия со складами и методами доставки.
/// </summary>
public class WarehouseClient : ApiClientBase
{
    public WarehouseClient(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Список складов.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// <see cref="V1WarehousesResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V1WarehousesResponseDto> GetWarehousesV1(CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/warehouse/list";
        var result = await PostRequestWithEmptyContentAsync<V1WarehousesResponseDto>(endpoint, cancellationToken);  
        return result;
    }

    /// <summary>
    /// Список методов доставки склада.
    /// </summary>
    /// <param name="requestDto">Тело запроса.</param>
    /// <returns>
    /// <see cref="V1DeliveryMethodsResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V1DeliveryMethodsResponseDto> GetDeliveryMethodsV1(V1DeliveryMethodsRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/delivery-method/list";
        var result = await PostRequestAsync<V1DeliveryMethodsRequestDto, V1DeliveryMethodsResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }
}
