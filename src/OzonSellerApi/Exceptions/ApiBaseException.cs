internal class ApiBaseException : Exception
{
    public ApiBaseException() { }

    public ApiBaseException(string? message) : base(message) { }

    public ApiBaseException(string? message, Exception? innerException) : base(message, innerException) { }
}
