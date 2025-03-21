using Domain.CallAgrements;

namespace Domain.Buffers;

public class CallAgreementBuffer : IBuffer
{
    private ICallAgreement _callAgreement;
    private int _counter;

    public CallAgreementBuffer(ICallAgreement callAgreement)
    {
        _callAgreement = callAgreement;
        _counter = 0;
    }

    public Object GetValue()
    {
        return _callAgreement;

        /*var inputBuffers = _callAgreement.GetInputBuffers();

        if (inputBuffers != null)
        {
            return inputBuffers[++_counter]; 
        }

        return null;*/
    }

    public void SetCallAgreement(ICallAgreement callAgreement) 
    {
        _callAgreement = callAgreement;
        _counter = 0;
    }
}