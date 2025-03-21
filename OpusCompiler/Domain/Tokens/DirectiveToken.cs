namespace Tokens;

public class DirectiveToken : Token
{
    public DirectiveToken(string value) : base(value) { }

    public override Type GetTokenType()
    {
        return typeof(DirectiveToken);
    }
}