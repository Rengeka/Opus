using System.Runtime.InteropServices;

namespace Opus.AMDx86.Structs;

[StructLayout(LayoutKind.Explicit)]
internal struct ModRM
{
    [FieldOffset(0)]
    public byte Mod;
    [FieldOffset(0)]
    public byte Reg;
    [FieldOffset(0)]
    public byte RM;   
}