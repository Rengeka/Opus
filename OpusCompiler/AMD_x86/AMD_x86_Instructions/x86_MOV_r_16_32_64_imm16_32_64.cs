using Domain.Result;

namespace AMD_x86.AMD_x86_Instructions;

internal static class x86_MOV_r_16_32_64_imm16_32_64
{
    private const byte mov_r_16_32_64_imm16_32_64 = 0xB8;
    private const byte REX = 0x48;

    /// <summary>
    /// Compile x86 mov r/m16/32/64 imm16/32/64
    /// </summary>
    /// <param name="parameters">Move</param>
    /// <returns>Machine code for statement/returns>
    public static CompilationResult<byte[]> COMPILE(byte buffer, byte[] source, bool isEXTReg = false)
    {
        var rex = REX;
        if (isEXTReg)
        {
            rex++;
            buffer -= 8;
        }

        var opcode = (byte)(buffer + mov_r_16_32_64_imm16_32_64);

        byte[] code = [rex, opcode];

        return CompilationResult<byte[]>.Success(code.Concat(source).ToArray());
    }
}