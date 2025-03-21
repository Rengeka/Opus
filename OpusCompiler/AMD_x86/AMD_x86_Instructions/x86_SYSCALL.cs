using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal class x86_SYSCALL
{
    private readonly byte[] syscall = [0x0F, 0x05];

    /*public static CompilationResult<byte[]> COMPILE()
    {
        return CompilationResult<byte[]>.Success(syscall);
    }*/
}