namespace StateMachine;

public class ExternModuleTable
{
    private readonly Dictionary<string, IntPtr> _externModuelTable;

    public ExternModuleTable(IExternModuleLibrary library)
    {
        _externModuelTable = library.GetModules(); ;
    }

    public IntPtr GetModuleAddress(string identifier)
    {
        return _externModuelTable[identifier];
    }
}