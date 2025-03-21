using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal class x86_RETN
{
    private const byte retn = 0xC3;

    /// <summary>
    /// Compile x86 RETN
    /// </summary>
    /// <param name="parameters">Return from procedure</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE()
    {
        return CompilationResult<byte[]>.Success([retn]);
    }
}