namespace Domain;

public interface IBuffer
{
    public BufferType GetBufferType();
    public byte GetValue();
}