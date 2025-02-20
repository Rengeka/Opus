using BufferTable;
using Domain;
using Domain.CallAgrements;
using Domain.Result;

namespace Compiler.CompileStrategies;

public class Ix0000000D : IOInstruction
{
    private readonly ICPUFacade _CPU;
    private readonly BufferTableFasade _bufferTable;

    public Ix0000000D(ICPUFacade CPU, BufferTableFasade bufferTableFasade)
    {
        _CPU = CPU;
        _bufferTable = bufferTableFasade;
    }

    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        // TODO
        var callAgreement = (ICallAgreement)buffers[0].GetValue();

        var outputBuffer = _bufferTable.GetOutputBuffer(callAgreement);
        var buffer = _bufferTable.GetNextArgumentBuffer(callAgreement);

        return _CPU.MOV(buffer, outputBuffer);
    }
}