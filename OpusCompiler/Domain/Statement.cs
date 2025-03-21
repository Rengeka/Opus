using Tokens;

namespace Domain;

public class Statement
{
    public List<Token> Tokens { get; init; }

    public Statement()
    {
        Tokens = new List<Token>();
    }

    public Statement(List<Token> tokens)
    {
        Tokens = tokens;
    }

    public void AddToken(Token token)
    {
        Tokens.Add(token);
    }
}
