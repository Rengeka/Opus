using Tokens;

namespace Lexer.TokenizerStrategies;

public class TokenizeDirectiveStrategy : ITokenizeStrategy
{
    private readonly List<string> _keywords =
        [
            "call",
            "extern",
            "ret",
            "jmp",
            "INT"
        ];

    public bool Tokenize(string str, out Token result)
    {
        if (_keywords.Contains(str))
        {
            result = new DirectiveToken(str);
            return true;
        }

        result = null;
        return false;
    }
}