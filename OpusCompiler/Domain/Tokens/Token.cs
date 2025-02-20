using Domain;

namespace Tokens;

public abstract class Token
{
    public string Value { get; set; }

    public Token(string value)
    {
        Value = value;
    }

    public virtual IBuffer GetBuffer()
    {
        throw new NotImplementedException();
    }

    public abstract Type GetTokenType();
}