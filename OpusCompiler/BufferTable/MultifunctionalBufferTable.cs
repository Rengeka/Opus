using Domain;

namespace BufferTable;

public class MultifunctionalBufferTable
{
    private RegisterBuffer _MB1;
    private RegisterBuffer _MB2;

    private readonly ReserveBufferTable _reserveBufferTable;

    private bool _counter;

    public MultifunctionalBufferTable()
    {
        _counter = true;
    }

    public IBuffer GetNext()
    {
        if (_counter)
        {
            _counter = false;
            return GetMB1();
        }
        else
        {
            _counter = true;
            return GetMB2();
        }
    }

    private IBuffer GetMB1()
    {
        if (_MB1 == null || _MB1.State != BufferState.free)
        {
            var buffer = _reserveBufferTable.GetFreeBuffer();
            if (buffer == null)
            {
                return null;
            }

            _MB1 = buffer;
        }

        return _MB1;
    }

    private IBuffer GetMB2()
    {
        if (_MB2 == null || _MB2.State != BufferState.free)
        {
            var buffer = _reserveBufferTable.GetFreeBuffer();
            if (buffer == null)
            {
                return null;
            }

            _MB2 = buffer;
        }

        return _MB2;
    }
}