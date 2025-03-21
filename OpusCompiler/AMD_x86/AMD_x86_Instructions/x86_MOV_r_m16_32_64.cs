using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal static class x86_MOV_r_m16_32_64
{
    private const byte mov_r_m16_32_64 = 0x89;
    private const byte REX = 0x48;

    private const byte MOD = 0xC0;


    /// <summary>
    /// Compile x86 mov r/m16/32/64
    /// </summary>
    /// <param name="parameters">Move</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE(byte buffer, byte source, bool isEXTReg = false)
    {
        var rex = REX;
        if (isEXTReg)
        {
            rex++;
        }

        byte modrm = (byte)(MOD | (source << 3) | buffer);

        return CompilationResult<byte[]>.Success([rex, mov_r_m16_32_64, modrm]);
    }
}