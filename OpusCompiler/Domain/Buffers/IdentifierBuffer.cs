using System.Text;

namespace Domain.Buffers;

public class IdentifierBuffer : IBuffer
{
    private readonly string _identifier;

    public IdentifierBuffer(string identifier)
    {
        _identifier = identifier;
    }

    public Object GetValue()
    {
        return _identifier;
    }
}