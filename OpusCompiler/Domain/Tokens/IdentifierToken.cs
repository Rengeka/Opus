
namespace Tokens;

public class IdentifierToken : Token
{
    public IdentifierToken(string value) : base(value) { }

    public override Type GetTokenType()
    {
        return typeof(IdentifierToken);
    }
}