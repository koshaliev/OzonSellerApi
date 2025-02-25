using FluentResults;
using Microsoft.Extensions.Logging;
using OzonSellerApi.Dtos.Responses.Common;
using OzonSellerApi.Errors;
using OzonSellerApi.Extensions;
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
    private readonly ILogger _logger;

    public ApiClientBase(HttpClient httpClient, ILogger logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
    /// Возвращает объект типа <see cref="Result{TResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="TResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>Если ответ содержит null, то результат содержит ошибку <see cref="NullResponseContentError"/>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит ошибку <see cref="JsonDeserializationResultError"/>.</item>
    /// <item>При отмене операции, результат содержит ошибку <see cref="OperationCanceledError"/></item>
    /// </list>
    /// </returns>
    protected async Task<Result<TResponseDto>> PostRequestAsync<TRequestDto, TResponseDto>(string endpoint, TRequestDto? requestDto, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response;
            if (requestDto == null)
            {
                response = await _httpClient.PostAsync(endpoint, null, cancellationToken);
            }
            else
            {
                response = await _httpClient.PostAsJsonAsync(endpoint, requestDto, cancellationToken);
            }

            try
            {
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadFromJsonAsync<FailureResponseDto>(cancellationToken);
                    if (errorContent == null)
                    {
                        _logger.LogError($"Получен null при десериализации ответа неудачного запроса на {endpoint}. Код состояния: {response.StatusCode}.", endpoint, response.StatusCode);
                        return Result.Fail<TResponseDto>(new NullResponseContentError(response.StatusCode));
                    }
                    else
                    {
                        _logger.LogWarning($"Ошибка при вызове Ozon Seller API на {endpoint}. Код состояния: {response.StatusCode}. Тело ответа: {errorContent}", endpoint, response.StatusCode, errorContent);
                        return Result.Fail<TResponseDto>(new ApiResultError(errorContent, response.StatusCode));
                    }
                }

                var content = await response.Content.ReadFromJsonAsync<TResponseDto>(cancellationToken);
                if (content == null)
                {
                    _logger.LogError($"Получен null при десериализации ответа удачного запроса на {endpoint}. Код состояния: {response.StatusCode}.", endpoint, response.StatusCode);
                    return Result.Fail<TResponseDto>(new NullResponseContentError(response.StatusCode));
                }
                else
                {
                    return Result.Ok(content);
                }
            }
            catch (JsonException ex)
            {
                string content = await response.Content.ReadAsStringAsync();
                _logger.LogError(ex, $"Ошибка сериализации ответа. Код состояния: {response.StatusCode}. Тело ответа: {content}", response.StatusCode, content);
                return Result.Fail<TResponseDto>(new JsonDeserializationResultError(ex.Message, content, response.StatusCode));
            }
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogError(ex, "Передан аргумент со значением null.");
            return Result.Fail($"Передан аргумент со значением null: {ex.Message}");
        }
        catch (OperationCanceledException ex) when (cancellationToken.IsCancellationRequested)
        {
            _logger.LogWarning(ex, $"Запрос на {endpoint} был отменен.", endpoint);
            return Result.Fail(new OperationCanceledError($"Запрос на {endpoint} был отменен.", ex));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Непредвиденная ошибка при запросе на {endpoint}.", endpoint);
            return Result.Fail<TResponseDto>(new Error($"Непредвиденное исключение. Сообщение исключения: {ex.Message}").CausedBy(ex));
        }
    }

    protected async Task<Result<TResponseDto>> PostRequestWithEmptyContentAsync<TResponseDto>(string endpoint, CancellationToken cancellationToken)
    {
        return await PostRequestAsync<object, TResponseDto>(endpoint, null, cancellationToken);
    }
}