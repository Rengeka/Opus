using Tokens;
using System.Text.RegularExpressions;

namespace Lexer.TokenizerStrategies;

public class TokenizeLiteralStrategy : ITokenizeStrategy
{
    private const string _hexLiteralPattern = @"^0[xX][0-9a-fA-F]+$";

    public bool Tokenize(string str, out Token result)
    {
        if (int.TryParse(str, out _))
        {
            result = new LiteralToken(str, LiteralType.LInt);
            return true;
        }

        if (str.StartsWith('\"') && str.EndsWith('\"'))
        {
            result = new LiteralToken(str, LiteralType.LString);
            return true;
        }

        if (Regex.IsMatch(str, _hexLiteralPattern))
        {
            result = new LiteralToken(str.Substring(2), LiteralType.LHex);
            return true;
        }

        result = null;
        return false;
    }
}