using PaymentAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.Interfaces.Repositorys
{
    public interface IAccountRepository
    {
        Task<AccountDTO> Create(AccountCreateDTO model);
        Task<List<AccountDTO>> Read();
        Task<AccountDTO> Read(int id);
        Task<AccountDTO> Update(AccountUpdateDTO model);
        Task Delete(int id);
    }
}
