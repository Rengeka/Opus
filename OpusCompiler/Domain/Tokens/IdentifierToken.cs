using Domain;
using Domain.Buffers;

namespace Tokens;

public class IdentifierToken : Token
{
    public IdentifierToken(string value) : base(value) { }

    public override Type GetTokenType()
    {
        return typeof(IdentifierToken);
    }

    public override IBuffer GetBuffer()
    {
        return new IdentifierBuffer(Value);
    }
}