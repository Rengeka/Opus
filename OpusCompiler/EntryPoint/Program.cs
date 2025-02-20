using AMD_x86;
using CORuntime;
using WindowsAPI;

var startup = new COStartUp();
var CPU = new x86_Facade();
var windowsAPI = new OSWindowsAPI();

startup.Start(CPU, windowsAPI);