using FluentResults;
using OzonSellerApi.Dtos.Responses.Common;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace OzonSellerApi.Errors;

/// <summary>
/// Ошибка, предназначенная для хранения тела ответа неудачного запроса.
/// </summary>
public class ApiResultError : Error
{
    /// <summary>
    /// Код состояния.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Тело ответа.
    /// </summary>
    [MemberNotNullWhen(false, nameof(IsContentNull))]
    public FailureResponseDto? ResponseContent { get; set; }
    
    public bool IsContentNull => ResponseContent == null;

    public ApiResultError(FailureResponseDto? responseContent, HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }
}
