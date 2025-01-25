using FluentResults;
using OzonSellerApi.Errors;
using OzonSellerApi.Extensions;
using System.Net.Http.Json;

namespace OzonSellerApi.Clients;
/// <summary>
/// Базовый клиент для работы с Ozon Seller API.
/// <para>Конструктор устанавливает значения для заголовков запроса <c>Client-Id</c> и <c>Api-Key</c> на основе <seealso cref="ApiSettings"/>.</para>
/// </summary>
internal class BaseApiClient
{
    protected readonly HttpClient _httpClient;
    private readonly ApiSettings _apiSettings;

    public BaseApiClient(HttpClient httpClient, ApiSettings apiSettings)
    {
        _httpClient = httpClient;
        _apiSettings = apiSettings;

        _httpClient.BaseAddress = new Uri("https://api-seller.ozon.ru", UriKind.Absolute);
        _httpClient.DefaultRequestHeaders.Add("Client-Id", _apiSettings.ClientId);
        _httpClient.DefaultRequestHeaders.Add("Api-Key", _apiSettings.ApiKey);
    }

    /// <summary>
    /// Базовый метод для всех POST-запросов на эндроинты Ozon Seller API. 
    /// </summary>
    /// <typeparam name="TRequestDto">DTO для тела запроса.</typeparam>
    /// <typeparam name="TResponseDto">DTO для тела ответа.</typeparam>
    /// <param name="endpoint">Конечная точка.</param>
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{TResponseDto}"/>.
    /// <list type="bullet">
    ///     <item>
    ///         <description>В случае успеха возвращает данные типа <typeparamref name="TResponseDto"/>.</description>
    ///     </item>
    ///     <item>
    ///         <description>При неудачном запросе, <c>Result</c> содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description>
    ///     </item>
    ///     <item>
    ///         <description>При ошибки десериализации ответа, <c>Result</c> содержит <see cref="JsonDeserializationResultError"/> и <see cref="ApiResultError"/> с пустым <c>ResponseContent</c></description>
    ///     </item>
    /// </list>
    /// </returns>
    protected async Task<Result<TResponseDto>> PostRequestAsync<TRequestDto, TResponseDto>(string endpoint, TRequestDto? requestDto, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(endpoint, requestDto, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadFromJsonAsync<FailureResponseDto>(cancellationToken);
            return errorContent switch
            {
                null => Result.Fail<TResponseDto>(new JsonDeserializationResultError(await response.Content.ReadAsStringAsync(), response.StatusCode))
                        .WithError(new ApiResultError(null, response.StatusCode)),
                _ => Result.Fail<TResponseDto>(new ApiResultError(errorContent, response.StatusCode))
            };
        }

        var content = await response.Content.ReadFromJsonAsync<TResponseDto>(cancellationToken);
        return content switch
        {
            null => Result.Fail<TResponseDto>(new JsonDeserializationResultError(await response.Content.ReadAsStringAsync(), response.StatusCode))
                                    .WithError(new ApiResultError(null, response.StatusCode)),
            _ => Result.Ok(content),
        };
    }

    /// <summary>
    /// Базовый метод для всех POST-запросов на эндроинты Ozon Seller API (для запросов с пустым телом).
    /// </summary>
    /// <typeparam name="TRequestDto">DTO для тела запроса.</typeparam>
    /// <param name="endpoint">Конечная точка.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{TResponseDto}"/>.
    /// <list type="bullet">
    ///     <item>
    ///         <description>В случае успеха возвращает данные типа <typeparamref name="TResponseDto"/>.</description>
    ///     </item>
    ///     <item>
    ///         <description>При неудачном запросе, <c>Result</c> содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description>
    ///     </item>
    ///     <item>
    ///         <description>При ошибки десериализации ответа, <c>Result</c> содержит <see cref="JsonDeserializationResultError"/> и <see cref="ApiResultError"/> с пустым <c>ResponseContent</c></description>
    ///     </item>
    /// </list>
    /// </returns>
    protected async Task<Result<TResponseDto>> PostRequestWithEmptyContent<TResponseDto>(string endpoint, CancellationToken cancellationToken)
    {
        return await PostRequestAsync<object, TResponseDto>(endpoint, default, cancellationToken);
    }
}