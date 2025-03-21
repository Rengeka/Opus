using Domain;
using Domain.Result;

namespace Compiler.CompileStrategies;

public class ret : IOInstruction
{
    private readonly ICPUFacade _CPU;

    public ret(ICPUFacade CPU)
    {
        _CPU = CPU;
    }

    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        return _CPU.RET();
    }
}