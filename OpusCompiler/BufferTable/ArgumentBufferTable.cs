using Domain;
using Domain.CallAgrements;

namespace BufferTable;

public class ArgumentBufferTable
{
    private readonly List<IBuffer> _buffers;
    private readonly ReserveBufferTable _reserveBufferTable;
    private int _counter;
    private ICallAgreement _callAgreement;

    public ArgumentBufferTable(ReserveBufferTable reserveBufferTable)
    {
        _reserveBufferTable = reserveBufferTable;
        _buffers = new List<IBuffer>();
        _callAgreement = new STDOCallAgreement();
    }

    public IBuffer GetNext()
    {
        if (!(_callAgreement is STDOCallAgreement))
        {
            _callAgreement = new STDOCallAgreement();
            ResetBuffers();
            ResetCounter();
        }

        if (_buffers == null || _buffers.Count() < 4)
        {
            _buffers.Add(_reserveBufferTable.GetFreeBuffer());
        }

        var buffer = _buffers[_counter];
        _counter++;

        return buffer;
    }

    public IBuffer GetNext(ICallAgreement callAgreement)
    {
        if (callAgreement == null || callAgreement is STDOCallAgreement)
        {
            return GetNext();
        }

        if (!_callAgreement.Equals(callAgreement))
        {
            _callAgreement = callAgreement;
            ResetBuffers();
            ResetCounter();

            _buffers.AddRange(_reserveBufferTable.GetBuffers(_callAgreement.GetInputBuffers()));
        }

        var buffer = _buffers[_counter];
        _counter++;

        return buffer;
    }

    public void ResetBuffers()
    {
        _reserveBufferTable.LoadBuffers(_buffers);
        _buffers.Clear();
    }

    public void ResetCounter()
    {
        _counter = 0;
    }
}