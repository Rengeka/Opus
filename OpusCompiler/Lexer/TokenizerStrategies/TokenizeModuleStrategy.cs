using Tokens;

namespace Lexer.TokenizerStrategies;

public class TokenizeModuleStrategy : ITokenizeStrategy
{
    public bool Tokenize(string str, out Token result)
    {
        if (str.StartsWith("[<") && str.EndsWith(">]"))
        {
            result = new ModuleToken(str.Trim().Substring(2, str.Length - 4));
            return true;
        }

        result = null;
        return false;
    }
}