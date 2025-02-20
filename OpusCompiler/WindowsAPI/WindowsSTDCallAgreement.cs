using Domain.CallAgrements;

namespace WindowsAPI;

public class WindowsSTDCallAgreement : ICallAgreement
{
    private readonly List<int> _inputBuffers;
    private readonly int _outputBuffer;

    private const byte RAX = 0x00;
    private const byte RCX = 0x01;
    private const byte RDX = 0x02;
    private const byte R8 = 0x08;
    private const byte R9 = 0x09;

    public WindowsSTDCallAgreement()
    {
        _inputBuffers = new List<int>();

        _inputBuffers.Add(RCX);
        _inputBuffers.Add(RDX);
        _inputBuffers.Add(R8);
        _inputBuffers.Add(R9);

        _outputBuffer = RAX;
    }

    public List<int> GetInputBuffers()
    {
        return _inputBuffers;
    }

    public int? GetOutputBuffer()
    {
        return _outputBuffer;
    }
}