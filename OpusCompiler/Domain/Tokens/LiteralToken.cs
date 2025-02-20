using Domain;
using Domain.Buffers;
using System.Text;

namespace Tokens;

public class LiteralToken : Token
{
    public LiteralType Type { get; set; }

    public LiteralToken(string value, LiteralType type) : base(value)
    {
        Type = type;
    }

    public override Type GetTokenType()
    {
        return typeof(LiteralToken);
    }

    public override IBuffer GetBuffer()
    {
        byte[] bytes;

        if (Type is LiteralType.LString)
        {
            bytes = Encoding.ASCII.GetBytes(Value);
            return new LiteralBuffer(bytes);
        }

        if (Type is LiteralType.LInt)
        {
            bytes = BitConverter.GetBytes(long.Parse(Value));
            return new LiteralBuffer(bytes);
        }

        return null;
    }
}

public enum LiteralType
{
    LInt,
    LString,
    LHex
}