namespace StateMachine;

public interface IExternModuleLibrary
{
    public Dictionary<string, IntPtr> GetModules();
}