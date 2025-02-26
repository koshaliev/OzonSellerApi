using System.Net;

namespace OzonSellerApi.Exceptions;
internal class ApiFailureResponseException : ApiBaseException
{
    public HttpStatusCode StatusCode { get; }
    public HttpContent HttpContent { get; }

    public ApiFailureResponseException(HttpStatusCode statusCode, HttpContent content, string uri) 
        : base($"Код ответа: {statusCode}. Неудачный запрос на {uri}.")
    {
        HttpContent = content;
        StatusCode = statusCode;
    }
}
