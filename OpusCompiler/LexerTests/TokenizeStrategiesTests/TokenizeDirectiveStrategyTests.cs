using Lexer.TokenizerStrategies;
using Tokens;

namespace LexerTests.TokenizeStrategiesTests;

public class TokenizeDirectiveStrategyTests
{
    [Fact]
    public void Tokenize_ShouldBeEquivalent()
    {
        // Arrange 
        var strategy = new TokenizeDirectiveStrategy();
        var str = "ret";
        var expectedToken = new DirectiveToken("ret");

        // Act
        Token token;
        var result = strategy.Tokenize(str, out token);

        // Assert
        Assert.True(result);
        Assert.Equivalent(expectedToken, token);
    }

    [Theory]
    [InlineData("1234")]
    [InlineData("Ix00000001")]
    [InlineData(null)]
    public void Tokenize_ShouldBeNull(string str)
    {
        // Arrange 
        var strategy = new TokenizeDirectiveStrategy();

        // Act
        Token token;
        var result = strategy.Tokenize(str, out token);

        // Assert
        Assert.False(result);
        Assert.Null(token);
    }
}