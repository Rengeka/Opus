using Compiler.CompileStrategies;
using Domain;

namespace Compiler;

public class Compiler
{
    private readonly Dictionary<string, ICompileStrategy> _instructionTable;
    private readonly ICPUFasade _CPU;

    public Compiler(Dictionary<string, ICompileStrategy> instructionTable, ICPUFasade CPU) 
    { 
        _instructionTable = instructionTable;
        _CPU = CPU;
    }

    public void Compile()
    {

    }
}