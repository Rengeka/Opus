using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal static class AMD_x86_NOP
{
    private const byte nop = 0x90;

    /// <summary>
    /// Compile AMD x86 nop
    /// </summary>
    /// <param name="parameters">No operation</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE()
    {
        return CompilationResult<byte[]>.Success([nop]);
    }
}