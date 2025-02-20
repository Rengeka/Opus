using Domain;

namespace StateMachine;

public interface IExternModuleLibrary
{
    public Dictionary<string, ExternModule> GetModules();
}