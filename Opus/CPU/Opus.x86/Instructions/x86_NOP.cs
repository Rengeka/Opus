using Opus.x86.Enums;
using Opus.x86.Interfaces;

namespace Opus.x86.Instructions;

internal class x86_NOP : IInstruction_x86
{
    private const byte nop = 0x90;

    public x86_CPUFeatures RequiredFeatures { get; } = x86_CPUFeatures.None;

    /// <summary>
    /// Compile x86 nop
    /// </summary>
    /// <param name="parameters">No operation</param>
    /// <returns>Machine code for statement/returns>
    public static byte[] Compile()
    {
        return [nop];
    }
}