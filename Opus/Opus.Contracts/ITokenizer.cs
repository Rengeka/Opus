using Opus.Grammar;
using Opus.Kernel.Result;

namespace Opus.Contracts;

public interface ITokenizer
{
    public Result<Token[]> Tokenize(string code);
}