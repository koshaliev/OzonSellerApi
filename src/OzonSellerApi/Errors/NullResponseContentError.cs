using FluentResults;
using System.Net;

namespace OzonSellerApi.Errors;

/// <summary>
/// Ошибка, возникающая в случае, если API вернул null в теле ответа.
/// </summary>
public class NullResponseContentError : Error
{
    public HttpStatusCode StatusCode { get; set; }

    public NullResponseContentError(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }
}
