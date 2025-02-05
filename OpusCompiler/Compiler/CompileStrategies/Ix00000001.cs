using BufferTable;
using Domain;

namespace Compiler.CompileStrategies;

public class Ix00000001 
{
    private readonly ICPUFasade _CPU;
    private readonly BufferTableFasade _bufferTable;

    public void COMPILE(IBuffer sourse)
    {
        var buffer = _bufferTable.GetNextArgumentBuffer();
        var result = _CPU.MOV(buffer, sourse);

        if (!result.IsSucess)
        {
            throw new Exception("Compilation error");
        }
    }
}