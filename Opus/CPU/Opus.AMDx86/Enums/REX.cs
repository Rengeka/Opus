using System.Diagnostics;

namespace Opus.AMDx86.Enums;

/// <summary>
/// Represents the individual flags of the REX (Register Extension) prefix byte
/// used in x86-64 instruction encoding.
///
/// The REX prefix is a 1-byte value in the form 0b0100WRXB, where each flag
/// enables access to extended registers or 64-bit operands.
/// </summary>
[Flags]
[DebuggerDisplay("REX: {ToString()} (0x{((byte)this):X2})")]
internal enum REX : byte
{
    /// <summary>
    /// No REX flags set. Useful as a default value.
    /// </summary>
    None = 0,
    /// <summary>
    /// Extension for the ModR/M.rm field or SIB.base — allows access to registers R8–R15.
    /// </summary>
    B = 1 << 0, // Bit 0 (0b0001)

    /// <summary>
    /// Extension for the SIB.index field — allows use of registers R8–R15 as index.
    /// </summary>
    X = 1 << 1, // Bit 1 (0b0010)

    /// <summary>
    /// Extension for the ModR/M.reg field — enables registers R8–R15 in reg position.
    /// </summary>
    R = 1 << 2, // Bit 2 (0b0100)

    /// <summary>
    /// Operand size override — when set, indicates a 64-bit operand.
    /// </summary>
    W = 1 << 3  // Bit 3 (0b1000)
}