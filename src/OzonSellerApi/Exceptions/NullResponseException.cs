namespace OzonSellerApi.Exceptions;
public class NullResponseException : Exception
{
    public NullResponseException() : base("Тело ответа содержит null.") { }
    public NullResponseException(string? message) : base(message) { }
}
