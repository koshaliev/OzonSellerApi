using FluentResults;
using System.Net;

namespace OzonSellerApi.Errors;
public class JsonDeserializationResultError : Error
{
    public HttpStatusCode StatusCode { get; set; }
    public string ResponseContentAsString { get; set; }

    public JsonDeserializationResultError(string responseContentAsString, HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
        ResponseContentAsString = responseContentAsString;
    }
}
