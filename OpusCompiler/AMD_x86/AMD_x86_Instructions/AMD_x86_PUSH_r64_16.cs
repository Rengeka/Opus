using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal static class AMD_x86_PUSH_r64_16
{
    private const byte push_r64_16 = 0x50;

    /// <summary>
    /// Compile AMD x86 push r64/16
    /// </summary>
    /// <param name="parameters">Push Word, Doubleword or Quadword Onto the Stack</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE(byte value)
    {
        // This probably requires REX byte
        return CompilationResult<byte[]>.Success([push_r64_16, value]);
    }
}