using BufferTable;
using Domain;
using Domain.Buffers;
using Domain.CallAgrements;
using Domain.Result;
using System.Runtime.InteropServices;

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
    /// <param name="buffers">Source buffer, Call aggreement</param>
    /// <returns>CompilationResult with machine code</returns>
    /// <exception cref="Exception"></exception>
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        var source = buffers[0];
        var callAgreement = (ICallAgreement)(buffers[1].GetValue());

        var buffer = _bufferTable.GetNextArgumentBuffer(callAgreement);
        var result = _CPU.MOV(buffer, source);

        if (!result.IsSucess)
        {
            return CompilationResult<byte[]>.Failure("CompilationError", ErrorCode.CompilatonError);
        }

        return result;
    }

    public List<NextExpected> GetNextExpected()
    {
        var nextExpected = new List<NextExpected>();
        nextExpected.Add(NextExpected.Literal | NextExpected.Identifier);

        return nextExpected;
    }
}