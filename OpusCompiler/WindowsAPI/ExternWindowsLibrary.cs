using Domain.CallAgrements;
using Domain.Modules;
using System.Runtime.InteropServices;
using WindowsAPI;

namespace StateMachine.ModuleLibraries;

// TODO move in a separate Assembly
public class ExternWindowsLibrary : IExternModuleLibrary
{
    private const int PAGE_EXECUTE_READWRITE = 0x40;
    private const int PAGE_READWRITE = 0x04;
    private const int PAGE_EXECUTE = 0x10;

    public const int STD_OUTPUT_HANDLE = -11;

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool VirtualProtect(
    IntPtr lpAddress,
    uint dwSize,
    uint flNewProtect,
    out uint lpflOldProtect);


    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    private readonly Dictionary<string, ExternModule> _modules;

    public ExternWindowsLibrary()
    {
        _modules = new Dictionary<string, ExternModule>();
        ICallAgreement callAgreement = new WindowsSTDCallAgreement();

        IntPtr kernel32 = GetModuleHandle("kernel32.dll");
        IntPtr writeConsole = GetProcAddress(kernel32, "WriteConsoleA");
        IntPtr getStdHandle = GetProcAddress(kernel32, "GetStdHandle");
        IntPtr allocConsole = GetProcAddress(kernel32, "AllocConsole");
        IntPtr waitForSingleObject = GetProcAddress(kernel32, "WaitForSingleObject");

        var writeConsoleBytes = BitConverter.GetBytes(writeConsole);
        var getStdHandleBytes = BitConverter.GetBytes(getStdHandle);
        var allocConsoleBytes = BitConverter.GetBytes(allocConsole);
        var waitForSingleObjectBytes = BitConverter.GetBytes(waitForSingleObject);

        _modules.Add("WriteConsoleA", new ExternModule
        {
            CallAgreement = callAgreement,
            Ptr = writeConsoleBytes,
        });
        _modules.Add("GetStdHandle", new ExternModule
        {
            CallAgreement = callAgreement,
            Ptr = getStdHandleBytes
        });
        _modules.Add("AllocConsole", new ExternModule
        {
            CallAgreement = callAgreement,
            Ptr = allocConsoleBytes
        });
        _modules.Add("WaitForSingleObject", new ExternModule
        {
            CallAgreement = callAgreement,
            Ptr = waitForSingleObjectBytes
        });
    }

    public Dictionary<string, ExternModule> GetModules()
    {
        return _modules;
    }
}