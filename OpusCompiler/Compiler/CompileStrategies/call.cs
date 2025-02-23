using BufferTable;
using Domain;
using Domain.Buffers;
using Domain.Modules;
using Domain.Result;
using StateMachine;
using System.Runtime.InteropServices;

namespace Compiler.CompileStrategies;

public class call : IOInstruction
{
    private readonly ICPUFacade _CPU;
    private readonly ModuleTable _moduleTable;
    private readonly ExternModuleTable _externModuleTable;
    private readonly BufferTableFasade _bufferTable;
    private readonly List<IntPtr> _events;

    // These dlls should not be loaded here
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

    [DllImport("kernel32.dll")]
    static extern IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string lpName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetEvent(IntPtr hEvent);

    public call(
        ICPUFacade CPU,
        BufferTableFasade bufferTableFasade,
        ModuleTable moduleTable,
        ExternModuleTable externModuleTable,
        List<IntPtr> events)
    {
        _CPU = CPU;
        _moduleTable = moduleTable;
        _externModuleTable = externModuleTable;
        _bufferTable = bufferTableFasade;
        _events = events;
    }

    /// <summary>
    /// Call function
    /// </summary>
    /// <param name="buffers">Module identifier</param>
    /// <returns>CompilationResult with machine code</returns>
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        var funcIdentifier = (string)buffers[0].GetValue();
        Module module;

        if (_moduleTable.TryGetModule(funcIdentifier, out module))
        {
            if (module.Ptr != null)
            {
                return COMPILE_CALL(module.Ptr);
            }
            else
            {
                var eventHandle = CreateEvent(IntPtr.Zero, false, false, null);
                _events.Add(eventHandle);

                // make mov rdx, 0xFFFFFFFF before that call
                // 0x48, 0xBA, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00,
                var code = COMPILE_CALL(BitConverter.GetBytes(eventHandle));
                

                // make a placeholder for address of function
                //module.

                //SetEvent(eventHandle);




                // compile with wait for single object and 00000000 address 
                // replace this 00000000 later with correct address
            }

            throw new NotImplementedException();
        }
        else
        {
            var funcPtr = _externModuleTable.GetModuleAddress(funcIdentifier);

            return COMPILE_CALL(funcPtr);
        }
    }

    private CompilationResult<byte[]> COMPILE_CALL(byte[] funcPtr)
    {
        var buffer = _bufferTable.GetNextMultifunctionalBuffer();
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

    public List<NextExpected> GetNextExpected()
    {
        var nextExpected = new List<NextExpected>();
        nextExpected.Add(NextExpected.Identifier);

        return nextExpected;
    }
}