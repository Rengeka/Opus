using Domain;
using StateMachine;

namespace Compiler.CompileStrategies;

public class call
{
    private readonly ICPUFacade _CPU;
    private readonly ModuleTable _moduleTable;
    private readonly ExternModuleTable _externModuleTable;
    
    public call(ICPUFacade CPU, ModuleTable moduleTable, ExternModuleTable externModuleTable)
    {
        _CPU = CPU;
        _moduleTable = moduleTable;
        _externModuleTable = externModuleTable;
    }

    public void COMPILE(IBuffer buffer)
    {
        //var module = 
    }
}