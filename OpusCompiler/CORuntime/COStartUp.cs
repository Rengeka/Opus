using BufferTable;
using Compiler;
using Compiler.CompileStrategies;
using Domain;
using Lexer;
using Lexer.TokenizerStrategies;
using Parser;
using StateMachine;

namespace CORuntime;

public class COStartUp
{
    public void Start(ICPUFacade CPU, IOSAPI OSAPI, string codePath)
    {
        var moduleTable = CreateModuleTable();
        var externModuleTable = new ExternModuleTable(OSAPI.GetOSLibrary());
        var tokenizer = CreateTokenizer();

        var events = new List<IntPtr>();

        var reserveBufferTable = new ReserveBufferTable();
        var argumentBufferTable = new ArgumentBufferTable(reserveBufferTable);
        var multifunctionalBufferTable = new MultifunctionalBufferTable(reserveBufferTable);
        var bufferTable = new BufferTableFasade(argumentBufferTable, multifunctionalBufferTable,
            reserveBufferTable, CPU.GetPhysicalBufferTable());

        var instructions = GetInstructions(CPU, bufferTable, moduleTable, externModuleTable, events);
        var compiler = new OCompiler(instructions, CPU);

        var moduleParser = new ModuleParser();

        var runner = new CORunner(externModuleTable, moduleTable, tokenizer, compiler, moduleParser, events);
        //runner.Run(codePath);
        runner.StaticRun(codePath);
    }

    private Dictionary<string, IOInstruction> GetInstructions(
        ICPUFacade CPU,
        BufferTableFasade bufferTable,
        ModuleTable moduleTable,
        ExternModuleTable externModuleTable,
        List<IntPtr> events
        )
    {
        var instructions = new Dictionary<string, IOInstruction>()
        {
            { "00000000", new Ix00000000(CPU)},
            { "00000001", new Ix00000001(CPU, bufferTable)},
            { "00000002", new Ix00000002(bufferTable)},
            { "00000003", new Ix00000003(CPU, bufferTable)},
            { "0000000D", new Ix0000000D(CPU, bufferTable)},
            { "call", new call(CPU, bufferTable, moduleTable, externModuleTable, events)},
            { "ret", new ret(CPU)},
            { "jmp", new jmp() },
            { "INT", new INT() }
        };

        return instructions;
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