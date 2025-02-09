using System.Runtime.InteropServices;

namespace StateMachine.ModuleLibraries;

public class ExternWindowsLibrary : IExternModuleLibrary
{
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    private readonly Dictionary<string, IntPtr> _modules;

    public ExternWindowsLibrary()
    {
        _modules = new Dictionary<string, IntPtr>();

        IntPtr kernel32 = GetModuleHandle("kernel32.dll");
        IntPtr writeConsole = GetProcAddress(kernel32, "WriteConsoleA");

        //_modules.Add("kernel32.dll", kernel32);
        _modules.Add("WriteConsoleA", writeConsole);
    }

    public Dictionary<string, IntPtr> GetModules()
    {
        return _modules;
    }
}