using Lexer.TokenizerStrategies;
using Tokens;

namespace LexerTests.TokenizeStrategiesTests;

public class TokenizeInstructionStrategyTests
{
    [Fact]
    public void Tokenize_ShouldBeEquivalent()
    {
        // Arrange 
        var strategy = new TokenizeInstructionStrrategy();
        var str = "Ix00000000";
        var expectedToken = new InstructionToken("00000000");

        // Act
        Token token;
        var result = strategy.Tokenize(str, out token);

        // Assert
        Assert.True(result);
        Assert.Equivalent(expectedToken, token);
    }

    [Theory]
    [InlineData("Ix0000")]
    [InlineData("0000")]
    [InlineData("Ix")]
    [InlineData("          ")]
    public void Tokenize_ShouldBeNull(string str)
    {
        // Arrange 
        var strategy = new TokenizeInstructionStrrategy();

        // Act
        Token token;
        var result = strategy.Tokenize(str, out token);

        // Assert
        Assert.False(result);
        Assert.Null(token);
    }
}
