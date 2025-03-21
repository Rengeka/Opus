using Domain;
using Domain.Result;
using Tokens;

namespace Compiler.CompileStrategies;

public interface IOInstruction
{
    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers);

    public List<NextExpected> GetNextExpected()
    {
        return null;
    }

    public static bool CompareToToken(Token token, NextExpected nextExpected)
    {
        if (
            (token is LiteralToken && nextExpected.HasFlag(NextExpected.Literal)) ||
            (token is IdentifierToken && nextExpected.HasFlag(NextExpected.Identifier)) ||
            (token is ModuleToken && nextExpected.HasFlag(NextExpected.Module))
            )
        {
            return true;
        }

        return false;
    }
}