using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Interfaces.Repositorys;
using PaymentAPI.Domain.Models;
using PaymentAPI.Infrastructure.Context;
using PaymentAPI.Infrastructure.Services;

namespace PaymentAPI.Infrastructure.Repositorys
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentAPIContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(PaymentAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<PaymentDTO>> Read()
        {
            try
            {
                List<Payment> payments = _context.Payments.ToList();
                List<PaymentDTO> resultList = _mapper.Map<List<Payment>, List<PaymentDTO>>(payments);

                return Task.FromResult(resultList);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel listar pagamentos: " + ex.Message);
            }
        }

        public Task<PaymentDTO> Read(int id)
        {
            try
            {
                Payment payments = _context.Payments.Find(id);

                if (payments is not null)
                {
                    PaymentDTO result = _mapper.Map<Payment, PaymentDTO>(payments);

                    return Task.FromResult(result);
                }
                else
                {
                    throw new Exception("Não foi possivel encontrar pagamento");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel listar pagamentos: " + ex.Message);
            }
        }

        public Task<PaymentDTO> MakePayment(MakePaymentDTO model)
        {
            IDbContextTransaction tx = _context.Database.BeginTransaction();
            try
            {
                User Payer = _context.Users.Find(model.Payer);
                User Payee = _context.Users.Find(model.Payee);

                if (Payer is not null && Payee is not null)
                {

                    Account PayerAccount = _context.Accounts.Where(x => x.Owner.Id == Payer.Id).First();
                    Account PayeeAccount = _context.Accounts.Where(x => x.Owner.Id == Payee.Id).First();

                    if (PayerAccount is not null && PayeeAccount is not null)
                    {

                        if (Payer.Type == UserType.shopkeeper)
                        {
                            throw new Exception("Logistas não podem realizar transferencias");
                        }

                        if (PayerAccount.Status is StatusAccount.blocked || PayeeAccount.Status is StatusAccount.blocked)
                        {
                            throw new Exception("Conta inicial ou de destino invalidas");
                        }
                        if (PayerAccount.Value >= model.Value)
                        {

                            bool paymentIsAuthorizaded = AuthorizationService.AuthorizePayment();

                            if (!paymentIsAuthorizaded) {
                                throw new Exception("Pagamento não autorizado");
                            };

                            PayerAccount.Value -= model.Value;
                            PayeeAccount.Value += model.Value;

                            Payment payment = new Payment();
                            payment.Payee = Payee;
                            payment.Payer = Payer;
                            payment.Value = model.Value;
                            payment.ExecutionDate = DateTime.Now;

                            _context.Accounts.Update(PayeeAccount);
                            _context.Accounts.Update(PayerAccount);
                            _context.Payments.Add(payment);

                            _context.SaveChanges();

                            tx.Commit();

                            bool notificationIsSended = NotificationService.SendNotification(Payee.Email);

                            if(!notificationIsSended)
                            {
                                // Melhoria possivel,
                                // Aplicar tratativa de fila de chamadas
                            }

                            PaymentDTO paymentResponse = _mapper.Map<Payment, PaymentDTO>(payment);

                            return Task.FromResult(paymentResponse);
                        }
                        else
                        {
                            throw new Exception("Valor insuficiente");
                        }
                    }
                    else
                    {
                        throw new Exception("Conta inicial ou de destino inexistente");
                    }

                }
                else
                {   
                    tx.Rollback();
                    throw new Exception("É necessario informar o usuario de inicio e destino da transfência");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel realizar pagamento pagamentos: " + ex.Message);
            }
        }
    }
}
