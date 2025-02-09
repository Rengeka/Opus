using BufferTable;
using Domain;
using Domain.Result;

namespace Compiler.CompileStrategies;

public class Ix00000001 : IOInstruction
{
    private readonly ICPUFacade _CPU;
    private readonly BufferTableFasade _bufferTable;

    public Ix00000001(ICPUFacade CPU, BufferTableFasade bufferTableFasade)
    {
        _CPU = CPU;
        _bufferTable = bufferTableFasade;
    }

    /// <summary>
    /// Load value into next function argument buffer
    /// </summary>
    /// <param name="buffers">Source buffer</param>
    /// <returns>CompilationResult with machine code</returns>
    /// <exception cref="Exception"></exception>
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        var source = buffers[0];

        var buffer = _bufferTable.GetNextArgumentBuffer();
        var result = _CPU.MOV(buffer, source);

        if (!result.IsSucess)
        {
            throw new Exception("Compilation error");
        }

        return result;
    }

    public List<Type> GetNextExpected()
    {
        throw new NotImplementedException();
    }
}