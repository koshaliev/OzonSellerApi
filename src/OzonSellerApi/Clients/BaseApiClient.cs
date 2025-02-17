using FluentResults;
using Microsoft.Extensions.Options;
using OzonSellerApi.Dtos.Responses.Common;
using OzonSellerApi.Errors;
using OzonSellerApi.Extensions;
using System.Net.Http.Json;

namespace OzonSellerApi.Clients;
/// <summary>
/// Базовый клиент для работы с Ozon Seller API.
/// <para>Конструктор устанавливает значения для заголовков запроса <c>Client-Id</c> и <c>Api-Key</c> на основе <seealso cref="ApiSettings"/>.</para>
/// </summary>
public class BaseApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ApiSettings _apiSettings;

    public BaseApiClient(HttpClient httpClient, ApiSettings apiSettings)
    {
        _httpClient = httpClient;
        _apiSettings = apiSettings;

        _httpClient.BaseAddress = new Uri("https://api-seller.ozon.ru", UriKind.Absolute);
        _httpClient.DefaultRequestHeaders.Add("Client-Id", _apiSettings.ClientId);
        _httpClient.DefaultRequestHeaders.Add("Api-Key", _apiSettings.ApiKey);
    }

    public BaseApiClient(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        : this (httpClient, apiSettings.Value) { }

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
    /// <item>В случае успеха результат содержит данные типа <see cref="TResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит <see cref="JsonDeserializationResultError"/> и <see cref="ApiResultError"/> с пустым <c>ResponseContent</c></item>
    /// </list>
    /// </returns>
    public async Task<Result<TResponseDto>> PostRequestAsync<TRequestDto, TResponseDto>(string endpoint, TRequestDto? requestDto, CancellationToken cancellationToken)
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
    /// <item>В случае успеха результат содержит данные типа <see cref="TResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item> При ошибки десериализации ответа, результат содержит <see cref="JsonDeserializationResultError"/> и <see cref="ApiResultError"/> с пустым <c>ResponseContent</c></item>
    /// </list>
    /// </returns>
    public async Task<Result<TResponseDto>> PostRequestWithEmptyContent<TResponseDto>(string endpoint, CancellationToken cancellationToken)
    {
        return await PostRequestAsync<object, TResponseDto>(endpoint, default, cancellationToken);
    }
}