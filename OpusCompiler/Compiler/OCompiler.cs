using Compiler.CompileStrategies;
using Domain;
using Domain.Result;
using Tokens;

namespace Compiler;

public class OCompiler
{
    private readonly Dictionary<string, IOInstruction> _instructionTable;
    private readonly ICPUFacade _CPU;

    public OCompiler(Dictionary<string, IOInstruction> instructionTable, ICPUFacade CPU)
    {
        _instructionTable = instructionTable;
        _CPU = CPU;
    }

    public CompilationResult<byte[]> COMPILE_MODULE(List<Statement> statements)
    {
        byte[] code = [];

        foreach (var statement in statements)
        {
            var instruction = _instructionTable[statement.Tokens[0].Value];
            var nextExpected = instruction.GetNextExpected();

            for (int i = 1; i < statement.Tokens.Count(); i++)
            {
                if (statement.Tokens[i].GetTokenType() != nextExpected[i])
                {
                    // TODO normal result pattern instead of throwing exception
                    throw new Exception("Compilation error");
                }
            }

            code = code.Concat(instruction.COMPILE().Value).ToArray();
        }

        return CompilationResult<byte[]>.Success(code);
    }
}