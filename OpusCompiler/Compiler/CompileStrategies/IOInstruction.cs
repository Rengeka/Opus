using Domain;
using Domain.Result;
using Tokens;

namespace Compiler.CompileStrategies;

public interface IOInstruction
{
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers);

    public List<Type> GetNextExpected()
    {
        return null;
    }
}