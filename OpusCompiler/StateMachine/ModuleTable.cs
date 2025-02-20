using Domain;

namespace StateMachine;

public class ModuleTable
{
    private Dictionary<string, Tuple<ModuleState, List<Statement>>> _moduleTable;

    public ModuleTable()
    {
        _moduleTable = new Dictionary<string, Tuple<ModuleState, List<Statement>>>();
    }

    public void AddModules(Dictionary<string, List<Statement>> table)
    {
        foreach (var module in table)
        {
            _moduleTable.Add(module.Key, new Tuple<ModuleState, List<Statement>>(ModuleState.ReadyToCompile, module.Value));
        }
    }

    public bool TryGetModule(string identifier, out Tuple<ModuleState, List<Statement>> module)
    {
        return _moduleTable.TryGetValue(identifier, out module);
    }

    public bool ContainsModule(string identifier)
    {
        return _moduleTable.ContainsKey(identifier);
    }
}