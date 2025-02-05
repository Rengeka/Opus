namespace Domain;

public class Module
{
    public List<Statement> Statements { get; init; }

    public Module(List<Statement> statements)
    {
        Statements = statements;
    }
}