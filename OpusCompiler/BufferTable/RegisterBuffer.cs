using Domain;

namespace BufferTable;

public class RegisterBuffer : IBuffer
{
    private readonly byte _code;
    public BufferState State { get; set; }

    public RegisterBuffer(byte code)
    {
        _code = code;
        State = BufferState.free;
    }

    public BufferType GetBufferType()
    {
        return BufferType.Register;
    }

    public byte GetValue()
    {
        return _code;
    }
}