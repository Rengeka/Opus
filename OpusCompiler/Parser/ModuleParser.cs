using Tokens;

namespace Parser;

public class ModuleParser
{
    public Dictionary<string, List<Token>> ParseModules(List<Token> tokens)
    {
        var modules = new Dictionary<string, List<Token>>();
        
        var currentModule = new List<Token>();
        modules.Add("GLOBAL", currentModule);

        foreach (Token token in tokens)
        {
            if (token.GetType() == typeof(ModuleToken))
            {
                currentModule = new List<Token>();
                modules.Add(token.Value, currentModule);
            }
            else
            {
                currentModule.Add(token);
            }
        }

        return modules;
    }
}