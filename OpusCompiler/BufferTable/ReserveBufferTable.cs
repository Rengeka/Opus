namespace BufferTable;

public class ReserveBufferTable
{
    private readonly List<RegisterBuffer> _buffers;

    public ReserveBufferTable()
    {
        _buffers = new List<RegisterBuffer>();
    }

    public RegisterBuffer GetFreeBuffer()
    {
        var buffer = _buffers.FirstOrDefault();
        _buffers.Remove(buffer);

        return buffer;
    }
}