using BufferTable;

namespace Compiler.CompileStrategies;

public class Ix00000002
{
    private readonly BufferTableFasade _bufferTable;

    public void Compile()
    {
        _bufferTable.ResetArgumentCounter();
    }
}