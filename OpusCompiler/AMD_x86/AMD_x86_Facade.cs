using AMD_x86.AMD_x86_Instructions;
using Domain;
using Domain.Result;

namespace AMD_x86;

public class AMD_x86_Facade : ICPUFacade
{
    public CompilationResult<byte[]> NOP()
    {
        return AMD_x86_NOP.COMPILE();
    }
    public CompilationResult<byte[]> PUSH(IBuffer buffer)
    {
        if (buffer.GetBufferType() == BufferType.Literal)
        {
            return AMD_x86_PUSH_imm16_32.COMPILE(buffer.GetValue());
        }
        else if (buffer.GetBufferType() == BufferType.Register)
        {
            return AMD_x86_PUSH_r64_16.COMPILE(buffer.GetValue());
        }

        return CompilationResult<byte[]>.Failure("Compilation error", ErrorCode.InvalidArgument);
    }
    public CompilationResult<byte[]> POP()
    {
        throw new NotImplementedException();
    }
    public CompilationResult<byte[]> POP(IBuffer buffer)
    {
        throw new NotImplementedException();
    }
    public CompilationResult<byte[]> ADD()
    {
        throw new NotImplementedException();
    }
    public CompilationResult<byte[]> SUB()
    {
        throw new NotImplementedException();
    }
    public CompilationResult<byte[]> MOV(IBuffer buffer, IBuffer sourse)
    {
        throw new NotImplementedException();
    }
    public CompilationResult<byte[]> RET()
    {
        // TODO other variants of RETN
        return x86_RETN.COMPILE();
    }

    // ETC
}