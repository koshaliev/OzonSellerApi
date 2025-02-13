﻿using FluentResults;
using OzonSellerApi.Dtos.Requests.Products;
using OzonSellerApi.Dtos.Responses.Products;
using OzonSellerApi.Extensions;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия с товарами.
/// </summary>
public class ProductClient : BaseApiClient
{
    public ProductClient(HttpClient httpClient, ApiSettings apiSettings) : base(httpClient, apiSettings) { }

    /// <summary>
    /// Метод для получения списка всех товаров.
    /// <para>Если вы используете фильтр по идентификатору <c>OfferId</c> или <c>ProductId</c>, остальные параметры заполнять не обязательно. За один раз вы можете использовать только одну группу идентификаторов, не больше <c>1000</c> товаров.</para>
    /// <para>Если вы не используете для отображения идентификаторы, укажите <c>Limit</c> и <c>LastId</c> в следующих запросах.</para>
    /// </summary>
    /// <remarks>Проверки на общее количество товаров в одной группе идентификаторов нет.</remarks>
    /// <param name="productListRequestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{V3ProductListResponseDto}"/>.
    /// <list type="bullet">
    /// <item><description>В случае успеха возвращает данные типа <typeparamref name="V3ProductListResponseDto"/>.</description></item>
    /// <item><description>При неудачном запросе, результат содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description></item>
    /// <item><description>При ошибки десериализации ответа, результат содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description></item>
    /// </list>
    /// </returns>
    public async Task<Result<V3ProductListResponseDto>> GetProductListV3(V3ProductListRequestDto productListRequestDto, CancellationToken cancellationToken)
    {
        string endpoint = "/v3/product/list";
        var result = await PostRequestAsync<V3ProductListRequestDto, V3ProductListResponseDto>(endpoint, productListRequestDto, cancellationToken);
        return result;
    }

    /// <summary>
    /// Метод для получения информации о товарах по их идентификаторам.
    /// </summary>
    /// <param name="productInfoListRequestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{ProductInfoListResponseDto}"/>.
    /// <list type="bullet">
    /// <item><description>В случае успеха возвращает данные типа <typeparamref name="V3ProductInfoListResponseDto"/>.</description></item>
    /// <item><description>При неудачном запросе, результат содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description></item>
    /// <item><description>При ошибки десериализации ответа, результат содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description></item>
    /// </list>
    /// </returns>
    public async Task<Result<V3ProductInfoListResponseDto>> GetProductInfoListV3(V3ProductInfoListRequestDto productInfoListRequestDto, CancellationToken cancellationToken)
    {
        string endpoint = "/v3/product/info/list";
        var result = await PostRequestAsync<V3ProductInfoListRequestDto, V3ProductInfoListResponseDto>(endpoint, productInfoListRequestDto, cancellationToken);
        return result;
    }

    /// <summary>
    /// Метод для получения описания характеристик товара.
    /// <para>Возвращает описание характеристик товаров по идентификатору и видимости. Товар можно искать по <c>OfferId</c>, <c>ProductId</c> или <c>Sku</c>.</para>
    /// </summary>
    /// <param name="v4ProductInfoAttributesRequestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{V4ProductInfoAttributesResponseDto}"/>.
    /// <list type="bullet">
    /// <item><description>В случае успеха возвращает данные типа <typeparamref name="V4ProductInfoAttributesRequestDto"/>.</description></item>
    /// <item><description>При неудачном запросе, результат содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description></item>
    /// <item><description>При ошибки десериализации ответа, результат содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description></item>
    /// </list>
    /// </returns>
    public async Task<Result<V4ProductInfoAttributesResponseDto>> GetProductInfoAttributesV4(V4ProductInfoAttributesRequestDto v4ProductInfoAttributesRequestDto, CancellationToken cancellationToken)
    {
        string endpoint = "/v4/product/info/attributes";
        var result = await PostRequestAsync<V4ProductInfoAttributesRequestDto, V4ProductInfoAttributesResponseDto>(endpoint, v4ProductInfoAttributesRequestDto, cancellationToken);
        return result;
    }
}