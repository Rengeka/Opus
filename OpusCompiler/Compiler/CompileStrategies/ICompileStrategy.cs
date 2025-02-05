namespace Compiler.CompileStrategies;

public interface ICompileStrategy
{
    public List<Type> GetNextExpected();
}