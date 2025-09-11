using Opus.Kernel.Enums;

namespace Opus.Kernel.Result;

public class Result<T>
{
    public T? Value { get; set; }
    public bool IsSucess { get; set; }
    public Error Error { get; set; }

    private Result(T value)
    {
        Value = value;
        IsSucess = true;
        Error = Error.None;
    }

    private Result(string errorMessage, ErrorCode errorCode)
    {
        Error = Error.Throw(errorMessage, errorCode);
        IsSucess = false;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    public static Result<T> Failure(string errorMessage, ErrorCode errorCode)
    {
        return new Result<T>(errorMessage, errorCode);
    }
}