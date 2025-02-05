namespace AMD_x86;

internal class RegisterTable
{
    private const byte EAX = 0x50;
    private const byte ECX = 0x51;
    private const byte EDX = 0x52;
    private const byte EBX = 0x53;
    private const byte ESP = 0x54;
    private const byte EBP = 0x55;
    private const byte ESI = 0x56;
    private const byte EDI = 0x57;

    private readonly Dictionary<string, byte> _buffers;

    public RegisterTable()
    {
        _buffers = new Dictionary<string, byte>();

        _buffers.Add("EAX", EAX);
        _buffers.Add("ECX", ECX);
        _buffers.Add("EDX", EDX);
        _buffers.Add("EBX", EBX);
        _buffers.Add("ESP", ESP);
        _buffers.Add("EBP", EBP);
        _buffers.Add("ESI", ESI);
        _buffers.Add("EDI", EDI);
    }
}