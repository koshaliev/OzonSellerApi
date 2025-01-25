using FluentResults;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace OzonSellerApi.Errors;
public class ApiResultError : Error
{
    public HttpStatusCode StatusCode { get; set; }

    [MemberNotNullWhen(false, nameof(IsContentNull))]
    public FailureResponseDto? ResponseContent { get; set; }
    
    public bool IsContentNull => ResponseContent == null;

    public ApiResultError(FailureResponseDto? responseContent, HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }
}
