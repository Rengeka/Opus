namespace Domain.Buffers;

public class LiteralBuffer : IBuffer
{
    private readonly byte[] _value;

    public LiteralBuffer(byte[] value)
    {
        _value = value;
    }

    public Object GetValue()
    {
        return _value;
    }
}