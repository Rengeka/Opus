using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal class x86_RETN
{
    private const byte retn = 0xC3;

    public static CompilationResult<byte[]> COMPILE()
    {
        return CompilationResult<byte[]>.Success([retn]);
    }
}