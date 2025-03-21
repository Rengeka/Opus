using Domain;
using StateMachine;
using StateMachine.ModuleLibraries;
using System.Runtime.InteropServices;

namespace WindowsAPI;

public class OSWindowsAPI : IOSAPI
{
    private readonly IExternModuleLibrary _windowsLibrary;

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool VirtualFree(IntPtr lpAddress, uint dwSize, uint dwFreeType);

    public OSWindowsAPI()
    {
        _windowsLibrary = new ExternWindowsLibrary();
    }

    public IExternModuleLibrary GetOSLibrary()
    {
        return _windowsLibrary;
    }

    public nint Free()
    {
        throw new NotImplementedException();
    }

    public nint Malloc()
    {
        throw new NotImplementedException();
    }
}