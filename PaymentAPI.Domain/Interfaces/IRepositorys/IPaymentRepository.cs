using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Models;

namespace PaymentAPI.Domain.Interfaces.Repositorys
{
    public interface IPaymentRepository: IGeneric<Payment>
    {
        Task<PaymentDTO> MakePayment(MakePaymentDTO model);
        Task<List<PaymentDTO>> Read();
        Task<PaymentDTO> Read(int id);
    }
}
