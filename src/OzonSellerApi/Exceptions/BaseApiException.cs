internal class BaseApiException : Exception
{
    public BaseApiException() { }

    public BaseApiException(string? message) : base(message) { }

    public BaseApiException(string? message, Exception? innerException) : base(message, innerException) { }
}
