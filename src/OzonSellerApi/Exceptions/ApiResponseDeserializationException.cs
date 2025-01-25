using System.Net;

namespace OzonSellerApi.Exceptions;
internal class ApiResponseDeserializationException : BaseApiException
{
    public HttpStatusCode StatusCode { get; set; }
    public HttpContent? HttpContent { get; set; }

    public ApiResponseDeserializationException(HttpStatusCode statusCode, HttpContent httpContent)
        : base($"Ошибка десериализации тела ответа. Код состояния: {statusCode}")
    {
        StatusCode = statusCode;
        HttpContent = httpContent;
    }

    public ApiResponseDeserializationException(HttpStatusCode statusCode, HttpContent httpContent, Exception? innerException)
        : base($"Ошибка десериализации тела ответа. Код состояния: {statusCode}", innerException)
    {
        StatusCode = statusCode;
        HttpContent = httpContent;
    }
}
