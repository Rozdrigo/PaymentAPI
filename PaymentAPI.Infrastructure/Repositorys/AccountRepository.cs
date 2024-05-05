using AutoMapper;
using PaymentAPI.Domain.DTOs;
using PaymentAPI.Domain.Interfaces.Repositorys;
using PaymentAPI.Domain.Models;
using PaymentAPI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Infrastructure.Repositorys
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PaymentAPIContext _context;
        private readonly IMapper _mapper;

        public AccountRepository(PaymentAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<AccountDTO> Create(AccountCreateDTO model)
        {
            try
            {
                Account newAccount = _mapper.Map<AccountCreateDTO, Account>(model);

                _context.Accounts.Add(newAccount);
                _context.SaveChanges();

                AccountDTO accountResponse = _mapper.Map<Account, AccountDTO>(newAccount);

                return Task.FromResult(accountResponse);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel criar conta: " + ex.Message);
            }
        }

        public Task<List<AccountDTO>> Read()
        {
            try
            {
                List<Account> accounts = _context.Accounts.ToList();

                List<AccountDTO> accountsReponse = _mapper.Map<List<Account>, List<AccountDTO>>(accounts);

                return Task.FromResult(accountsReponse);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel listar contas: " + ex.Message);
            }
        }

        public Task<AccountDTO> Read(int id)
        {
            try
            {
                Account account = _context.Accounts.Find(id);

                if (account is not null)
                {
                    AccountDTO accountResponse = _mapper.Map<Account, AccountDTO>(account);

                    return Task.FromResult(accountResponse);
                }
                else
                {
                    throw new Exception("Conta não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel retornar conta: " + ex.Message);
            }
        }

        public Task<AccountDTO> Update(AccountUpdateDTO model)
        {
            try
            {
                Account account = _context.Accounts.Find(model.Id);

                if (account is not null)
                {
                    _mapper.Map(model, account);
                    _context.Update(account);
                    _context.SaveChanges();

                    AccountDTO accountResponse = _mapper.Map<Account, AccountDTO>(account);

                    return Task.FromResult(accountResponse);
                }
                else
                {
                    throw new Exception("Conta não encontrada");
                }
            }
            catch (Exception ex) {
                throw new Exception("Não foi possivel atualizar conta: " + ex.Message);
            }
        }
        public Task Delete(int id)
        {
            try
            {
                Account account = _context.Accounts.Find(id);

                if (account is not null)
                {
                    _context.Accounts.Remove(account);
                    return Task.CompletedTask;
                }
                else
                {
                    throw new Exception("Conta não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel remover conta: " + ex.Message);
            }
        }
    }
}
