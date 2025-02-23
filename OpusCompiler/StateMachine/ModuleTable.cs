using Domain;
using Domain.Modules;

namespace StateMachine;

public class ModuleTable
{
    private Dictionary<string, Module> _modules;

    public ModuleTable()
    {
        _modules = new Dictionary<string, Module>();
    }

    public void AddModules(Dictionary<string, List<Statement>> table)
    {
        foreach (var moduleData in table)
        {
            _modules.Add(moduleData.Key, new Module(moduleData.Value));
        }
    }

    public void AddModules(Dictionary<string, Module> table)
    {
        foreach (var module in table)
        {
            _modules.Add(module.Key, module.Value);
        }
    }

    public bool TryGetModule(string identifier, out Module module)
    {
        return _modules.TryGetValue(identifier, out module);
    }

    public bool ContainsModule(string identifier)
    {
        return _modules.ContainsKey(identifier);
    }

    public Module GetUncompiledModuleWithLeastSelfRefs()
    {
        return _modules.Where(m => m.Value.Ptr != null).MinBy(m => m.Value.SelfReferencess).Value;
    }

    public Module GetUncompiledModuleWithLeastExternRefs()
    {
        var notCompiled = _modules.Where(m => m.Value.Ptr == null && m.Key != "GLOBAL");

        if (notCompiled.Count() > 0)
        {
            return notCompiled.MinBy(m => m.Value.ExternReferencess).Value;
        }

        return null;
    }

    public int CountModules()
    {
        return _modules.Count;
    }
}