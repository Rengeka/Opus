using Domain.Result;

namespace Domain;

public interface ICPUFasade
{
    public CompilationResult<byte[]> NOP();
    public CompilationResult<byte[]> PUSH(IBuffer buffer);
    public CompilationResult<byte[]> POP();
    public CompilationResult<byte[]> POP(IBuffer buffer);
    public CompilationResult<byte[]> ADD();
    public CompilationResult<byte[]> SUB();
    public CompilationResult<byte[]> MOV(IBuffer buffer, IBuffer source);
}