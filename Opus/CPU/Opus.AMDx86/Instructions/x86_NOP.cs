namespace Opus.AMDx86.Instructions;

internal class x86_NOP
{
    private const byte nop = 0x90;

    /// <summary>
    /// Compile x86 nop
    /// </summary>
    /// <param name="parameters">No operation</param>
    /// <returns>Machine code for statement/returns>
    public static byte[] Compile()
    {
        throw new NotImplementedException();
    }
}