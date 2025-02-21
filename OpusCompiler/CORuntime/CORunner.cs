using Lexer;
using StateMachine;
using System.Runtime.InteropServices;
using Compiler;
using Parser;
using Domain.CallAgrements;
//using Serilog; // TODO Add logs
using Tokens;
using Domain;
using Domain.Modules;
using Domain.Result;

namespace CORuntime;

public class CORunner
{
    private readonly ExternModuleTable _externModuleTable;
    private readonly ModuleTable _moduleTable;
    private readonly Tokenizer _tokenizer;
    private readonly OCompiler _compiler;
    private readonly ModuleParser _moduleParser;

    const uint PAGE_EXECUTE_READWRITE = 0x40;   // Memory protection: executable, readable, writable
    const uint MEM_COMMIT = 0x1000;             // Commit memory
    const uint MEM_RELEASE = 0x8000;
    const uint MEM_SIZE = 4096;                 // 4KB
    const int STRING_POOL_START = 4000;
    const uint MEM_RESERVE = 0x2000;
    const string ENTRY_POINT = "EntryPoint";

    readonly nint CODE_START;

    nint __CODE__END__;
    int __STRING__POOL__END__ = STRING_POOL_START;


    // Importing Windows API functions
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool VirtualFree(IntPtr lpAddress, uint dwSize, uint dwFreeType);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void MachineCodeFunction();

    public CORunner(
        ExternModuleTable externModuleTable,
        ModuleTable moduleTable,
        Tokenizer tokenizer,
        OCompiler compiler,
        ModuleParser moduleParser)
    {
        _externModuleTable = externModuleTable;
        _moduleTable = moduleTable;
        _tokenizer = tokenizer;
        _compiler = compiler;
        _moduleParser = moduleParser;

        CODE_START = VirtualAlloc(IntPtr.Zero, MEM_SIZE, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
        if (CODE_START == IntPtr.Zero)
        {
            throw new Exception("Failed to allocate memory");
        }

        __CODE__END__ = CODE_START;
    }

    public void Run(string filePath)
    {
        var tokens = _tokenizer.TokenizeFromFile(filePath);
        var modules = _moduleParser.ParseModules(tokens);

        _moduleTable.AddModules(modules);

        Module module;
        _moduleTable.TryGetModule("Print", out module);
        CompileModule(/*CODE_BUFFER_START,*/ module);
        //var result = CompileModule(CODE_BUFFER_START, module);

        _moduleTable.TryGetModule(ENTRY_POINT, out module);
        CompileModule(/*CODE_BUFFER_START,*/ module);
        //var code = result.Value.Concat(CompileModule(CODE_BUFFER_START, module).Value).ToArray();

        Execute(/*code,*/ CODE_START);

        //CompileEntryPoint(codeBuffer);
    }
    /*
        private void CompileEntryPoint(IntPtr codeBuffer)
        {
            Module entryPoint;

            if (_moduleTable.TryGetModule(ENTRY_POINT, out entryPoint))
            {
                var strings = entryPoint.Statements
                .SelectMany(s => s.Tokens.Where(t => t is LiteralToken token && token.Type == LiteralType.LString))
                .Select(t => t.Value)
                .ToArray();

                _compiler.COMPILE_STRINGS(strings, codeBuffer, ref STRING_POOL_ADDRESS);
                var callAgreements = IDENTIFY_CALL_AGREEMENTS(entryPoint.Statements);

                var code = _compiler.COMPILE_MODULE(entryPoint.Statements, callAgreements);

                //var task = new Task(() => Execute(code.Value, codeBuffer));
                //task.Wait();
                Execute(code.Value, codeBuffer);
            }
        }*/

    private CompilationResult<string> CompileModule(/*IntPtr codeBuffer,*/ Module module)
    {
        var strings = module.Statements
        .SelectMany(s => 
            s.Tokens.Where(t => 
                t is LiteralToken token && token.Type == LiteralType.LString))
            .Select(t => t.Value)
            .ToArray();

        __STRING__POOL__END__ = _compiler.COMPILE_STRINGS(strings, CODE_START, __STRING__POOL__END__);
        var callAgreements = IDENTIFY_CALL_AGREEMENTS(module.Statements);

        var result = _compiler.COMPILE_MODULE(module.Statements, callAgreements);
        Marshal.Copy(result.Value, 0, __CODE__END__, result.Value.Length);

        module.Ptr = BitConverter.GetBytes(__CODE__END__);
        __CODE__END__ += (nint)result.Value.Length;

        return CompilationResult<string>.Success("Module was compiled");
    }

    private void Execute(/*byte[] code, */IntPtr codeBuffer)
    {
        //Marshal.Copy(code, 0, codeBuffer, code.Length);

        unsafe
        {
            // Convert the IntPtr to a pointer
            byte* ptr = (byte*)codeBuffer.ToPointer();

            // Create a Span from the pointer (use the correct size of the buffer)
            Span<byte> bufferSpan = new Span<byte>(ptr, 4096);

            // Print the contents of the memory
            Console.WriteLine("Code buffer contents:");
            for (int i = 0; i < bufferSpan.Length; i++)
            {
                Console.Write($"{bufferSpan[i]:X2} ");  // Print each byte as a hexadecimal value
                if ((i + 1) % 16 == 0)  // Print a newline every 16 bytes
                {
                    Console.WriteLine();
                }
            }
        }

        MachineCodeFunction func =
            Marshal.GetDelegateForFunctionPointer<MachineCodeFunction>(codeBuffer);

        func();

        VirtualFree(codeBuffer, 0, MEM_RELEASE);
    }

    private Queue<ICallAgreement> IDENTIFY_CALL_AGREEMENTS(List<Statement> statements)
    {
        var callAgreementQueue = new Queue<ICallAgreement>();
        var stdCallAgreement = new STDOCallAgreement();

        foreach (var statement in statements)
        {
            var tokens = statement.Tokens;
            if (tokens[0] is DirectiveToken && tokens[0].Value == "call")
            {
                if (_moduleTable.ContainsModule(tokens[1].Value))
                {
                    callAgreementQueue.Enqueue(stdCallAgreement);
                }
                else
                {
                    var module = _externModuleTable.GetExternModule(tokens[1].Value);
                    callAgreementQueue.Enqueue(module.CallAgreement);
                }
            }
        }

        return callAgreementQueue;
    }
}