using AMD_x86;
using CORuntime;
using WindowsAPI;

class Program
{
    static void Main(string[] args)
    {
        var startup = new COStartUp();
        var CPU = new x86_Facade();
        var windowsAPI = new OSWindowsAPI();
        var codePath = /*args[0];*/ "C:\\Users\\stasi\\source\\repos\\Opus\\OpusCompiler\\CORuntime\\CodeSample.ops";

        startup.Start(CPU, windowsAPI, codePath);
    }
}