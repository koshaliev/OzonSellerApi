using OzonSellerApi.Exceptions;
using System.Net.Http.Json;
using System.Text.Json;

namespace OzonSellerApi.Clients;
/// <summary>
/// Базовый клиент для работы с Ozon Seller API.
/// <para>Конструктор устанавливает значения для заголовков запроса <c>Client-Id</c> и <c>Api-Key</c> на основе <seealso cref="ApiSettings"/>.</para>
/// </summary>
public abstract class ApiClientBase
{
    private readonly HttpClient _httpClient;

    public ApiClientBase(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("https://api-seller.ozon.ru", UriKind.Absolute);
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
    /// <typeparamref name="TResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    protected async Task<TResponseDto> PostRequestAsync<TRequestDto, TResponseDto>(string endpoint, TRequestDto? requestDto, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(endpoint, requestDto, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var requestUriString = _httpClient.BaseAddress + endpoint;
            throw new ApiFailureResponseException(response.StatusCode, response.Content, requestUriString);
        }

        var responseContent = await response.Content.ReadFromJsonAsync<TResponseDto>(cancellationToken);
        return responseContent ?? throw new NullResponseException();
    }

    protected async Task<TResponseDto> PostRequestWithEmptyContentAsync<TResponseDto>(string endpoint, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await _httpClient.PostAsync(endpoint, null, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var requestUriString = _httpClient.BaseAddress + endpoint;
            throw new ApiFailureResponseException(response.StatusCode, response.Content, requestUriString);
        }

        var responseContent = await response.Content.ReadFromJsonAsync<TResponseDto>(cancellationToken);
        return responseContent ?? throw new NullResponseException();
    }
}