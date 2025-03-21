using Domain.Modules;

namespace StateMachine;

public interface IExternModuleLibrary
{
    public Dictionary<string, ExternModule> GetModules();

    public void AddModule(string identifier, string path)
    {

    }
}