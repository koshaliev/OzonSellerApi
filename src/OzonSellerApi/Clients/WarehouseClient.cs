﻿using FluentResults;
using OzonSellerApi.Dtos.Requests.Warehouses;
using OzonSellerApi.Dtos.Responses.Warehouses;
using OzonSellerApi.Errors;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия со складами и методами доставки.
/// </summary>
public class WarehouseClient
{
    private readonly BaseApiClient _apiClient;

    public WarehouseClient(BaseApiClient apiClient) => _apiClient = apiClient;

    /// <summary>
    /// Список складов.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{V1WarehousesResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="V1WarehousesResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит <see cref="JsonDeserializationResultError"/> и <see cref="ApiResultError"/> с пустым <c>ResponseContent</c></item>
    /// </list>
    /// </returns>
    public async Task<Result<V1WarehousesResponseDto>> GetWarehouses(CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/warehouse/list";
        var result = await _apiClient.PostRequestWithEmptyContent<V1WarehousesResponseDto>(endpoint, cancellationToken);
        return result;
    }

    /// <summary>
    /// Список методов доставки склада.
    /// </summary>
    /// <param name="deliveryMethodsRequestDto">Тело запроса.</param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{V1DeliveryMethodsResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="V1DeliveryMethodsResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item> При ошибки десериализации ответа, результат содержит <see cref="JsonDeserializationResultError"/> и <see cref="ApiResultError"/> с пустым <c>ResponseContent</c></item>
    /// </list>
    /// </returns>
    public async Task<Result<V1DeliveryMethodsResponseDto>> GetDeliveryMethodsV1(V1DeliveryMethodsRequestDto deliveryMethodsRequestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v1/delivery-method/list";
        var result = await _apiClient.PostRequestAsync<V1DeliveryMethodsRequestDto, V1DeliveryMethodsResponseDto>(endpoint, deliveryMethodsRequestDto, cancellationToken);
        return result;
    }
}
