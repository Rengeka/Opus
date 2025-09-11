using Opus.Grammar;
using Opus.Kernel.Result;

namespace Opus.Contracts;

public interface ITokenizer
{
    public CompilationResult<Token[]> Tokenize(string code);
}