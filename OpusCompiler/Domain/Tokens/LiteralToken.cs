namespace Tokens;

public class LiteralToken : Token 
{
    public LiteralType Type { get; set; }

    public LiteralToken(string value, LiteralType type) : base(value) 
    { 
        Type = type;
    }
}

public enum LiteralType
{
    LInt,
    LString,
    LHex
}