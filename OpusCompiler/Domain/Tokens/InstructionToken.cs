namespace Tokens;

public class InstructionToken : Token
{
    public InstructionToken(string value) : base(value) { }
    
    public override Type GetTokenType()
    {
        return typeof(InstructionToken);
    }
}