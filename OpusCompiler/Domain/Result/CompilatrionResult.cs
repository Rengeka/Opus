namespace Domain.Result;

public class CompilationResult<T>
{
    public T Value { get; set; }
    public bool IsSucess { get; set; }
    public CompilationError Error { get; set; }

    private CompilationResult(T value)
    {
        Value = value;
        IsSucess = true;
    }
    private CompilationResult(string errorMessage, ErrorCode errorCode)
    {
        Error = CompilationError.Throw(errorMessage, errorCode);
        IsSucess = false;
    }

    public static CompilationResult<T> Success(T value)
    {
        return new CompilationResult<T>(value);
    }
    public static CompilationResult<T> Failure(string errorMessage, ErrorCode errorCode)
    {
        return new CompilationResult<T>(errorMessage, errorCode);
    }
}
