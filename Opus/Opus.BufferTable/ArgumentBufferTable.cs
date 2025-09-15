using Opus.Kernel.Interfaces;

namespace Opus.BufferTable;

internal class ArgumentBufferTable
{
    private readonly List<IBuffer> _buffers;
    private readonly ReserveBufferTable _reserveBufferTable;

    public ArgumentBufferTable(ReserveBufferTable reserveBufferTable)
    {
        _reserveBufferTable = reserveBufferTable;
        _buffers = new List<IBuffer>();
    }
}