using Compiler.CompileStrategies;
using Domain;
using Domain.Buffers;
using Domain.CallAgrements;
using Domain.Result;
using System.Runtime.InteropServices;
using System.Text;
using Tokens;

namespace Compiler;

public class OCompiler
{
    private readonly Dictionary<string, IOInstruction> _instructionTable;
    private readonly ICPUFacade _CPU;
    private readonly Dictionary<string, IntPtr> _stringPool;

    public OCompiler(Dictionary<string, IOInstruction> instructionTable, ICPUFacade CPU)
    {
        _instructionTable = instructionTable;
        _CPU = CPU;
        _stringPool = new Dictionary<string, IntPtr>();
    }

    // TODO Change call agreement system
    public CompilationResult<byte[]> COMPILE_MODULE(List<Statement> statements, Queue<ICallAgreement> callAgreementQueue)
    {
        byte[] code = [];

        // TODO REFACTOR THIS

        CallAgreementBuffer currentCallAgreementBuffer;

        if (callAgreementQueue.Count() > 0)
        {
            currentCallAgreementBuffer = new CallAgreementBuffer(callAgreementQueue.Dequeue());
        }
        else
        {
            currentCallAgreementBuffer = new CallAgreementBuffer(new STDOCallAgreement());
        }

        foreach (var statement in statements)
        {
            var instruction = _instructionTable[statement.Tokens[0].Value];
            var nextExpected = instruction.GetNextExpected();

            for (int i = 1; i < statement.Tokens.Count(); i++)
            {
                if (!IOInstruction.CompareToToken(statement.Tokens[i], nextExpected[i - 1]))
                {
                    return CompilationResult<byte[]>.Failure("Unexpected token found", ErrorCode.UnexpectedToken);
                }
            }

            var buffers = new List<IBuffer>();
            for (int i = 1; i < statement.Tokens.Count(); i++)
            {
                var token = statement.Tokens[i];
                if (token is LiteralToken && ((LiteralToken)token).Type == LiteralType.LString)
                {
                    buffers.Add(new LiteralBuffer(BitConverter.GetBytes(_stringPool[token.Value])));
                }
                else
                {
                    buffers.Add(statement.Tokens[i].GetBuffer());
                }
            }

            if (statement.Tokens[0] is InstructionToken && statement.Tokens[0].Value == "call")
            {
                currentCallAgreementBuffer.SetCallAgreement(callAgreementQueue.Dequeue());
            }

            buffers.Add(currentCallAgreementBuffer);

            var result = instruction.COMPILE(buffers.ToArray()).Value;
            if (result != null)
            {
                code = code.Concat(result).ToArray();
            }
        }

        return CompilationResult<byte[]>.Success(code);
    }

    public int COMPILE_STRINGS(string[] strings, IntPtr memory, int lastByteIndex)
    {
        foreach (var str in strings)
        {
            if (!_stringPool.ContainsKey(str))
            {
                var bytes = ASCIIEncoding.ASCII.GetBytes(str);

                Marshal.Copy(bytes, 0, memory + lastByteIndex, bytes.Length);

                _stringPool.Add(str, memory + (int)lastByteIndex);
                lastByteIndex += bytes.Length;
            }
        }

        return lastByteIndex;
    }
}