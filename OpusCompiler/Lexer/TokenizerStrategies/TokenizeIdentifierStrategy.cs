using Tokens;
using System.Text.RegularExpressions;

namespace Lexer.TokenizerStrategies;

public class TokenizeIdentifierStrategy : ITokenizeStrategy
{
    private const string _identifierPattern = @"^[a-zA-Z][a-zA-Z0-9]*(\.[a-zA-Z0-9]+)*$";

    public bool Tokenize(string str, out Token result)
    {
        if (Regex.IsMatch(str, _identifierPattern))
        {
            result = new IdentifierToken(str);
            return true;
        }

        result = null;
        return false;
    }
}