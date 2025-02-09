using Domain;
using Tokens;

namespace Parser;

public class ModuleParser
{
    public Dictionary<string, List<Statement>> ParseModules(List<Token> tokens)
    {
        var modules = new Dictionary<string, List<Statement>>();

        var currentModuleTokens = new List<Token>();
        var currentModuleStatements = new List<Statement>();    
        modules.Add("GLOBAL", currentModuleStatements);

        foreach (var token in tokens)
        {
            if (token is ModuleToken)
            {
                var statements = ParseStatements(currentModuleTokens);
                currentModuleStatements.AddRange(statements);

                currentModuleStatements = new List<Statement>();
                currentModuleTokens = new List<Token>();

                modules.Add(token.Value, currentModuleStatements);
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

        return modules;
    }

    public List<Statement> ParseStatements(List<Token> tokens)
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

    /*public Dictionary<string, List<Token>> ParseModules(List<Token> tokens)
    {
        var modules = new Dictionary<string, List<Statement>>();
        
        var currentModuleStatements = new List<Statement>();
        modules.Add("GLOBAL", currentModuleStatements);

        var isCurrentStatement = false;
        Statement currentStatement;

        Type nextExpected = null; 

        foreach (Token token in tokens)
        {
            if (nextExpected == null && 
                token.GetTokenType() == typeof(ModuleToken))
            {
                currentModuleStatements = new List<Statement>();
                modules.Add(token.Value, currentModuleStatements);
            }
            else
            {
                if (isCurrentStatement)
                {
                    if (nextExpected != null && token.GetTokenType() == nextExpected)
                    {

                    }
                }
                else
                {
                    isCurrentStatement = true;
                    currentStatement = new Statement(new List<Token>());
                    currentModuleStatements.Add(currentStatement);

                    if (token.GetTokenType() == typeof(InstructionToken)
                        || token.GetTokenType() == typeof(DirectiveToken))
                    {
                        currentStatement.AddToken(token);

                        nextExpected = token
                    }

              
                }


                currentModuleStatements.Add(token);
            }
        }

        return modules;
    }*/
}