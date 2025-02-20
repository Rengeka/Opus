using CORuntime;
using Lexer;
using Moq;
using StateMachine;
using Compiler;
using Parser;
using Tokens;
using Domain;

namespace RunnerTests;

public class RunnerTests
{
    private readonly string _codePath = "C:\\Users\\stasi\\Desktop\\OpusCompiler\\RunnerTests\\CodeSample.ops";

    private readonly Mock<ExternModuleTable> _externModuleTableMock;
    private readonly Mock<ModuleTable> _moduleTableMock;
    private readonly Mock<Tokenizer> _tokenizerMock;
    private readonly Mock<OCompiler> _compilerMock;
    private readonly Mock<ModuleParser> _moduleParserMock;

    private readonly CORunner _runner;

    public RunnerTests()
    {
        _externModuleTableMock = new Mock<ExternModuleTable>();
        _moduleTableMock = new Mock<ModuleTable>();
        _tokenizerMock = new Mock<Tokenizer>();
        _compilerMock = new Mock<OCompiler>();
        _moduleParserMock = new Mock<ModuleParser>();

        _runner = new CORunner(
            _externModuleTableMock.Object,
            _moduleTableMock.Object,
            _tokenizerMock.Object,
            _compilerMock.Object,
            _moduleParserMock.Object);
    }

    [Fact]
    public void Run_ShouldBe()
    {
        // Arrange
        var token1 = new ModuleToken("EntryPoint");
        var token2 = new InstructionToken("Ix00000000");
        var token3 = new DirectiveToken("ret");

        List<Token> tokens =
            [
                token1,
                token2,
                token3
            ];

        _tokenizerMock.Setup(t => t.TokenizeFromFile(_codePath)).Returns(tokens);

        var statement1 = new Statement();
        var statement2 = new Statement();

        statement1.AddToken(token2);
        statement2.AddToken(token3);

        List<Statement> statements =
            [
                statement1,
                statement2
            ];

        var modules = new Dictionary<string, List<Statement>>();
        modules.Add(token1.Value, statements);

        _moduleParserMock.Setup(p => p.ParseModules(tokens)).Returns(modules);
        _moduleTableMock.Setup(t => t.TryGetModule(token1.Value))
            .Returns(new Tuple<ModuleState, List<Statement>>(ModuleState.ReadyToCompile, statements));

        // Act
        _runner.Run(_codePath);

        // Assert
        //Assert.
    }
}