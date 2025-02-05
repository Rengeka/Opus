using AMD_x86.AMD_x86_Instructions;
using Domain;
using Domain.Result;

namespace AMD_x86;

public class AMD_x86_Fasade : ICPUFasade
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
        return null;
    }
    public CompilationResult<byte[]> POP(IBuffer buffer)
    { 
        return null; 
    }
    public CompilationResult<byte[]> ADD() 
    { 
        return null; 
    }
    public CompilationResult<byte[]> SUB() 
    { 
        return null; 
    }
    public CompilationResult<byte[]> MOV(IBuffer buffer, IBuffer sourse)
    {
        return null;
    }

    // ETC
}