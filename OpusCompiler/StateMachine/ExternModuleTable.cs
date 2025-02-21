using Domain.CallAgrements;
using Domain.Modules;

namespace StateMachine;

public class ExternModuleTable
{
    private readonly Dictionary<string, ExternModule> _externModuelTable;

    public ExternModuleTable(IExternModuleLibrary library)
    {
        _externModuelTable = library.GetModules(); ;
    }

    public byte[] GetModuleAddress(string identifier)
    {
        return _externModuelTable[identifier].Ptr;
    }

    /*public IntPtr GetModuleAddress(string identifier)
    {
        return _externModuelTable[identifier].Ptr;
    }*/

    public ICallAgreement GetCallAgreement(string identifier) 
    { 
        return _externModuelTable[identifier].CallAgreement;
    }

    public ExternModule GetExternModule(string identifier) 
    {
        return _externModuelTable[identifier];
    }
}