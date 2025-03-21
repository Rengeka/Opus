using BufferTable;
using Domain;
using Domain.Result;

namespace Compiler.CompileStrategies;

public class Ix00000002 : IOInstruction
{
    private readonly BufferTableFasade _bufferTable;

    public Ix00000002(BufferTableFasade bufferTableFasade)
    {
        _bufferTable = bufferTableFasade;
    }

    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        _bufferTable.ResetArgumentCounter();
        return CompilationResult<byte[]>.Success(null);
    }
}