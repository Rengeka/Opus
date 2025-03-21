using Domain;
using Domain.Result;
using StateMachine;

namespace Compiler.CompileStrategies;

internal class @extern : IOInstruction
{
    private readonly List<NextExpected> _nextExpected;
    private readonly IExternModuleLibrary _externModuleLibrary;

    public @extern(IExternModuleLibrary externModuleLibrary)
    {
        _nextExpected = new List<NextExpected>();
        _externModuleLibrary = externModuleLibrary;

        _nextExpected.Add(NextExpected.Identifier);
        _nextExpected.Add(NextExpected.Nothing | NextExpected.Literal);
    }

    public CompilationResult<byte[]> COMPILE(params IBuffer[] buffers)
    {
        throw new NotImplementedException();

        var identifier = (string)buffers[0].GetValue();

        if (buffers[1] != null)
        {
            //var path = (string)buffers[1].GetValue();
            //_externModuleLibrary.AddModule(identifier, path);
        }

        return CompilationResult<byte[]>.Success(new byte[] { });
    }

    public List<NextExpected> GetNextExpected()
    {
        return _nextExpected;
    }
}