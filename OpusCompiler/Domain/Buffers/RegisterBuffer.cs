namespace Domain.Buffers;

public class RegisterBuffer : IBuffer
{
    private readonly byte _code;

    public BufferState State { get; set; }

    public RegisterBuffer(byte code)
    {
        _code = code;
        State = BufferState.free;
    }

    public Object GetValue()
    {
        return _code;
    }
}