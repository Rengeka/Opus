namespace Lexer;

using Lexer.TokenizerStrategies;
using System.IO;
using System.Text.RegularExpressions;
using Tokens;

public class Tokenizer
{
    private const string _splitPattern = @"(?<=^|[ \t])""[^""]*""|[^ \t]+";
    private readonly List<ITokenizeStrategy> _tokenizerStrategies;

    public Tokenizer(List<ITokenizeStrategy> tokenizeStrategies) 
    {
        _tokenizerStrategies = tokenizeStrategies;
    }

    public List<Token> TokenizeFromFile(string filePath)
    {
        StreamReader streamReader = new StreamReader(filePath);

        var line = streamReader.ReadLine();
        var tokenList = new List<Token>();

        while (line != null)
        {
            line = line.Trim();
            var tokens = Regex.Matches(line, _splitPattern).Cast<Match>().Select(m => m.Value).ToArray();

            foreach (var tokenStr in tokens)
            {
                var token = Tokenize(tokenStr);

                if(token != null)
                {
                    tokenList.Add(token);
                }
                else
                {
                    throw new Exception("Token wasn't recognised");
                }
            }

            line = streamReader.ReadLine();
        }

        streamReader.Close();
        return tokenList;
    }

    private Token Tokenize(string str)
    {
        Token token;

        foreach (var strategy in _tokenizerStrategies)
        {
            if (strategy.Tokenize(str, out token))
            {
                return token;
            }
        }

        return null;
    }
}