using Tokens;

namespace Domain;

public class Statement
{
    public List<Token> Tokens {  get; init; }

    public Statement(List<Token> tokens)
    {
        Tokens = tokens;
    }
}
