using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal class x86_LEA_r16_32_64_m
{
    private const byte lea_r16_32_64_m = 0x8D;
    private const byte REX = 0x48; // TODO for now

    /// <summary>
    /// Compile x86 lea r16/32/64 m
    /// </summary>
    /// <param name="parameters">Load Effective Address</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE(byte value)
    {
        return CompilationResult<byte[]>.Success([REX, lea_r16_32_64_m, value]);
    }
}