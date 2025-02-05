namespace BufferTable;

public class ArgumentBufferTable
{
    private readonly List<RegisterBuffer> _buffers;
    private int _counter;

    public ArgumentBufferTable()
    {
        _buffers = new List<RegisterBuffer>();
    }

    public RegisterBuffer GetNext()
    {
        var buffer = _buffers[_counter];
        _counter++;

        return buffer;
    }

    public void ResetCounter()
    {
        _counter = 0;
    }

}