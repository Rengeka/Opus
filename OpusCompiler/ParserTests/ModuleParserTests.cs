using Tokens;
using Parser;

namespace ParserTests;

public class ModuleParserTests
{
    [Fact]
    public void ParseModules_ShouldBeEquivalent()
    {
        // Arrange
        List<Token> tokens =
            [
            new DirectiveToken("extern"),
            new IdentifierToken("WriteConsole"),
            new ModuleToken("EntryPoint"),
            new InstructionToken("Ix00000000"),
            new DirectiveToken("ret"),
            new ModuleToken("Console.Print"),
            new InstructionToken("Ix00000000"),
            new DirectiveToken("ret")
            ];

        var moduleParser = new ModuleParser();

        // Act
        var result = moduleParser.ParseModules(tokens);

        // Assert
        Assert.NotNull(result);
        Assert.Equivalent(result.Count(), 3);
    }
}