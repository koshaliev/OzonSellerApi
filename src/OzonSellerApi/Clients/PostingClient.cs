using OzonSellerApi.Exceptions;
using System.Text.Json;
using OzonSellerApi.Dtos.Requests.Postings;
using OzonSellerApi.Dtos.Responses.Postings;

namespace OzonSellerApi.Clients;
public class PostingClient : ApiClientBase
{
    public PostingClient(HttpClient httpClient) : base(httpClient) { }

    /// <summary>
    /// Возвращает список необработанных отправлений за указанный период времени — он должен быть не больше одного года.
    /// <param name="requestDto">Тело запроса.</param>
    /// <param name="cancellationToken"></param>
    /// </summary>
    /// <returns>
    /// <see cref="V3PostingFbsUnfulfilledListResponseDto"/>
    /// </returns>
    /// <exception cref="ApiFailureResponseException">Возникает при неудачном запросе.</exception>
    /// <exception cref="NullResponseException">Может возникнуть, если Тела ответа содержит null.</exception>
    /// <exception cref="JsonException"/>
    /// <exception cref="ArgumentNullException">Может возникнуть при сериализации <c>Тела запроса</c>.</exception>
    /// <exception cref="OperationCanceledException"/>
    public async Task<V3PostingFbsUnfulfilledListResponseDto> GetFbsUnfulfilledPostingsV3(V3PostingFbsUnfulfilledListRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        string endpoint = "/v3/posting/fbs/unfulfilled/list";
        var result = await PostRequestAsync<V3PostingFbsUnfulfilledListRequestDto, V3PostingFbsUnfulfilledListResponseDto>(endpoint, requestDto, cancellationToken);
        return result;
    }
}
