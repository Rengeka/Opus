using Domain;
using Domain.Result;

namespace Compiler.CompileStrategies;

public class INT : IOInstruction
{
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        return CompilationResult<byte[]>.Success([0xCC]);
    }
}