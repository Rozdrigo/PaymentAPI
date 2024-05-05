using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Interfaces.Repositorys;

namespace PaymentAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpPost("MakePayment")]
        public ActionResult<PaymentDTO> MakePayment(MakePaymentDTO model)
        {
            try
            {
                Task<PaymentDTO> payment = _paymentRepository.MakePayment(model);

                return Ok(payment.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Read")]
        public ActionResult<List<PaymentDTO>> Read()
        {
            try
            {
                Task<List<PaymentDTO>> payments = _paymentRepository.Read();

                return Ok(payments.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Read/{id}")]
        public ActionResult<PaymentDTO> Read(int id)
        {
            try
            {
                Task<PaymentDTO> payment = _paymentRepository.Read(id);

                return Ok(payment.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
