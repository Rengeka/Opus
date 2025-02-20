using Domain;
using Domain.CallAgrements;

namespace BufferTable;

public class BufferTableFasade
{
    private readonly ArgumentBufferTable _argumentBufferTable;
    private readonly MultifunctionalBufferTable _multifunctionalBufferTable;
    private readonly ReserveBufferTable _reserveBufferTable;

    private IBuffer _acummulatorBuffer;
    private IBuffer _outputBuffer;

    public BufferTableFasade(
        ArgumentBufferTable argumentBufferTable,
        MultifunctionalBufferTable multifunctionalBufferTable,
        ReserveBufferTable reserveBufferTable,
        IPhysicalBufferTable physicalBufferTable)
    {
        _argumentBufferTable = argumentBufferTable;
        _multifunctionalBufferTable = multifunctionalBufferTable;
        _reserveBufferTable = reserveBufferTable;
        _reserveBufferTable.LoadBuffers(physicalBufferTable.GetBuffers());
    }

    public void AddBufferInReserve(IBuffer buffer)
    {
        _reserveBufferTable.LoadBuffer(buffer);
    }

    public IBuffer GetOutputBuffer()
    {
        if (_outputBuffer == null)
        {
            _outputBuffer = _reserveBufferTable.GetFreeBuffer();
        }

        return _outputBuffer;
    }

    public IBuffer GetOutputBuffer(ICallAgreement callAgreement)
    {
        if (callAgreement == null || callAgreement is STDOCallAgreement)
        {
            return _reserveBufferTable.GetFreeBuffer();
        }

        if (_outputBuffer == null)
        {
            //_reserveBufferTable.LoadBuffers(new List<IBuffer> { _outputBuffer });

            var sad = callAgreement.GetOutputBuffer();

            if (_reserveBufferTable.GetBuffer(callAgreement.GetOutputBuffer(), out _outputBuffer))
            {
                return _outputBuffer;
            }
            else
            {
                _outputBuffer = _reserveBufferTable.GetFreeBuffer();
            }
        }


        return _outputBuffer;
    }

    public IBuffer GetAcummulatorBuffer()
    {
        if (_acummulatorBuffer == null)
        {
            _acummulatorBuffer = _reserveBufferTable.GetFreeBuffer();
        }

        return _acummulatorBuffer;
    }
    public IBuffer GetNextArgumentBuffer(ICallAgreement callAgreement)
    {
        return _argumentBufferTable.GetNext(callAgreement);
    }

    public void ResetArgumentCounter()
    {
        _argumentBufferTable.ResetCounter();
    }

    public IBuffer GetNextMultifunctionalBuffer()
    {
        return _multifunctionalBufferTable.GetNext();
    }
}