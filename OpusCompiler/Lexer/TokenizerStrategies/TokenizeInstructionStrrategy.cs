using Tokens;

namespace Lexer.TokenizerStrategies;

public class TokenizeInstructionStrrategy : ITokenizeStrategy
{
    public bool Tokenize(string str, out Token result)
    {
        if (str.Length == 10 && str.StartsWith("Ix"))
        {
            result = new InstructionToken(str.Substring(2));
            return true;
        }

        result = null;
        return false;
    }
}