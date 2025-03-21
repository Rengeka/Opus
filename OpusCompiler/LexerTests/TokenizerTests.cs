using Lexer;
using Lexer.TokenizerStrategies;

namespace LexerTests;

public class TokenizerTests
{
    private readonly string codeSamplePath = "C:\\Users\\stasi\\source\\repos\\Opus\\OpusCompiler\\LexerTests\\CodeSample.ops";

    [Fact]
    public void TokenizeFromFile_ShouldNotBeEmpty()
    {
        // Arrange
        List<ITokenizeStrategy> strategies = [
            new TokenizeInstructionStrrategy(),
            new TokenizeLiteralStrategy(),
            new TokenizeDirectiveStrategy(),
            new TokenizeModuleStrategy(),
            new TokenizeIdentifierStrategy(),
        ];

        var tokenizer = new Tokenizer(strategies);

        // Act
        var result = tokenizer.TokenizeFromFile(codeSamplePath);

        // Assert
        Assert.NotEmpty(result);
    }
}