namespace Domain.Result;

public class CompilationError
{
    public string ErrorMessage { get; init; }
    public ErrorCode ErrorCode { get; init; }

    private CompilationError(string message, ErrorCode errorCode)
    {
        ErrorMessage = message;
        ErrorCode = errorCode;
    }

    public static CompilationError Throw(string message, ErrorCode errorCode)
    {
        return new CompilationError(message, errorCode);
    }
}