using Domain;
using Domain.Result;

namespace Compiler.CompileStrategies;

public class jmp : IOInstruction
{
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        return CompilationResult<byte[]>.Success([0xEB, 0xFE]);
    }
}