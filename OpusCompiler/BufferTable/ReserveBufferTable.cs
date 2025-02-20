using Domain;

namespace BufferTable;

public class ReserveBufferTable
{
    private readonly List<IBuffer> _buffers;

    public ReserveBufferTable()
    {
        _buffers = new List<IBuffer>();
    }

    public void LoadBuffers(List<IBuffer> buffers)
    {
        _buffers.AddRange(buffers);
    }

    public void LoadBuffer(IBuffer buffer)
    {
        _buffers.Add(buffer);
    }

    public IBuffer GetFreeBuffer()
    {
        var buffer = _buffers.FirstOrDefault();
        _buffers.Remove(buffer);

        return buffer;
    }

    public List<IBuffer> GetBuffers(List<int> identifiers)
    {
        var buffers = _buffers.Where(b => identifiers.Contains((byte)b.GetValue())).ToList();      
        _buffers.RemoveAll(b => buffers.Contains(b));

        return buffers;
    }

    public bool GetBuffer(int? identifier, out IBuffer buffer)
    {
        if (identifier.HasValue)
        {
            buffer = _buffers.FirstOrDefault(b => (byte)b.GetValue() == identifier);

            if (buffer != null)
            {
                _buffers.Remove(buffer);
                return true;
            }
        }

        buffer = null;
        return false;
    }
}