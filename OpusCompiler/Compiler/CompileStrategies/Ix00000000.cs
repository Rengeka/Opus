using Domain;
using Domain.Result;
using Tokens;

namespace Compiler.CompileStrategies;

public class Ix00000000 : IOInstruction
{
    private readonly ICPUFacade _CPU;

    public Ix00000000(ICPUFacade CPU)
    {
        _CPU = CPU;
    }

    /// <summary>
    /// Do nothing
    /// </summary>
    /// <param name="buffers">No params</param>
    /// <returns>CompilationResult with no machine code</returns>
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        return _CPU.NOP();
    }
}