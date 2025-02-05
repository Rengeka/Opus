namespace BufferTable;

public class BufferTableFasade
{
    private readonly ArgumentBufferTable _argumentBufferTable;
    private readonly MultifunctionalBufferTable _multifunctionalBufferTable;
    private readonly ReserveBufferTable _reserveBufferTable;

    private RegisterBuffer _acummulatorBuffer;
    private RegisterBuffer _outputBuffer;

    public BufferTableFasade(
        ArgumentBufferTable argumentBufferTable,
        MultifunctionalBufferTable multifunctionalBufferTable,
        ReserveBufferTable reserveBufferTable)
    {
        _argumentBufferTable = argumentBufferTable;
        _multifunctionalBufferTable = multifunctionalBufferTable;
        _reserveBufferTable = reserveBufferTable;
    }

    public RegisterBuffer GetOutputBuffer()
    {
        if (_outputBuffer == null)
        {
            _outputBuffer = _reserveBufferTable.GetFreeBuffer();
        }

        return _outputBuffer;
    }

    public RegisterBuffer GetAcummulatorBuffer()
    {
        if (_acummulatorBuffer == null)
        {
            _acummulatorBuffer = _reserveBufferTable.GetFreeBuffer();
        }

        return _acummulatorBuffer;
    }

    public RegisterBuffer GetNextArgumentBuffer(/*Add call conventions*/)
    {
        return _argumentBufferTable.GetNext();
    }

    public void ResetArgumentCounter()
    {
        _argumentBufferTable.ResetCounter();
    }
}