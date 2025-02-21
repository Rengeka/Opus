using Domain;
using Tokens;
using Domain.Modules;

namespace Parser;

public class ModuleParser
{
    public Dictionary<string, Module> ParseModules(List<Token> tokens)
    {
        var modules = new Dictionary<string, Module>();

        var currentModuleTokens = new List<Token>();
        var currentModuleStatements = new List<Statement>();
        modules.Add("GLOBAL", new Module(currentModuleStatements));

        foreach (var token in tokens)
        {
            if (token is ModuleToken)
            {
                var statements = ParseStatements(currentModuleTokens);
                currentModuleStatements.AddRange(statements);

                currentModuleStatements = new List<Statement>();
                currentModuleTokens = new List<Token>();

                modules.Add(token.Value, new Module(currentModuleStatements));
            }
            else
            {
                currentModuleTokens.Add(token);
            }
        }

        if (currentModuleTokens.Count() > 0)
        {
            var statements = ParseStatements(currentModuleTokens);
            currentModuleStatements.AddRange(statements);
        }

        CountReferences(modules);

        return modules;
    }

    private void CountReferences(Dictionary<string, Module> modules)
    {
        foreach (var module in modules)
        {
            foreach (var statement in module.Value.Statements)
            {
                foreach (var token in statement.Tokens)
                {
                    if (token is IdentifierToken)
                    {
                        Module m;
                        if (modules.TryGetValue((string)token.Value, out m)){
                            m.References++;
                        }
                    }
                }
            }
        }
    }

    private List<Statement> ParseStatements(List<Token> tokens)
    {
        var statements = new List<Statement>();
        Statement currentStatement = new Statement();

        foreach (var token in tokens)
        {
            if (token is DirectiveToken || token is InstructionToken)
            {
                if (currentStatement.Tokens.Count() != 0)
                {
                    statements.Add(currentStatement);
                }

                currentStatement = new Statement();
                currentStatement.Tokens.Add(token);
            }
            else
            {
                currentStatement.AddToken(token);
            }
        }

        if (!statements.Contains(currentStatement))
        {
            statements.Add(currentStatement);
        }

        return statements;
    }
}