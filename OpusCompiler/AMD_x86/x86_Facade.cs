using AMD_x86.AMD_x86_Instructions;
using Domain;
using Domain.Buffers;
using Domain.CallAgrements;
using Domain.Result;

namespace AMD_x86;

public class x86_Facade : ICPUFacade
{
    private readonly IPhysicalBufferTable _registerTable;
    private readonly byte FIRST_EXT_REGISTER = 0x8;

    public x86_Facade()
    {
        _registerTable = new RegisterBufferTable();
    }

    public IPhysicalBufferTable GetPhysicalBufferTable()
    {
        return _registerTable;
    }

    public CompilationResult<byte[]> NOP()
    {
        return x86_NOP.COMPILE();
    }
    public CompilationResult<byte[]> PUSH(IBuffer buffer)
    {
        if (buffer is LiteralBuffer)
        {
            return x86_PUSH_imm16_32.COMPILE((byte)buffer.GetValue());
        }
        else if (buffer is RegisterBuffer)
        {
            return x86_PUSH_r64_16.COMPILE((byte)buffer.GetValue());
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
        if (buffer is RegisterBuffer && sourse is RegisterBuffer)
        {
            var isEXTReg = false;
            if ((byte)buffer.GetValue() >= FIRST_EXT_REGISTER)
            {
                isEXTReg = true;
            }

            return x86_MOV_r_m16_32_64.COMPILE((byte)buffer.GetValue(), (byte)sourse.GetValue(), isEXTReg);
        }
        else if (buffer is RegisterBuffer && sourse is LiteralBuffer)
        {
            var isEXTReg = false;
            if ((byte)buffer.GetValue() >= FIRST_EXT_REGISTER)
            {
                isEXTReg = true;
            }

            return x86_MOV_r_16_32_64_imm16_32_64.COMPILE((byte)buffer.GetValue(), (byte[])sourse.GetValue(), isEXTReg);
        }

        return CompilationResult<byte[]>.Failure("Wrong buffer", ErrorCode.CompilatonError);
    }
    public CompilationResult<byte[]> RET()
    {
        // TODO other variants of RETN
        return x86_RETN.COMPILE();
    }

    public CompilationResult<byte[]> LEA()
    {
        throw new NotImplementedException();
    }

    public CompilationResult<byte[]> CALL(IBuffer buffer)
    {
        return x86_CALL.COMPILE((byte)buffer.GetValue());
    }

  /*  public CompilationResult<byte[]> SYSCALL()
    {
        return x86_SYSCALL.COMPILE();
    }*/

    // ETC
}