using Domain.CallAgrements;

namespace Domain.Modules;

public class ExternModule
{
    public ICallAgreement CallAgreement { get; set; }
    public byte[] Ptr { get; set; }
}