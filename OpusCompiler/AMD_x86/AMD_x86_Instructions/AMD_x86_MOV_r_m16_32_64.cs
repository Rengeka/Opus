using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal static class AMD_x86_MOV_r_m16_32_64
{
    private const byte mov_r_m16_32_64 = 0x89;

    public static CompilationResult<byte[]> COMPILE(byte buffer, byte source)
    {
        return CompilationResult<byte[]>.Success([mov_r_m16_32_64, buffer, source]);
    }
}