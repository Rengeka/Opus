using BufferTable;
using Domain;
using Domain.Buffers;
using Domain.Result;
using StateMachine;

namespace Compiler.CompileStrategies;

public class call : IOInstruction
{
    private readonly ICPUFacade _CPU;
    private readonly ModuleTable _moduleTable;
    private readonly ExternModuleTable _externModuleTable;
    private readonly BufferTableFasade _bufferTable;

    public call(
        ICPUFacade CPU, 
        BufferTableFasade bufferTableFasade, 
        ModuleTable moduleTable, 
        ExternModuleTable externModuleTable)
    {
        _CPU = CPU;
        _moduleTable = moduleTable;
        _externModuleTable = externModuleTable;
        _bufferTable = bufferTableFasade;
    }

    /// <summary>
    /// Call function
    /// </summary>
    /// <param name="buffers">Module identifier</param>
    /// <returns>CompilationResult with no machine code</returns>
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        var funcIdentifier = (string)buffers[0].GetValue();

        Tuple<ModuleState, List<Statement>> module;

        if (_moduleTable.TryGetModule(funcIdentifier, out module))
        {
            throw new NotImplementedException();
        }
        else
        {
            var funcPtr = _externModuleTable.GetModuleAddress(funcIdentifier);
            var buffer = _bufferTable.GetNextMultifunctionalBuffer();

            //var literalBuffer = new LiteralBuffer(BitConverter.GetBytes(funcPtr));
            var literalBuffer = new LiteralBuffer(funcPtr);

            var MOVResult = _CPU.MOV(buffer, literalBuffer);

            if (!MOVResult.IsSucess)
            {
                return MOVResult;
            }

            var CALLResult = _CPU.CALL(buffer);
            var code = MOVResult.Value.Concat(CALLResult.Value).ToArray();

            _bufferTable.AddBufferInReserve(buffer);

            return CompilationResult<byte[]>.Success(code);
        }

        throw new NotImplementedException();
    }

    public List<NextExpected> GetNextExpected()
    {
        var nextExpected = new List<NextExpected>();
        nextExpected.Add(NextExpected.Identifier);

        return nextExpected;
    }
}