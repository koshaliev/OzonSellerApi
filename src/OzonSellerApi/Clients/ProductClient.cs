using FluentResults;
using OzonSellerApi.Dtos.Requests.Products;
using OzonSellerApi.Dtos.Responses.Products;
using OzonSellerApi.Extensions;

namespace OzonSellerApi.Clients;
/// <summary>
/// Клиент для взаимодействия с товарами.
/// </summary>
public class ProductClient : BaseApiClient
{
    public ProductClient(HttpClient httpClient, ApiSettings apiSettings) : base(httpClient, apiSettings)
    {
    }

    /// <summary>
    /// Метод для получения списка всех товаров.
    /// <para>Если вы используете фильтр по идентификатору <c>OfferId</c> или <c>ProductId</c>, остальные параметры заполнять не обязательно. За один раз вы можете использовать только одну группу идентификаторов, не больше <c>1000</c> товаров.</para>
    /// <para>Если вы не используете для отображения идентификаторы, укажите <c>Limit</c> и <c>LastId</c> в следующих запросах.</para>
    /// </summary>
    /// <remarks>Проверки на общее количество товаров в одной группе идентификаторов нет.</remarks>
    /// <param name="productListRequestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{ProductListResponseDto}"/>.
    /// <list type="bullet">
    ///     <item>
    ///         <description>В случае успеха возвращает данные типа <typeparamref name="ProductListResponseDto"/>.</description>
    ///     </item>
    ///     <item>
    ///         <description>При неудачном запросе, <c>PostingFbsUnfulfilledListResponseResult</c> содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description>
    ///     </item>
    ///     <item>
    ///         <description>При ошибки десериализации ответа, <c>PostingFbsUnfulfilledListResponseResult</c> содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description>
    ///     </item>
    /// </list>
    /// </returns>
    public async Task<Result<ProductListResponseDto>> GetProductList(ProductListRequestDto productListRequestDto, CancellationToken cancellationToken)
    {
        string endpoint = "/v3/product/list";
        var result = await PostRequestAsync<ProductListRequestDto, ProductListResponseDto>(endpoint, productListRequestDto, cancellationToken);

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
    ///     <item>
    ///         <description>В случае успеха возвращает данные типа <typeparamref name="ProductInfoListResponseDto"/>.</description>
    ///     </item>
    ///     <item>
    ///         <description>При неудачном запросе, <c>PostingFbsUnfulfilledListResponseResult</c> содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description>
    ///     </item>
    ///     <item>
    ///         <description>При ошибки десериализации ответа, <c>PostingFbsUnfulfilledListResponseResult</c> содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description>
    ///     </item>
    /// </list>
    /// </returns>
    public async Task<Result<ProductInfoListResponseDto>> GetProductInfoList(ProductInfoListRequestDto productInfoListRequestDto, CancellationToken cancellationToken)
    {
        string endpoint = "/v3/product/info/list";
        var result = await PostRequestAsync<ProductInfoListRequestDto, ProductInfoListResponseDto>(endpoint, productInfoListRequestDto, cancellationToken);

        return result;
    }
}