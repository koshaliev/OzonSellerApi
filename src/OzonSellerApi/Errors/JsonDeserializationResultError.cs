using FluentResults;
using System.Net;

namespace OzonSellerApi.Errors;
public class JsonDeserializationResultError : Error
{
    /// <summary>
    /// Код состояния.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }
    
    /// <summary>
    /// Тело ответа.
    /// </summary>
    public string ResponseContentAsString { get; set; }

    public JsonDeserializationResultError(string exceptionMessage, string responseContentAsString, HttpStatusCode statusCode) 
        : base(exceptionMessage)
    {
        StatusCode = statusCode;
        ResponseContentAsString = responseContentAsString;
    }
}
