using FluentResults;

namespace OzonSellerApi.Errors;
public class OperationCanceledError : ExceptionalError
{
    public OperationCanceledError(Exception exception) : base(exception) { }
    public OperationCanceledError(string message, Exception exception) : base(message, exception) { }
}
