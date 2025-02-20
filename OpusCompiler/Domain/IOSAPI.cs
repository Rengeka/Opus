using StateMachine;

namespace Domain;

public interface IOSAPI
{
    public IntPtr Malloc();
    public IntPtr Free();
    public IExternModuleLibrary GetOSLibrary();
}