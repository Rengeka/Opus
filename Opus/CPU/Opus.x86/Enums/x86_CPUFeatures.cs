namespace Opus.x86.Enums;


[Flags]
public enum x86_CPUFeatures
{
    None = 0,

    Add = 1 << 0,
    Sub = 1 << 1,
    And = 1 << 2,
    Or = 1 << 3,
    Nop = 1 << 4,

    Push = 1 << 5,
    Pop = 1 << 6,

    PushR64 = 1 << 7,
    PopR64 = 1 << 8,
    PushImm64 = 1 << 9,

    Sse = 1 << 10,
    Avx = 1 << 11
}