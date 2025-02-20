using Domain;

namespace Tokens;

public class ModuleToken : Token
{
    public ModuleToken(string value) : base(value) { }

    public override Type GetTokenType()
    {
        return typeof(ModuleToken);
    }
}