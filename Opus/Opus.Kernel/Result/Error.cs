using Opus.Kernel.Enums;

namespace Opus.Kernel.Result;

public class Error
{
    public string ErrorMessage { get; init; }
    public ErrorCode ErrorCode { get; init; }
    public static Error None =>  new Error("None", ErrorCode.None);

    private Error(string message, ErrorCode errorCode)
    {
        ErrorMessage = message;
        ErrorCode = errorCode;
    }

    public static Error Throw(string message, ErrorCode errorCode)
    {
        return new Error(message, errorCode);
    }
}