using Opus.AMDx86.Enums;

namespace Opus.AMDx86.Extentions;

internal static class REXExtentions
{
    /// <summary>
    /// Encodes the REX flags into a full REX byte (with 0x40 prefix).
    /// </summary>
    public static byte ToByte(this REX rexFlags)
    {
        return (byte)(0x40 | (byte)rexFlags);
    }
}