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
        Assert.Equivalent(result.Count(), 3);
    }

    [Fact]
    public void ParseStatements_ShouldBeEquivalent()
    {
        // Arrange
        List<Token> tokens =
            [
            new InstructionToken("Ix00000000"),
            new IdentifierToken("testName"),
            new DirectiveToken("ret"),
            new InstructionToken("Ix00000000"),
            ];

        var moduleParser = new ModuleParser();

        // Act
        var result = moduleParser.ParseStatements(tokens);

        // Assert
        Assert.Equivalent(result.Count(), 3);
    }
}