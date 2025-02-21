using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal class x86_CALL
{
    private const byte call = 0xFF;
    private const byte mod = 0xD0;

    /// <summary>
    /// Compile x86 call r16/32/64 m
    /// </summary>
    /// <param name="parameters">Load Effective Address</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE(byte register)
    {
        return CompilationResult<byte[]>.Success([call, (byte)(register + mod)]);
    }
}