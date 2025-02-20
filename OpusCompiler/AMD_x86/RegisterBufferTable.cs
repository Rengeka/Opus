using Domain;
using Domain.Buffers;

namespace AMD_x86;

public class RegisterBufferTable : IPhysicalBufferTable
{
    /*private const byte EAX = 0x50;
    private const byte ECX = 0x51;
    private const byte EDX = 0x52;
    private const byte EBX = 0x53;
    private const byte ESP = 0x54;
    private const byte EBP = 0x55;
    private const byte ESI = 0x56;
    private const byte EDI = 0x57;*/


    private const byte RAX = 0x00;
    private const byte RCX = 0x01;
    private const byte RDX = 0x02;
    private const byte RBX = 0x03;
    private const byte RSP = 0x04;
    private const byte RBP = 0x05;
    private const byte RSI = 0x06;
    private const byte RDI = 0x07;
    private const byte R8 = 0x08;
    private const byte R9 = 0x09;
    private const byte R10 = 0x10;

    private readonly Dictionary<string, byte> _buffers;

    public RegisterBufferTable()
    {
        _buffers = new Dictionary<string, byte>();

        _buffers.Add("RCX", RCX);
        _buffers.Add("RDX", RDX);
        _buffers.Add("R8", R8);
        _buffers.Add("R9", R9);

        _buffers.Add("RAX", RAX);
        _buffers.Add("RBX", RBX);
        _buffers.Add("RSP", RSP);
        _buffers.Add("RBP", RBP);
        _buffers.Add("RSI", RSI);
        _buffers.Add("RDI", RDI);
        _buffers.Add("R10", R10);

        /*_buffers.Add("RAX", RAX);
        _buffers.Add("RCX", RCX);
        _buffers.Add("RDX", RDX);
        _buffers.Add("RBX", RBX);
        _buffers.Add("RSP", RSP);
        _buffers.Add("RBP", RBP);
        _buffers.Add("RSI", RSI);
        _buffers.Add("RDI", RDI);
        _buffers.Add("R8", R8);
        _buffers.Add("R9", R9);*/
    }

    public List<IBuffer> GetBuffers()
    {
        var buffers = new List<IBuffer>();

        foreach(var buffer in _buffers)
        {
            buffers.Add(new RegisterBuffer(buffer.Value));
        }

        return buffers;
    }
}