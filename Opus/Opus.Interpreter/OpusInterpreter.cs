using Opus.Contracts;

namespace Opus.Interpreter;

public class OpusInterpreter
{
    private readonly IBufferTable _bufferTable;

    public OpusInterpreter(IBufferTable bufferTable) 
    {
        _bufferTable = bufferTable;
    }

    public void Interpret(/*IModule module*/)
    {


    }
}