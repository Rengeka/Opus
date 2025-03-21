using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal static class x86_POP_r_m16_32
{
    private const byte pop_r_m16_32 = 0x8F;


    /// <summary>
    /// Compile x86 pop r/m16/32
    /// </summary>
    /// <param name="parameters">Pop a Value from the Stack</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE()
    {
        return CompilationResult<byte[]>.Success([pop_r_m16_32]);
    }
}