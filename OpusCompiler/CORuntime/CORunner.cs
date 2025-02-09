using Lexer;
using StateMachine;
using System.Runtime.InteropServices;
using Compiler;
using Parser;

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

    const string ENTRY_POINT = "EntryPoint";

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
    }

    public void Run(string filePath)
    {
        var tokens = _tokenizer.TokenizeFromFile(filePath);
        var modules = _moduleParser.ParseModules(tokens);

        _moduleTable.AddModules(modules);

        var entryPoint = _moduleTable.GetModule(ENTRY_POINT);

        if (entryPoint != null)
        {
            var code = _compiler.COMPILE_MODULE(entryPoint.Item2);
            Execute(code.Value);
        }
    }

    private void Execute(byte[] code)
    {
        IntPtr codeBuffer = VirtualAlloc(IntPtr.Zero, (uint)code.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
        if (codeBuffer == IntPtr.Zero)
        {
            throw new Exception("Failed to allocate memory");
        }

        Marshal.Copy(code, 0, codeBuffer, code.Length);

        MachineCodeFunction func = 
            Marshal.GetDelegateForFunctionPointer<MachineCodeFunction>(codeBuffer);
        func();

        VirtualFree(codeBuffer, 0, MEM_RELEASE);
    }



    /*public void Run()
    {
        // Example machine code (e.g., a function that simply returns)
        byte[] machineCode = { 0x90, 0x90, 0xC3 }; // NOP NOP RET instruction for x86/x64

        // Step 1: Allocate executable memory
        IntPtr codeBuffer = VirtualAlloc(IntPtr.Zero, (uint)machineCode.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
        if (codeBuffer == IntPtr.Zero)
        {
            throw new Exception("Failed to allocate memory");
        }

        // Step 2: Copy the machine code into the allocated memory
        Marshal.Copy(machineCode, 0, codeBuffer, machineCode.Length);

        // Step 3: Create a delegate pointing to the machine code
        MachineCodeFunction func = Marshal.GetDelegateForFunctionPointer<MachineCodeFunction>(codeBuffer);

        // Step 4: Execute code
        func();

        // Step 5: Free the allocated memory
        VirtualFree(codeBuffer, 0, MEM_RELEASE);
    }*/
}