using Domain.CallAgrements;

namespace Domain;

public class ExternModule
{
    public ICallAgreement CallAgreement {  get; set; }
    public byte[] Ptr { get; set; }
    //public IntPtr Ptr {  get; set; }
}