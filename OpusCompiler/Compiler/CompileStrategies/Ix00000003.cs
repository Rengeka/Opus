using Domain;
using BufferTable;
using Domain.Result;

namespace Compiler.CompileStrategies;

public class Ix00000003 : IOInstruction
{
    private readonly ICPUFacade _CPU;
    private readonly BufferTableFasade _bufferTable;

    public Ix00000003(ICPUFacade CPU, BufferTableFasade bufferTableFacade)
    {
        _CPU = CPU;
        _bufferTable = bufferTableFacade;
    }

    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        var source = buffers[0];
        var buffer = _bufferTable.GetNextMultifunctionalBuffer();

        return _CPU.MOV(buffer, source);
    }
}