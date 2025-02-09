using FluentResults;
using OzonSellerApi.Dtos.Requests.Postings;
using OzonSellerApi.Dtos.Responses.Postings;
using OzonSellerApi.Extensions;

namespace OzonSellerApi.Clients;
internal class PostingClient : BaseApiClient
{
    public PostingClient(HttpClient httpClient, ApiSettings apiSettings) : base(httpClient, apiSettings)
    {
    }

    public async Task<Result<PostingFbsUnfulfilledListResponseDto>> GetFbsUnfulfilledPostings(PostingFbsUnfulfilledListRequestDto postingFbsUnfulfilledListRequestDto, CancellationToken cancellationToken)
    {
        string endpoint = "/v1/product/import/prices";
        var result = await PostRequestAsync<PostingFbsUnfulfilledListRequestDto, PostingFbsUnfulfilledListResponseDto>(endpoint, postingFbsUnfulfilledListRequestDto, cancellationToken);
        return result;
    }
}
