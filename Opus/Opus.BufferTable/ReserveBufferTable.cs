using Opus.Kernel.Interfaces;

namespace Opus.BufferTable;

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

        if (buffer is not null)
        {
            _buffers.Remove(buffer);
            return buffer;
        }

        // [INFO] Do I need a result pattern in this module?
        throw new Exception(); 
    }
}