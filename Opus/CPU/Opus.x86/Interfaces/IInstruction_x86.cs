using Opus.x86.Enums;

namespace Opus.x86.Interfaces;

internal interface IInstruction_x86
{
    public x86_CPUFeatures RequiredFeatures { get; }
}