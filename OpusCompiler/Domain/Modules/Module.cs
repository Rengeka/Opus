namespace Domain.Modules;

public class Module
{
    public List<Statement> Statements { get; init; }
    public ModuleState State {  get; set; }
    public int SelfReferencess { get; set; }
    public int ExternReferencess { get; set; }
    public byte[] Ptr { get; set; }

    public Module(List<Statement> statements)
    {
        Statements = statements;
        State = ModuleState.ReadyToCompile;
        Ptr = null;
        SelfReferencess = 0;
        ExternReferencess = 0;
    }
}