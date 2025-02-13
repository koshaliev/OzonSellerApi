using FluentResults;
using OzonSellerApi.Dtos.Requests.Postings;
using OzonSellerApi.Dtos.Responses.Postings;
using OzonSellerApi.Extensions;

namespace OzonSellerApi.Clients;
public class PostingClient : BaseApiClient
{
    public PostingClient(HttpClient httpClient, ApiSettings apiSettings) : base(httpClient, apiSettings) { }

    /// <summary>
    /// Возвращает список необработанных отправлений за указанный период времени — он должен быть не больше одного года.
    /// <param name="postingFbsUnfulfilledListRequestDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// Возвращает объект типа <see cref="Result{V3PostingFbsUnfulfilledListResponseDto}"/>.
    /// <list type="bullet">
    /// <item><description>В случае успеха возвращает данные типа <typeparamref name="V3PostingFbsUnfulfilledListResponseDto"/>.</description></item>
    /// <item><description>При неудачном запросе, результат содержит ошибку <typeparamref name="ApiResultError"/>. Тело ответа хранится в <c>ResponseContent.</c></description></item>
    /// <item><description>При ошибки десериализации ответа, результат содержит <typeparamref name="JsonDeserializationResultError"/> и <typeparamref name="ApiResultError"/> с пустым <c>ResponseContent</c></description></item>
    /// </list>
    /// </returns>
    public async Task<Result<V3PostingFbsUnfulfilledListResponseDto>> GetFbsUnfulfilledPostingsV3(V3PostingFbsUnfulfilledListRequestDto postingFbsUnfulfilledListRequestDto, CancellationToken cancellationToken)
    {
        string endpoint = "/v3/posting/fbs/unfulfilled/list";
        var result = await PostRequestAsync<V3PostingFbsUnfulfilledListRequestDto, V3PostingFbsUnfulfilledListResponseDto>(endpoint, postingFbsUnfulfilledListRequestDto, cancellationToken);
        return result;
    }
}
