namespace Tokens;

public abstract class Token
{
    public string Value { get; set; }

    public Token(string value)
    {
        Value = value;
    }

    public abstract Type GetTokenType();
}