using AMD_x86;
using BufferTable;
using Compiler;
using Compiler.CompileStrategies;
using Domain;
using Lexer;
using Lexer.TokenizerStrategies;
using StateMachine;
using StateMachine.ModuleLibraries;
using Parser;

namespace CORuntime;

public class COStartUp
{
    public void Start()
    {
        var moduleTable = CreateModuleTable();
        var externModuleTable = CreateExternModuleTable();
        var tokenizer = CreateTokenizer();

        var CPU = new AMD_x86_Facade();

        var argumentBufferTable = new ArgumentBufferTable();
        var multifunctionalBufferTable = new MultifunctionalBufferTable();
        var reserveBufferTable = new ReserveBufferTable();
        var bufferTable = new BufferTableFasade(argumentBufferTable, multifunctionalBufferTable, reserveBufferTable);

        var instructions = GetInstructions(CPU, bufferTable);
        var compiler = new OCompiler(instructions, CPU);

        var moduleParser = new ModuleParser();

        // TODO remove this shit
        var testCodePath = "C:\\Users\\stasi\\Desktop\\OpusCompiler\\CORuntime\\CodeSample.ops";

        var runner = new CORunner(externModuleTable, moduleTable, tokenizer, compiler, moduleParser);
        runner.Run(testCodePath);
    }

    private Dictionary<string, IOInstruction> GetInstructions(ICPUFacade CPU, BufferTableFasade bufferTable)
    {
        var instructions = new Dictionary<string, IOInstruction>()
        {
            { "00000000", new Ix00000000(CPU)},
            { "00000001", new Ix00000001(CPU, bufferTable)},
            { "ret", new ret(CPU)}
        };

        return instructions;
    }

    private ExternModuleTable CreateExternModuleTable()
    {
        // TODO Make it optional
        var windowsLib = new ExternWindowsLibrary();
        return new ExternModuleTable(windowsLib);
    }

    private ModuleTable CreateModuleTable()
    {
        return new ModuleTable();
    }

    private Tokenizer CreateTokenizer()
    {
        List<ITokenizeStrategy> strategies = [
            new TokenizeInstructionStrrategy(),
            new TokenizeLiteralStrategy(),
            new TokenizeDirectiveStrategy(),
            new TokenizeModuleStrategy(),
            new TokenizeIdentifierStrategy(),
        ];

        return new Tokenizer(strategies);
    }
}