using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal static class AMD_x86_POP_r_m16_32
{
    private const byte pop_r_m16_32 = 0x8F;

    public static CompilationResult<byte[]> COMPILE()
    {
        return CompilationResult<byte[]>.Success([pop_r_m16_32]);
    }
}