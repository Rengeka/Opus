using System.Runtime.InteropServices;

namespace CORuntime;

public class CORunner
{
    const uint PAGE_EXECUTE_READWRITE = 0x40;   // Memory protection: executable, readable, writable
    const uint MEM_COMMIT = 0x1000;             // Commit memory
    const uint MEM_RELEASE = 0x8000;

    // Importing Windows API functions
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool VirtualFree(IntPtr lpAddress, uint dwSize, uint dwFreeType);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate void MachineCodeFunction();

    public CORunner()
    {

    }

    public void Run()
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
    }
}