using Tokens;

namespace Lexer.TokenizerStrategies;

public interface ITokenizeStrategy
{
    public bool Tokenize(string str, out Token result);
}