using Opus.x86.Enums;

namespace Opus.x86.Extentions;

internal static class REX_Extentions
{
    /// <summary>
    /// Encodes the REX flags into a full REX byte (with 0x40 prefix).
    /// </summary>
    public static byte ToByte(this REX rexFlags)
    {
        return (byte)(0x40 | (byte)rexFlags);
    }
}