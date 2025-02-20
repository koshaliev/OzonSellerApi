using FluentResults;
using Microsoft.Extensions.Logging;
using OzonSellerApi.Dtos.Requests.Postings;
using OzonSellerApi.Dtos.Responses.Postings;
using OzonSellerApi.Errors;

namespace OzonSellerApi.Clients;
public class PostingClient : BaseApiClient
{
    public PostingClient(HttpClient httpClient, ILogger<PostingClient> logger) : base(httpClient, logger) { }

    /// <summary>
    /// Возвращает список необработанных отправлений за указанный период времени — он должен быть не больше одного года.
    /// <param name="postingFbsUnfulfilledListRequestDto"></param>
    /// <param name="cancellationToken"></param>
    /// </summary>
    /// <returns>
    /// <see cref="Result{T}"/>
    /// <para></para>
    /// Возвращает объект типа <see cref="Result{V3PostingFbsUnfulfilledListResponseDto}"/>.
    /// <list type="bullet">
    /// <item>В случае успеха результат содержит данные типа <see cref="V3PostingFbsUnfulfilledListResponseDto"/>.</item>
    /// <item>При неудачном запросе, результат содержит ошибку <see cref="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent</c>.</item>
    /// <item>При ошибки десериализации ответа, результат содержит ошибку <see cref="JsonDeserializationResultError"/>.</item>
    /// </list>
    /// </returns>
    public async Task<Result<V3PostingFbsUnfulfilledListResponseDto>> GetFbsUnfulfilledPostingsV3(V3PostingFbsUnfulfilledListRequestDto postingFbsUnfulfilledListRequestDto, CancellationToken cancellationToken)
    {
        string endpoint = "/v3/posting/fbs/unfulfilled/list";
        var result = await PostRequestAsync<V3PostingFbsUnfulfilledListRequestDto, V3PostingFbsUnfulfilledListResponseDto>(endpoint, postingFbsUnfulfilledListRequestDto, cancellationToken);
        return result;
    }
}
