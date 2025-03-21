using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal static class x86_PUSH_imm16_32
{
    private const byte push_imm16_32 = 0x68;

    /// <summary>
    /// Compile x86 push imm16/32
    /// </summary>
    /// <param name="parameters">Push Word, Doubleword or Quadword Onto the Stack</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE(byte value)
    {
        return CompilationResult<byte[]>.Success([push_imm16_32, value]);
    }
}